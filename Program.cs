using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MouseController
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				Properties.Settings.Default.Upgrade();
			}
			catch
			{
				// Could not update settings, no biggie
			}

			Options opts = new Options(args);
			if (opts.ParseError != "")
				MessageBox.Show(opts.ParseError, "Error parsing options", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else if (opts.ShowHelp)
				MessageBox.Show(opts.Help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				Application.Run(new MainForm(opts));
		}
	}
}
