using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace MouseController
{
	public partial class MainForm : Form
	{
		#region private variables

		private const string RecBtnOff = @"to start recording";
		private const string RecBtnOn = @"to stop recording";
		private const string PlayBtnOff = @"start playback";
		private const string PlayBtnOn = @"stop playback";
		private const string PlayBtnRep = @"stop repeating";
		private List<string> _keyOptions = new List<string>
		{
			"F1", "F2", "F3", "F4", "F5", "F6",
			"F7", "F8", "F9", "F10", "F11", "F12"
		};

		private static List<MouseEventContainer> _mouseEvents, _mouseEventsCopy;
		private static long _lastEvent;
		private static long _nextEvent;
		private static Button _startStopRecordingButton;
		private static Button _startStopPlaybackButton;

		private Options _opts;
		private string _loadedFile;
		private bool _showClick;
		private bool _addRndDelay;
		private bool _exitAfterPlayback;
		private bool _didRecord;
		private bool _recording;
		private bool _playing;
		private bool _repeating;
		private bool _delaying;

		private static int _clickCount;
		private List<MouseClickForm> _mcf;

		private double _timeStretch;

		private int _repeatCount;
		#endregion

		public MainForm(Options opts)
		{
			InitializeComponent();
            bgWorkerCheckVersion.RunWorkerAsync();
			PopulateStartStopComboboxes();
			LocaliseTimeStretch();

			Trace.AutoFlush = true;
			log("Starting " + Application.ProductName);

			_opts = opts;
			_recording = false;
			_didRecord = false;
			_playing = false;
			_repeating = false;
			_delaying = false;
			_clickCount = 1;
			_mcf = new List<MouseClickForm>();
			_timeStretch = 1;
			_repeatCount = 0;

			// Only load settings if no command options were present
			if (opts.Count > 0)
				SetOptions(opts);
			else
				LoadSettings();

			showClickNumberToolStripMenuItem.Checked = _showClick;
			addRandomDelayToRepeatToolStripMenuItem.Checked = _addRndDelay;
			_startStopRecordingButton = new Button();
			_startStopRecordingButton.Click += new EventHandler(startStopRecordingButton_Click);
			_startStopPlaybackButton = new Button();
			_startStopPlaybackButton.Click += new EventHandler(startStopPlaybackButton_Click);
			_keyboardHookID = SetKeyboardHook(_keyboardProc);
			if (_keyboardHookID == IntPtr.Zero)
				MessageBox.Show("Cannot listen to keyboard events.");
			toolStripStatusLabel.Text = "idle";
			UpdateTitle();

			if (opts.StartPlayback)
				StartStopPlayback();
		}

		#region General stuff

		/// <summary>
		/// Set options passed from command line parser
		/// </summary>
		/// <param name="opts"></param>
		private void SetOptions(Options opts)
		{
			_exitAfterPlayback = opts.ExitAfterPlayback;
			exitAfterPlaybackCompletedToolStripMenuItem.Checked = _exitAfterPlayback;
			if (opts.Delay > 0)
			{
				cbDelay.Checked = true;
				txtDelay.Text = opts.Delay.ToString();
				cmbDelay.SelectedItem = "sec";
			}
			if (opts.File != "")
				LoadMEC(opts.File);
			if (opts.RepeatAfter > 0)
			{
				cbRepeat.Checked = true;
				txtRepeat.Text = opts.RepeatAfter.ToString();
				cmbRepeat.SelectedItem = "sec";
			}
			if (opts.Repeats > 0)
			{
				cbRepeats.Checked = true;
				txtRepeats.Text = opts.Repeats.ToString();
			}
			if (opts.TimeStretch != 1)
			{
				_timeStretch = opts.TimeStretch;
			}
		}

		/// <summary>
		/// Update window title displaying time stretch
		/// </summary>
		private void UpdateTitle()
		{
			Text = "MouseController (" + _timeStretch.ToString("F1") + "x)";
		}

		/// <summary>
		/// Updates the label indicating the currently loaded file and its duration
		/// </summary>
		private void UpdateFileLabel()
		{
			string name;
			if (_loadedFile != null)
			{
				if (_loadedFile.Equals(String.Empty)) name = "unsaved recording";
				else name = Path.GetFileName(_loadedFile);

				lblFilename.Text = name + @" [" + Duration(_mouseEvents).ToString("F1") + "s]";
			}
		}

		/// <summary>
		/// Calculate the length of a recording in seconds
		/// </summary>
		/// <param name="mecList">MouseEventContainer list</param>
		/// <returns>duration in seconds</returns>
		private double Duration(List<MouseEventContainer> mecList) {
			long l = 0;
			mecList.ForEach(mec => l += mec.tOffset);
			return (double)l / 1000000 / _timeStretch;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void showClickNumberToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_showClick = !_showClick;
			showClickNumberToolStripMenuItem.Checked = _showClick;
		}

		private void addRandomDelayToRepeatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_addRndDelay = !_addRndDelay;
			addRandomDelayToRepeatToolStripMenuItem.Checked = _addRndDelay;
		}

		private void exitAfterPlaybackCompletedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_exitAfterPlayback = !_exitAfterPlayback;
			exitAfterPlaybackCompletedToolStripMenuItem.Checked = _exitAfterPlayback;
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm f = new AboutForm();
			f.ShowDialog();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Don't pop up windows when the "Exit after playback" flag is set
			if (_didRecord && (_mouseEvents != null) && (_mouseEvents.Count != 0) && !_exitAfterPlayback)
			{
				if (MessageBox.Show("Do you want to save your recording?", "Save before exit",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SaveMEC();
				}
			}
			SaveSettings();
			log("Closing " + Application.ProductName);
		}

		private void LocaliseTimeStretch()
		{
			this.x05ToolStripMenuItem.Tag = (0.5).ToString();
			this.x05ToolStripMenuItem.Text = this.x05ToolStripMenuItem.Tag + "x";
			this.x09ToolStripMenuItem.Tag = (0.9).ToString();
			this.x09ToolStripMenuItem.Text = this.x09ToolStripMenuItem.Tag + "x";
			this.x11toolStripMenuItem.Tag = (1.1).ToString();
			this.x11toolStripMenuItem.Text = this.x11toolStripMenuItem.Tag + "x";
		}

		private static void log(string arg)
		{
			DateTime dt = DateTime.Now;
			string ts = "[" + dt.Hour + ":" + dt.Minute + ":" + dt.Second + "." + dt.Millisecond + "] ";
			Trace.WriteLine(arg);
			Console.WriteLine(ts + arg);
		}

		#endregion

		#region Load/Save settings

		private void LoadSettings()
		{
			this.Location = Properties.Settings.Default.Position;
			cbRepeat.Checked = Properties.Settings.Default.RepeatChecked;
			txtRepeat.Text = Properties.Settings.Default.RepeatValue.ToString();
			cmbRepeat.SelectedIndex = Properties.Settings.Default.RepeatOption;
			cbDelay.Checked = Properties.Settings.Default.DelayChecked;
			txtDelay.Text = Properties.Settings.Default.DelayValue.ToString();
			cmbDelay.SelectedIndex = Properties.Settings.Default.DelayOption;
			cbRepeats.Checked = Properties.Settings.Default.RepeatsChecked;
			txtRepeats.Text = Properties.Settings.Default.RepeatsValue.ToString();
			_showClick = Properties.Settings.Default.ShowClick;
			_addRndDelay = Properties.Settings.Default.AddRndDelay;
			LoadMEC(Properties.Settings.Default.LoadedFile);
		}

		private void SaveSettings()
		{
			// Don't save settings if command line options were present
			if (_opts.Count > 0)
				return;
			Properties.Settings.Default.Position = this.Location;
			Properties.Settings.Default.RepeatChecked = cbRepeat.Checked;
			if (String.IsNullOrEmpty(txtRepeat.Text))
				Properties.Settings.Default.RepeatValue = 0;
			else
				try { Properties.Settings.Default.RepeatValue = Convert.ToInt32(txtRepeat.Text); }
				catch { }
			Properties.Settings.Default.RepeatOption = cmbRepeat.SelectedIndex;
			Properties.Settings.Default.DelayChecked = cbDelay.Checked;
			if (String.IsNullOrEmpty(txtDelay.Text))
				Properties.Settings.Default.DelayValue = 0;
			else
				try { Properties.Settings.Default.DelayValue = Convert.ToInt32(txtDelay.Text); }
				catch { }
			Properties.Settings.Default.DelayOption = cmbDelay.SelectedIndex;
			Properties.Settings.Default.RepeatsChecked = cbRepeats.Checked;
			if (String.IsNullOrEmpty(txtRepeats.Text))
				Properties.Settings.Default.RepeatsValue = 0;
			else
				try { Properties.Settings.Default.RepeatsValue = Convert.ToInt32(txtRepeats.Text); }
				catch { }
			Properties.Settings.Default.LoadedFile = _loadedFile;
			Properties.Settings.Default.ShowClick = _showClick;
			Properties.Settings.Default.AddRndDelay = _addRndDelay;
			Properties.Settings.Default.Save();
		}

		#endregion

		#region Start/Stop combo boxes

		private void PopulateStartStopComboboxes()
		{
			btnStartStopPlayback.Text = PlayBtnOff;
			lblRecord.Text = RecBtnOff;
			object[] options = _keyOptions.ToArray();
			cmbStartStopRecording.Items.AddRange(options);
			cmbStartStopRecording.SelectedItem =
				Properties.Settings.Default.StartStopRecording;
			cmbStartStopPlayback.Items.AddRange(options);
			cmbStartStopPlayback.SelectedItem =
				Properties.Settings.Default.StartStopPlayback;

			cmbStartStopPlayback.SelectedIndexChanged +=
				new System.EventHandler(cmbStartStopThings_SelectedIndexChanged);
			cmbStartStopRecording.SelectedIndexChanged +=
				new System.EventHandler(cmbStartStopThings_SelectedIndexChanged);
		}

		private void cmbStartStopThings_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckOption(sender as ComboBox, cmbStartStopRecording);
			CheckOption(sender as ComboBox, cmbStartStopPlayback);

			if (cmbStartStopRecording.SelectedItem != null)
				Properties.Settings.Default.StartStopRecording =
					cmbStartStopRecording.SelectedItem.ToString();
			if (cmbStartStopPlayback.SelectedItem != null)
				Properties.Settings.Default.StartStopPlayback =
					cmbStartStopPlayback.SelectedItem.ToString();
			Properties.Settings.Default.Save();
		}

		private void CheckOption(ComboBox master, ComboBox slave)
		{
			if (master.Equals(slave)) return;

			if ((slave.SelectedItem != null) && (slave.SelectedItem.Equals(master.SelectedItem)))
				slave.SelectedItem = null;
		}

		#endregion

		#region Recording

		private void startStopRecordingButton_Click(object sender, EventArgs e)
		{
			StartStopRecord();
		}

		private void StartStopRecord()
		{
			if (_playing) return;
			if (_mouseHookID == IntPtr.Zero)
			{
				_mouseHookID = SetMouseHook(_mouseProc);

				//If the SetWindowsHookEx function fails.
				if (_mouseHookID == IntPtr.Zero)
				{
					MessageBox.Show("SetWindowsHookEx Failed");
					return;
				}
				// start recording
				_clickCount = 1;
				_recording = true;
				lblRecord.Text = RecBtnOn;
				btnStartStopPlayback.Enabled = false;
				timeStretchToolStripMenuItem.Enabled = false;
				toolStripStatusLabel.Text = "recording ...";
				_lastEvent = DateTime.Now.Ticks;
				_mouseEvents = new List<MouseEventContainer>();
				_mouseEvents.Add(new MouseEventContainer(
					Cursor.Position.X, Cursor.Position.Y,
					0, MouseMessage.WM_NONE, "start"));
				log("Start recording");
			}
			else
			{
				//If the UnhookWindowsHookEx function fails.
				if (!UnhookWindowsHookEx(_mouseHookID))
				{
					MessageBox.Show("UnhookWindowsHookEx Failed");
					return;
				}
				// stop recording
				_recording = false;
				_didRecord = true;
				lblRecord.Text = RecBtnOff;
				btnStartStopPlayback.Enabled = true;
				timeStretchToolStripMenuItem.Enabled = true;
				_loadedFile = String.Empty;
				_mouseHookID = IntPtr.Zero;
				_mouseEvents.Add(new MouseEventContainer(
					Cursor.Position.X, Cursor.Position.Y,
					(DateTime.Now.Ticks - _lastEvent) / 10, MouseMessage.WM_NONE, "stop"));
				UpdateFileLabel();
				toolStripStatusLabel.Text = "idle";
				log("Stop recording");
			}
		}

		#endregion

		#region Playback

		private void startStopPlaybackButton_Click(object sender, EventArgs e)
		{
			StartStopPlayback();
		}

		// Called from MainForm(), startStopPlaybackButton_Click(), repeatTimer_Tick()
		private void StartStopPlayback()
		{
			if (_recording) return;
			if (_delaying)
			{
				delayTimer.Stop();
				_delaying = false;
			}
			if (_playing || _repeating)
			{
				_playing = false;
				_repeating = false;
				toolStripStatusLabel.Text = "idle";
				repeatTimer.Stop();
				playbackTimer.Stop();
				btnStartStopPlayback.Text = PlayBtnOff;
				lblRecord.Enabled = true;
				timeStretchToolStripMenuItem.Enabled = true;
			}
			else
			{
				if (_loadedFile == null)
					return;
				if (cbRepeat.Checked)
					btnStartStopPlayback.Text = PlayBtnRep;
				else
					btnStartStopPlayback.Text = PlayBtnOn;
				_repeatCount = 0;
				lblRecord.Enabled = false;
				timeStretchToolStripMenuItem.Enabled = false;

				if (cbDelay.Checked)
				{
					StartDelayedPlayback();
					_playing = _delaying = true;
				}
				else
				{
					StartPlayback();
					CheckRepeat();
				}
			}
		}

		private void StartPlayback()
		{
			_playing = true;
			_clickCount = 1;
			toolStripStatusLabel.Text = "playing ...";
			_mouseEventsCopy = new List<MouseEventContainer>(_mouseEvents.Count);
			_mouseEvents.ForEach(me => _mouseEventsCopy.Add(me));
			_mouseEventsCopy.Add(new MouseEventContainer(Cursor.Position.X, Cursor.Position.Y));
			_nextEvent = DateTime.Now.Ticks + _mouseEventsCopy[0].tOffset * 10;
			_repeatCount++;
			log("Starting playback - repeat: " + _repeatCount.ToString());
			PrepareMouseEventExecution();
		}

		private void playbackTimer_Tick(object sender, EventArgs e)
		{
			playbackTimer.Stop();
			ExecuteMouseEvent();
		}

		private void repeatTimer_Tick(object sender, EventArgs e)
		{
			int sec = Convert.ToInt32(((DateTime)(repeatTimer.Tag)).
				Subtract(DateTime.Now).TotalSeconds);
			if (!_playing)
				toolStripStatusLabel.Text = "Repeating in " + sec.ToString() + "s";
			if (sec <= 0)
			{
				UpdateTimerTag();
				if (!_playing)
				{
					int rtg = RepeatsToGo();
					if (rtg == 1)
					{
						log("Turning off repeat");
						_repeating = false;
						repeatTimer.Stop();
					}
					if (rtg > 0)
						StartPlayback();
					else
					{
						toolStripStatusLabel.Text = _repeatCount.ToString() + " repeats completed";
						StartStopPlayback();
					}
				}
				else
					log("Skipping repeat; already playing");
			}
		}

		private void delayTimer_Tick(object sender, EventArgs e)
		{
			int sec = Convert.ToInt32(((DateTime)(delayTimer.Tag)).
				Subtract(DateTime.Now).TotalSeconds);
			toolStripStatusLabel.Text = "Waiting for " + sec.ToString() + "s";
			if (sec <= 0)
			{
				delayTimer.Stop();
				CheckRepeat();
				StartPlayback();
			}
		}

		private void StartDelayedPlayback()
		{
			int time = Convert.ToInt32(txtDelay.Text);
			if (time <= 0) return;
			if (cmbDelay.SelectedItem.Equals("min"))
				delayTimer.Tag = DateTime.Now.AddMinutes(time);
			else
				delayTimer.Tag = DateTime.Now.AddSeconds(time);
			log("Starting delay timer. Delay until " + ((DateTime)delayTimer.Tag).ToString());
			delayTimer.Start();
		}

		private void CheckRepeat()
		{
			if (cbRepeat.Checked && !_repeating)
			{
				repeatTimer.Tag = DateTime.Now;
				if (UpdateTimerTag())
				{
					repeatTimer.Interval = 1000;
					repeatTimer.Start();
					_repeating = true;
					log("Starting repeatTimer (1s)");
				}
			}
		}

		private int RepeatsToGo()
		{
			int rtg = 0;
			if (cbRepeats.Checked)
				try
				{
					rtg = Convert.ToInt32(txtRepeats.Text) - _repeatCount;
				}
				catch
				{ }
			else if (cbRepeat.Checked)
				rtg = 2;
			log("Repeats to go: " + rtg.ToString());
			return rtg;
		}

		private bool UpdateTimerTag()
		{
			try
			{
				Random r = new Random((int)DateTime.Now.Ticks);
				int time = Convert.ToInt32(txtRepeat.Text);
				if (time <= 0) return false;
				DateTime t = (DateTime)repeatTimer.Tag;
				if (cmbRepeat.SelectedItem.Equals("min"))
					t = t.AddMinutes(time);
				else
					t = t.AddSeconds(time);
				if (_addRndDelay)
					t = t.AddSeconds((int)(r.NextDouble() * 15));
				repeatTimer.Tag = t;
				log("Starting next repeat at: " + t.ToString() + "." + t.Millisecond.ToString());
				return true;
			}
			catch
			{
				toolStripStatusLabel.Text = "Couldn't start repeat timer";
				log("Couldn't start repeat timer");
				return false;
			}
		}

		private void PrepareMouseEventExecution()
		{
			if (!_playing || (_mouseEventsCopy.Count == 0))
			{
				PlaybackStopped();
				return;
			}

			int delay = 1;
			_nextEvent += (long)((double)_mouseEventsCopy[0].tOffset * 10 / _timeStretch);
			switch (_mouseEventsCopy[0].MouseMsg)
			{
				case MouseMessage.WM_TIMESCALE:
					try
					{
						_timeStretch = Convert.ToDouble(_mouseEventsCopy[0].Tag);
					}
					catch { }
					break;
				default:
					delay = (int)((_nextEvent - DateTime.Now.Ticks) / 10000);
					break;
			}
//			Console.WriteLine("Preparing " + _mouseEventsCopy[0].MouseMsg + " in " + delay.ToString());
			playbackTimer.Interval = delay > 0 ? delay : 1;
			playbackTimer.Start();
		}

		private void PlaybackStopped()
		{
			_playing = false;
			if (!_repeating)
			{
				if (RepeatsToGo() > 0)
					StartPlayback();
				else
				{
					btnStartStopPlayback.Text = PlayBtnOff;
					lblRecord.Enabled = true;
					_repeatCount = 0;
					toolStripStatusLabel.Text = "idle";
					timeStretchToolStripMenuItem.Enabled = true;
					if (_exitAfterPlayback)
					{
						log("Requested exit");
						Close();
					}
				}
			}
		}

		private void ExecuteMouseEvent()
		{
			MouseEventContainer mec = _mouseEventsCopy[0];
			_mouseEventsCopy.RemoveAt(0);
			Cursor.Position = new Point(mec.X, mec.Y);
			switch (mec.MouseMsg)
			{
				case MouseMessage.WM_LBUTTONDOWN:
					mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new IntPtr());
					if (_showClick)
					{
						MouseClickForm f = new MouseClickForm(mec.X, mec.Y, mec.Tag);
					}
					break;
				case MouseMessage.WM_LBUTTONUP:
					mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new IntPtr());
					break;
				case MouseMessage.WM_RBUTTONDOWN:
					mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, new IntPtr());
					if (_showClick)
					{
						MouseClickForm f = new MouseClickForm(mec.X, mec.Y, mec.Tag);
					}
					break;
				case MouseMessage.WM_RBUTTONUP:
					mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, new IntPtr());
					break;
				default: break;
			}
			PrepareMouseEventExecution();
		}

		#endregion

		#region Load/Save Files

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadMEC();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveMEC();
		}

		private void LoadMEC()
		{
			if (openMECDialog.ShowDialog() == DialogResult.OK)
				LoadMEC(openMECDialog.FileName);
		}

		private void LoadMEC(string file)
		{
			if (!File.Exists(file)) return;
			try
			{
				using (var fs = new FileStream(file, FileMode.Open))
				{
					var dcs = new DataContractSerializer(typeof(List<MouseEventContainer>));
					_mouseEvents = dcs.ReadObject(fs) as List<MouseEventContainer>;
				}
				_didRecord = false;
				btnStartStopPlayback.Enabled = true;
				_loadedFile = file;
				UpdateFileLabel();
				log("File loaded: " + file);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error opening file",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SaveMEC()
		{
			if (_mouseEvents == null)
			{
				MessageBox.Show("Nothing to save", "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (saveMECDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					using (var fs = new FileStream(saveMECDialog.FileName, FileMode.Create))
					{
						var dcs = new DataContractSerializer(_mouseEvents.GetType());
						dcs.WriteObject(fs, _mouseEvents);
					}
					_didRecord = false;
					_loadedFile = saveMECDialog.FileName;
					UpdateFileLabel();
					log("File saved: " + saveMECDialog.FileName);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error saving file",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		#endregion

		#region Time Stretch

		private void TimeStretchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_timeStretch = Convert.ToDouble(((ToolStripMenuItem)sender).Tag);

			UpdateTitle();
			UpdateFileLabel();
		}

		private void CustomTimeStretchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TimeStretchDialog d = new TimeStretchDialog(_timeStretch);
			d.ShowDialog();
			if (d.DialogResult == DialogResult.OK)
			{
				_timeStretch = d.TimeStretch;
				UpdateTitle();
				UpdateFileLabel();
			}
		}

		#endregion

		#region Global Hook stuff

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		#endregion

		#region Mouse Hook stuff

		public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

		private static IntPtr _mouseHookID = IntPtr.Zero;
		private static LowLevelMouseProc _mouseProc = MouseHookCallback;

		private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
		private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
		private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
		private const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
		private const int WH_MOUSE_LL = 14;

		#region DllImports

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll")]
		private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

		#endregion

		private static IntPtr SetMouseHook(LowLevelMouseProc proc)
		{
			using (Process curProcess = Process.GetCurrentProcess())
			using (ProcessModule curModule = curProcess.MainModule)
			{
				return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
			}
		}

		private enum MouseMessage
		{
			WM_NONE = 0,
			WM_TIMESCALE,
			WM_LBUTTONDOWN = 0x0201,
			WM_LBUTTONUP = 0x0202,
			WM_MOUSEMOVE = 0x0200,
			WM_MOUSEWHEEL = 0x020A,
			WM_RBUTTONDOWN = 0x0204,
			WM_RBUTTONUP = 0x0205
		}

		[StructLayout(LayoutKind.Sequential)]
		private class MouseHookStruct
		{
			public POINT pt;
			public int hwnd;
			public int wHitTestCode;
			public int dwExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		private class POINT
		{
			public int x;
			public int y;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct MSLLHOOKSTRUCT
		{
			public POINT pt;
			public uint mouseData;
			public uint flags;
			public uint time;
			public IntPtr dwExtraInfo;
		}

		private static IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
			if (nCode >= 0)
			{
				long now = DateTime.Now.Ticks;
				MouseMessage mm = (MouseMessage)wParam;
				string tag = String.Empty;
				if (mm.Equals(MouseMessage.WM_LBUTTONDOWN) || mm.Equals(MouseMessage.WM_RBUTTONDOWN))
				{
					tag = _clickCount.ToString();
					_clickCount++;
				}
				_mouseEvents.Add(new MouseEventContainer(
					hookStruct.pt.x, hookStruct.pt.y, (now - _lastEvent) / 10, mm, tag));
				_lastEvent = now;
			}
			return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
		}

		#endregion

		#region Keyboard hook stuff

		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

		private const int WH_KEYBOARD_LL = 13;
		private const int WM_KEYDOWN = 0x0100;
		private static LowLevelKeyboardProc _keyboardProc = KeyboardHookCallback;
		private static IntPtr _keyboardHookID = IntPtr.Zero;

		private static IntPtr SetKeyboardHook(LowLevelKeyboardProc proc)
		{
			using (Process curProcess = Process.GetCurrentProcess())
			using (ProcessModule curModule = curProcess.MainModule)
			{
				return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

		private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
			{
				int vkCode = Marshal.ReadInt32(lParam);
				string k = ((Keys)vkCode).ToString();
				log(k);
				if (k.Equals(Properties.Settings.Default.StartStopRecording))
					_startStopRecordingButton.PerformClick();
				if (k.Equals(Properties.Settings.Default.StartStopPlayback))
					_startStopPlaybackButton.PerformClick();
			}
			return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
		}

        #endregion

        #region MouseEvents Container

        [DataContract(Name = "MouseEvents")]
		private class MouseEventContainer
		{
			[DataMember]
			public long tOffset { get; set; }
			public int X { get { return _pos.X; } set { _pos.X = value; } }
			public int Y { get { return _pos.Y; } set { _pos.Y = value; } }
			[DataMember]
			public Point pos { get { return _pos; } set { _pos = value; } }
			[DataMember]
			public MouseMessage MouseMsg { get; set; }
			[DataMember]
			public string Tag { get; set; }

			private Point _pos;

			public MouseEventContainer() : this(0, 0, 0, MouseMessage.WM_NONE, "") { }

			public MouseEventContainer(int x, int y) : this(x, y, 0, MouseMessage.WM_NONE, "") { }

			public MouseEventContainer(int x, int y, long tOffset, MouseMessage msg, string tag)
			{
				X = x;
				Y = y;
				MouseMsg = msg;
				this.tOffset = tOffset;
				Tag = tag;
			}
		}

        #endregion

        #region Background Worker
        private void bgWorkerCheckVersion_DoWork(object sender, DoWorkEventArgs e)
        {
            ChkVersion.Check();
        }

        #endregion
    }
}
