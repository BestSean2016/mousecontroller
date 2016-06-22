using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MouseController
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			aboutTitleLabel.Text = Application.ProductName + " v" + Application.ProductVersion;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Options opts = new Options(null);
			MessageBox.Show(opts.Help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
