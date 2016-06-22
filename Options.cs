using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MouseController
{
	/// <summary>
	/// Handle command line options.
	/// This includes parsing and storing them
	/// </summary>
	public class Options
	{
		public Options(string[] args)
		{
			// set defaults
			ExitAfterPlayback = false;
			StartPlayback = false;
			ShowHelp = false;
			Delay = 0;
			File = String.Empty;
			RepeatAfter = 0;
			Repeats = 0;
			TimeStretch = 1;

			ParseError = String.Empty;
			Count = 0;

			if ((args == null) || (args.Count() == 0))
				return;
			else if (args.Count() == 1)
			{
				if (Parse(args[0], String.Empty))
					Count++;
				else if (Parse("-f", args[0]))
				{
					ParseError = String.Empty;
					Count++;
				}
				return;
			}

			int i = 0;
			string arg1, arg2;
			while (i < args.Count())
			{
				arg1 = args[i];
				arg2 = String.Empty;
				if (i + 1 < args.Count())
					arg2 = args[i + 1];
				if (Parse(arg1, arg2))
					Count++;
				i += _argsUsed;
			}
		}

		private int _argsUsed;

		#region public properties
		public bool ExitAfterPlayback { private set; get; }
		public bool StartPlayback { private set; get; }
		public int Delay { private set; get; }
		public int Repeats { private set; get; }
		public int RepeatAfter { private set; get; }
		public string File { private set; get; }
		public double TimeStretch { private set; get; }

		public int Count { private set; get; }

		public bool ShowHelp { private set; get; }
		public string Help
		{
			get
			{
				return "Usage: MouseController [OPTION]\n" +
					"OPTION can be any of\n" +
					"-d N, --delay N:  delay playback for N seconds\n" +
					"-f PATH, --file PATH:  load a .mcd file\n" +
					"-h, --help:  show this text\n" +
					"-n N, --repeats N:  repeat playback N times; requires -f\n" +
					"-p, --play:  start playback\n" +
					"-q, --quit:  exit program after playback has finished\n" +
					"-r N, --repeatAfter N: repeat playback after N seconds\n" +
					"-t X, --timeStretch X:  set time stretching to X";
			}
		}
		public string ParseError { private set; get; }
		#endregion

		private bool Parse(string arg1, string arg2)
		{
			bool parseError = false;
			_argsUsed = 1;
			switch (arg1)
			{
				case "-d":
				case "--delay":
					_argsUsed = 2;
					try { Delay = Convert.ToInt32(arg2); }
					catch (Exception e)
					{
						parseError = true;
						ParseError = e.Message;
					}
					break;
				case "-f":
				case "--file":
					_argsUsed = 2;
					if ((arg2 != "") && (System.IO.File.Exists(arg2)))
						File = arg2;
					else
					{
						parseError = true;
						ParseError = "File not found: " + arg2;
					}
					break;
				case "-h":
				case "--help":
					ShowHelp = true;
					break;
				case "-p":
				case "--play":
					StartPlayback = true;
					break;
				case "-q":
				case "--quit":
					ExitAfterPlayback = true;
					break;
				case "-n":
				case "--repeats":
					_argsUsed = 2;
					try { Repeats = Convert.ToInt32(arg2); }
					catch (Exception e)
					{
						parseError = true;
						ParseError = e.Message;
					}
					break;
				case "-r":
				case "--repeatAfter":
					_argsUsed = 2;
					try { RepeatAfter = Convert.ToInt32(arg2); }
					catch (Exception e)
					{
						parseError = true;
						ParseError = e.Message;
					}
					break;
				case "-t":
				case "--timeStretch":
					_argsUsed = 2;
					try { TimeStretch = Convert.ToDouble(arg2); }
					catch (Exception e)
					{
						parseError = true;
						ParseError = e.Message;
					}
					break;
				default:
					parseError = true;
					ParseError = "Unknown option: " + arg1;
					break;
			}
			return !parseError;
		}
	}
}
