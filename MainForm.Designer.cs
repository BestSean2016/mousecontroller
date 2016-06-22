namespace MouseController
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playbackTimer = new System.Windows.Forms.Timer(this.components);
            this.saveMECDialog = new System.Windows.Forms.SaveFileDialog();
            this.openMECDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClickNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRandomDelayToRepeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitAfterPlaybackCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeStretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x05ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x09ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x11toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbRepeat = new System.Windows.Forms.CheckBox();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.repeatTimer = new System.Windows.Forms.Timer(this.components);
            this.cmbRepeat = new System.Windows.Forms.ComboBox();
            this.cmbDelay = new System.Windows.Forms.ComboBox();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.cbDelay = new System.Windows.Forms.CheckBox();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.cmbStartStopPlayback = new System.Windows.Forms.ComboBox();
            this.cmbStartStopRecording = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblPlayback = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnStartStopPlayback = new System.Windows.Forms.Button();
            this.cbRepeats = new System.Windows.Forms.CheckBox();
            this.txtRepeats = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bgWorkerCheckVersion = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // playbackTimer
            // 
            this.playbackTimer.Tick += new System.EventHandler(this.playbackTimer_Tick);
            // 
            // saveMECDialog
            // 
            this.saveMECDialog.DefaultExt = "mcd";
            this.saveMECDialog.Filter = "MouseRecorder Files|*.mcd";
            this.saveMECDialog.Title = "Save MouseController data to file";
            // 
            // openMECDialog
            // 
            this.openMECDialog.DefaultExt = "mcd";
            this.openMECDialog.Filter = "MouseRecorder Files|*.mcd";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.cursorToolStripMenuItem,
            this.timeStretchToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(274, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::MouseController.Properties.Resources.folder_horizontal_open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::MouseController.Properties.Resources.disk;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cursorToolStripMenuItem
            // 
            this.cursorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showClickNumberToolStripMenuItem,
            this.addRandomDelayToRepeatToolStripMenuItem,
            this.exitAfterPlaybackCompletedToolStripMenuItem});
            this.cursorToolStripMenuItem.Name = "cursorToolStripMenuItem";
            this.cursorToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.cursorToolStripMenuItem.Text = "Extras";
            // 
            // showClickNumberToolStripMenuItem
            // 
            this.showClickNumberToolStripMenuItem.Name = "showClickNumberToolStripMenuItem";
            this.showClickNumberToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showClickNumberToolStripMenuItem.Text = "Show click number";
            this.showClickNumberToolStripMenuItem.Click += new System.EventHandler(this.showClickNumberToolStripMenuItem_Click);
            // 
            // addRandomDelayToRepeatToolStripMenuItem
            // 
            this.addRandomDelayToRepeatToolStripMenuItem.Name = "addRandomDelayToRepeatToolStripMenuItem";
            this.addRandomDelayToRepeatToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.addRandomDelayToRepeatToolStripMenuItem.Text = "Add random delay to repeat";
            this.addRandomDelayToRepeatToolStripMenuItem.Click += new System.EventHandler(this.addRandomDelayToRepeatToolStripMenuItem_Click);
            // 
            // exitAfterPlaybackCompletedToolStripMenuItem
            // 
            this.exitAfterPlaybackCompletedToolStripMenuItem.Name = "exitAfterPlaybackCompletedToolStripMenuItem";
            this.exitAfterPlaybackCompletedToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.exitAfterPlaybackCompletedToolStripMenuItem.Text = "Exit after playback completed";
            this.exitAfterPlaybackCompletedToolStripMenuItem.Click += new System.EventHandler(this.exitAfterPlaybackCompletedToolStripMenuItem_Click);
            // 
            // timeStretchToolStripMenuItem
            // 
            this.timeStretchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x05ToolStripMenuItem,
            this.x09ToolStripMenuItem,
            this.x1ToolStripMenuItem,
            this.x11toolStripMenuItem,
            this.x2ToolStripMenuItem,
            this.xCustomToolStripMenuItem});
            this.timeStretchToolStripMenuItem.Name = "timeStretchToolStripMenuItem";
            this.timeStretchToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.timeStretchToolStripMenuItem.Text = "Time stretch";
            // 
            // x05ToolStripMenuItem
            // 
            this.x05ToolStripMenuItem.Name = "x05ToolStripMenuItem";
            this.x05ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.x05ToolStripMenuItem.Tag = "0.5";
            this.x05ToolStripMenuItem.Text = "0.5x";
            this.x05ToolStripMenuItem.Click += new System.EventHandler(this.TimeStretchToolStripMenuItem_Click);
            // 
            // x09ToolStripMenuItem
            // 
            this.x09ToolStripMenuItem.Name = "x09ToolStripMenuItem";
            this.x09ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.x09ToolStripMenuItem.Tag = "0.9";
            this.x09ToolStripMenuItem.Text = "0.9x";
            this.x09ToolStripMenuItem.Click += new System.EventHandler(this.TimeStretchToolStripMenuItem_Click);
            // 
            // x1ToolStripMenuItem
            // 
            this.x1ToolStripMenuItem.Name = "x1ToolStripMenuItem";
            this.x1ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.x1ToolStripMenuItem.Tag = "1";
            this.x1ToolStripMenuItem.Text = "1x";
            this.x1ToolStripMenuItem.Click += new System.EventHandler(this.TimeStretchToolStripMenuItem_Click);
            // 
            // x11toolStripMenuItem
            // 
            this.x11toolStripMenuItem.Name = "x11toolStripMenuItem";
            this.x11toolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.x11toolStripMenuItem.Tag = "1.1";
            this.x11toolStripMenuItem.Text = "1.1x";
            this.x11toolStripMenuItem.Click += new System.EventHandler(this.TimeStretchToolStripMenuItem_Click);
            // 
            // x2ToolStripMenuItem
            // 
            this.x2ToolStripMenuItem.Name = "x2ToolStripMenuItem";
            this.x2ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.x2ToolStripMenuItem.Tag = "2";
            this.x2ToolStripMenuItem.Text = "2x";
            this.x2ToolStripMenuItem.Click += new System.EventHandler(this.TimeStretchToolStripMenuItem_Click);
            // 
            // xCustomToolStripMenuItem
            // 
            this.xCustomToolStripMenuItem.Name = "xCustomToolStripMenuItem";
            this.xCustomToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.xCustomToolStripMenuItem.Tag = "";
            this.xCustomToolStripMenuItem.Text = "Custom";
            this.xCustomToolStripMenuItem.Click += new System.EventHandler(this.CustomTimeStretchToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 187);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(274, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // cbRepeat
            // 
            this.cbRepeat.AutoSize = true;
            this.cbRepeat.Location = new System.Drawing.Point(15, 85);
            this.cbRepeat.Name = "cbRepeat";
            this.cbRepeat.Size = new System.Drawing.Size(90, 17);
            this.cbRepeat.TabIndex = 5;
            this.cbRepeat.Text = "Repeat every";
            this.cbRepeat.UseVisualStyleBackColor = true;
            // 
            // txtRepeat
            // 
            this.txtRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepeat.Location = new System.Drawing.Point(108, 83);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(89, 20);
            this.txtRepeat.TabIndex = 6;
            // 
            // repeatTimer
            // 
            this.repeatTimer.Interval = 1000;
            this.repeatTimer.Tick += new System.EventHandler(this.repeatTimer_Tick);
            // 
            // cmbRepeat
            // 
            this.cmbRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRepeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRepeat.FormattingEnabled = true;
            this.cmbRepeat.Items.AddRange(new object[] {
            "sec",
            "min"});
            this.cmbRepeat.Location = new System.Drawing.Point(203, 82);
            this.cmbRepeat.Name = "cmbRepeat";
            this.cmbRepeat.Size = new System.Drawing.Size(59, 21);
            this.cmbRepeat.TabIndex = 7;
            // 
            // cmbDelay
            // 
            this.cmbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDelay.FormattingEnabled = true;
            this.cmbDelay.Items.AddRange(new object[] {
            "sec",
            "min"});
            this.cmbDelay.Location = new System.Drawing.Point(203, 134);
            this.cmbDelay.Name = "cmbDelay";
            this.cmbDelay.Size = new System.Drawing.Size(59, 21);
            this.cmbDelay.TabIndex = 10;
            // 
            // txtDelay
            // 
            this.txtDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDelay.Location = new System.Drawing.Point(108, 135);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(89, 20);
            this.txtDelay.TabIndex = 9;
            // 
            // cbDelay
            // 
            this.cbDelay.AutoSize = true;
            this.cbDelay.Location = new System.Drawing.Point(15, 137);
            this.cbDelay.Name = "cbDelay";
            this.cbDelay.Size = new System.Drawing.Size(67, 17);
            this.cbDelay.TabIndex = 8;
            this.cbDelay.Text = "Delay by";
            this.cbDelay.UseVisualStyleBackColor = true;
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // cmbStartStopPlayback
            // 
            this.cmbStartStopPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartStopPlayback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartStopPlayback.FormattingEnabled = true;
            this.cmbStartStopPlayback.Location = new System.Drawing.Point(51, 54);
            this.cmbStartStopPlayback.Name = "cmbStartStopPlayback";
            this.cmbStartStopPlayback.Size = new System.Drawing.Size(48, 21);
            this.cmbStartStopPlayback.TabIndex = 12;
            // 
            // cmbStartStopRecording
            // 
            this.cmbStartStopRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartStopRecording.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartStopRecording.FormattingEnabled = true;
            this.cmbStartStopRecording.Location = new System.Drawing.Point(51, 27);
            this.cmbStartStopRecording.Name = "cmbStartStopRecording";
            this.cmbStartStopRecording.Size = new System.Drawing.Size(48, 21);
            this.cmbStartStopRecording.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Press";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Press";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(116, 30);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(86, 13);
            this.lblRecord.TabIndex = 15;
            this.lblRecord.Text = "to start recording";
            // 
            // lblPlayback
            // 
            this.lblPlayback.AutoSize = true;
            this.lblPlayback.Location = new System.Drawing.Point(116, 57);
            this.lblPlayback.Name = "lblPlayback";
            this.lblPlayback.Size = new System.Drawing.Size(16, 13);
            this.lblPlayback.TabIndex = 16;
            this.lblPlayback.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "loaded:";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(53, 166);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(10, 13);
            this.lblFilename.TabIndex = 18;
            this.lblFilename.Text = "-";
            // 
            // btnStartStopPlayback
            // 
            this.btnStartStopPlayback.Location = new System.Drawing.Point(150, 52);
            this.btnStartStopPlayback.Name = "btnStartStopPlayback";
            this.btnStartStopPlayback.Size = new System.Drawing.Size(112, 23);
            this.btnStartStopPlayback.TabIndex = 19;
            this.btnStartStopPlayback.Text = "start playback";
            this.btnStartStopPlayback.UseVisualStyleBackColor = true;
            this.btnStartStopPlayback.Click += new System.EventHandler(this.startStopPlaybackButton_Click);
            // 
            // cbRepeats
            // 
            this.cbRepeats.AutoSize = true;
            this.cbRepeats.Location = new System.Drawing.Point(15, 111);
            this.cbRepeats.Name = "cbRepeats";
            this.cbRepeats.Size = new System.Drawing.Size(61, 17);
            this.cbRepeats.TabIndex = 5;
            this.cbRepeats.Text = "Repeat";
            this.cbRepeats.UseVisualStyleBackColor = true;
            // 
            // txtRepeats
            // 
            this.txtRepeats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepeats.Location = new System.Drawing.Point(108, 109);
            this.txtRepeats.Name = "txtRepeats";
            this.txtRepeats.Size = new System.Drawing.Size(89, 20);
            this.txtRepeats.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "times";
            // 
            // bgWorkerCheckVersion
            // 
            this.bgWorkerCheckVersion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerCheckVersion_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 209);
            this.Controls.Add(this.btnStartStopPlayback);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPlayback);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStartStopPlayback);
            this.Controls.Add(this.cmbStartStopRecording);
            this.Controls.Add(this.cmbDelay);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.cbDelay);
            this.Controls.Add(this.cmbRepeat);
            this.Controls.Add(this.txtRepeats);
            this.Controls.Add(this.txtRepeat);
            this.Controls.Add(this.cbRepeats);
            this.Controls.Add(this.cbRepeat);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(240, 160);
            this.Name = "MainForm";
            this.Text = "MouseController";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer playbackTimer;
		private System.Windows.Forms.SaveFileDialog saveMECDialog;
		private System.Windows.Forms.OpenFileDialog openMECDialog;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.CheckBox cbRepeat;
		private System.Windows.Forms.TextBox txtRepeat;
		private System.Windows.Forms.Timer repeatTimer;
		private System.Windows.Forms.ComboBox cmbRepeat;
		private System.Windows.Forms.ComboBox cmbDelay;
		private System.Windows.Forms.TextBox txtDelay;
		private System.Windows.Forms.CheckBox cbDelay;
		private System.Windows.Forms.Timer delayTimer;
		private System.Windows.Forms.ComboBox cmbStartStopPlayback;
		private System.Windows.Forms.ComboBox cmbStartStopRecording;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblRecord;
		private System.Windows.Forms.Label lblPlayback;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.Button btnStartStopPlayback;
		private System.Windows.Forms.ToolStripMenuItem cursorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showClickNumberToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem timeStretchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x05ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x09ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x11toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xCustomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addRandomDelayToRepeatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitAfterPlaybackCompletedToolStripMenuItem;
		private System.Windows.Forms.CheckBox cbRepeats;
		private System.Windows.Forms.TextBox txtRepeats;
		private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgWorkerCheckVersion;
    }
}

