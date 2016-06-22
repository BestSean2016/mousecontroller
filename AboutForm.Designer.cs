namespace MouseController
{
	partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.aboutTitleLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.linkAbout = new System.Windows.Forms.LinkLabel();
			this.btnClose = new System.Windows.Forms.Button();
			this.llCmdOpts = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::MouseController.Properties.Resources.MuGiRi_Dreieck_Metall_klein;
			this.pictureBox1.Location = new System.Drawing.Point(4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(122, 106);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// aboutTitleLabel
			// 
			this.aboutTitleLabel.AutoSize = true;
			this.aboutTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.aboutTitleLabel.Location = new System.Drawing.Point(124, 9);
			this.aboutTitleLabel.Name = "aboutTitleLabel";
			this.aboutTitleLabel.Size = new System.Drawing.Size(111, 17);
			this.aboutTitleLabel.TabIndex = 1;
			this.aboutTitleLabel.Text = "MouseController";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(124, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Brought to you by";
			// 
			// linkAbout
			// 
			this.linkAbout.AutoSize = true;
			this.linkAbout.Location = new System.Drawing.Point(124, 44);
			this.linkAbout.Name = "linkAbout";
			this.linkAbout.Size = new System.Drawing.Size(153, 13);
			this.linkAbout.TabIndex = 4;
			this.linkAbout.TabStop = true;
			this.linkAbout.Text = "MuGiRi Software Development";
			this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(207, 84);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// llCmdOpts
			// 
			this.llCmdOpts.AutoSize = true;
			this.llCmdOpts.Location = new System.Drawing.Point(124, 63);
			this.llCmdOpts.Name = "llCmdOpts";
			this.llCmdOpts.Size = new System.Drawing.Size(147, 13);
			this.llCmdOpts.TabIndex = 4;
			this.llCmdOpts.TabStop = true;
			this.llCmdOpts.Text = "Explore command line options";
			this.llCmdOpts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 112);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.llCmdOpts);
			this.Controls.Add(this.linkAbout);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.aboutTitleLabel);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(310, 150);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(310, 150);
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label aboutTitleLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkAbout;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.LinkLabel llCmdOpts;
	}
}