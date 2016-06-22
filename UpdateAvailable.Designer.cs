namespace MouseController
{
	partial class UpdateAvailable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAvailable));
            this.label = new System.Windows.Forms.Label();
            this.DownloadLink = new System.Windows.Forms.LinkLabel();
            this.btnThanks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(114, 13);
            this.label.TabIndex = 0;
            this.label.Text = "New version available:";
            // 
            // DownloadLink
            // 
            this.DownloadLink.AutoSize = true;
            this.DownloadLink.Location = new System.Drawing.Point(12, 40);
            this.DownloadLink.Name = "DownloadLink";
            this.DownloadLink.Size = new System.Drawing.Size(81, 13);
            this.DownloadLink.TabIndex = 1;
            this.DownloadLink.TabStop = true;
            this.DownloadLink.Tag = "https://sourceforge.net/projects/mousecontroller/files/";
            this.DownloadLink.Text = "Download now!";
            this.DownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DownloadLink_Clicked);
            // 
            // btnThanks
            // 
            this.btnThanks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanks.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnThanks.Location = new System.Drawing.Point(264, 38);
            this.btnThanks.Name = "btnThanks";
            this.btnThanks.Size = new System.Drawing.Size(75, 23);
            this.btnThanks.TabIndex = 2;
            this.btnThanks.Text = "Thanks";
            this.btnThanks.UseVisualStyleBackColor = true;
            // 
            // UpdateAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 73);
            this.Controls.Add(this.btnThanks);
            this.Controls.Add(this.DownloadLink);
            this.Controls.Add(this.label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateAvailable";
            this.Text = "Update available";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label;
		private System.Windows.Forms.LinkLabel DownloadLink;
		private System.Windows.Forms.Button btnThanks;
	}
}