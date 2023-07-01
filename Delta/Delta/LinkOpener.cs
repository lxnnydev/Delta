using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Media.Imaging;

namespace Delta
{
	// Token: 0x02000009 RID: 9
	public static class LinkOpener
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00003084 File Offset: 0x00001284
		public static void openlink(string link)
		{
			try
			{
				Process.Start(new ProcessStartInfo(link)
				{
					UseShellExecute = true,
					Verb = "open"
				});
			}
			catch (Win32Exception)
			{
				Process.Start("IExplore.exe", link);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000020FA File Offset: 0x000002FA
		public static BitmapImage urltoimage(string url)
		{
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.UriSource = new Uri(url, UriKind.Absolute);
			bitmapImage.DecodePixelWidth = 150;
			bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
			bitmapImage.EndInit();
			return bitmapImage;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000030D0 File Offset: 0x000012D0
		public static string DownloadStr(string Link)
		{
			string result;
			using (WebClient webClient = new WebClient
			{
				Proxy = null
			})
			{
				result = webClient.DownloadString(Link);
			}
			return result;
		}
	}
}
