using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouseController
{
	public partial class TimeStretchDialog : Form
	{
		public TimeStretchDialog(double timeStretch)
		{
			InitializeComponent();
			txtTimeStretch.Text = timeStretch.ToString("F1");
		}

		public double TimeStretch {get; private set;}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				TimeStretch = Convert.ToDouble(txtTimeStretch.Text);
				DialogResult = DialogResult.OK;
			}
			catch { }
		}

		private void txtTimeStretch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnOk_Click(sender, e);
		}
	}
}
