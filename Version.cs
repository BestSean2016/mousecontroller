using System.IO;
using System.Net;

namespace MouseController
{
	internal static class ChkVersion
	{
		private const string UPDATE_URI = @"https://sourceforge.net/p/mousecontroller/code/HEAD/tree/trunk/MouseController.ver?format=raw";

        public static System.Version Version { get; private set; }
		public static System.Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

		public static void Check()
		{
			try
			{
				// Get HTML data 
				var client = new WebClient();
				Stream data = client.OpenRead(UPDATE_URI);
				var reader = new StreamReader(data);
				string str = reader.ReadToEnd();
				if (str != null)
				{
					Version = new System.Version(str);
				}
				data.Close();
				if (curVersion.CompareTo(Version) < 0)
					Popup();
			}
			catch
			{
                // Could not fetch online version
            }
        }

		private static void Popup()
		{
			UpdateAvailable UA = new UpdateAvailable();
			UA.Version = Version;
			UA.ShowDialog();
		}
	}
}
