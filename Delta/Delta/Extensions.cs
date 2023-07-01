using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Delta
{
	// Token: 0x02000005 RID: 5
	internal static class Extensions
	{
		// Token: 0x06000009 RID: 9
		[DllImport("Kernel32.dll")]
		private static extern bool QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] StringBuilder lpExeName, [In] [Out] ref uint lpdwSize);

		// Token: 0x0600000A RID: 10 RVA: 0x00002D9C File Offset: 0x00000F9C
		public static string GetMainModuleFileName(this Process process, int buffer = 1024)
		{
			StringBuilder stringBuilder = new StringBuilder(buffer);
			uint num = (uint)(stringBuilder.Capacity + 1);
			if (!Extensions.QueryFullProcessImageName(process.Handle, 0U, stringBuilder, ref num))
			{
				return null;
			}
			return stringBuilder.ToString();
		}
	}
}
