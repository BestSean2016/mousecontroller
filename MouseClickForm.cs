using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MouseController
{
	class MouseClickForm : Form
	{
		private string _tag;
		private Timer _closeTimer;
		private Point _location;
		private Font _font;

		public MouseClickForm(int x, int y, string tag)
		{
			_tag = tag;
			_location = new Point(x, y);
			_font = new Font("Comic Sans MS", 9);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			ClientSize = new Size(9, 18);
			BackColor = Color.Transparent;
			FormBorderStyle = FormBorderStyle.None;
			TopMost = true;
			ShowInTaskbar = false;
			
			Paint += new PaintEventHandler(MouseClickForm_Paint);
			_closeTimer = new Timer();
			_closeTimer.Interval = 1000;
			_closeTimer.Tick += new EventHandler(_closeTimer_Tick);
			_closeTimer.Start();

			Show();
		}

		void _closeTimer_Tick(object sender, EventArgs e)
		{
			_closeTimer.Stop();
			Close();
			Dispose();
		}

		private void MouseClickForm_Paint(object sender, PaintEventArgs e)
		{
			Size size = e.Graphics.MeasureString(_tag, _font).ToSize();
			Size = size;
			Location = _location - size;
			e.Graphics.DrawString(_tag, _font, new SolidBrush(Color.Black), 0, 0);
			BackColor = Color.LightGray;
		}

	}
}
