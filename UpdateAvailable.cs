using System.Windows.Forms;

namespace MouseController
{
	public partial class UpdateAvailable : Form
	{
		public System.Version Version
		{
			set
			{
				label.Text = @"A new version (" + value.ToString() +
				@") of MouseController is available for download:";
			}
		}
		public UpdateAvailable()
		{
			InitializeComponent();
		}

		private void DownloadLink_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(DownloadLink.Tag.ToString());
		}
	}
}
