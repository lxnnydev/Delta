using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;

namespace Delta
{
	// Token: 0x02000003 RID: 3
	internal class DLLPipe
	{
		// Token: 0x06000002 RID: 2
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool WaitNamedPipe(string pipe, int timeout = 10);

		// Token: 0x06000003 RID: 3 RVA: 0x00002058 File Offset: 0x00000258
		public static bool NamedPipeExist()
		{
			return DLLPipe.WaitNamedPipe("\\\\.\\pipe\\" + DLLPipe.luapipename, 10);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002C90 File Offset: 0x00000E90
		public static void LuaPipe(string script)
		{
			if (DLLPipe.NamedPipeExist())
			{
				new Thread(delegate()
				{
					try
					{
						using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", DLLPipe.luapipename, PipeDirection.Out))
						{
							namedPipeClientStream.Connect();
							using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, Encoding.Default, 999999))
							{
								streamWriter.Write(script);
								streamWriter.Dispose();
							}
							namedPipeClientStream.Dispose();
						}
					}
					catch (IOException)
					{
						MessageBox.Show("Can't Connect to Pipe, Connection Errot (Restart PC Or Kill Roblox)", "Delta");
					}
					catch (Exception)
					{
						MessageBox.Show("Unknown error", "Delta");
					}
				}).Start();
				return;
			}
			MessageBox.Show("Inject Before Executing", "Delta");
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002050 File Offset: 0x00000250
		public DLLPipe()
		{
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002070 File Offset: 0x00000270
		// Note: this type is marked as 'beforefieldinit'.
		static DLLPipe()
		{
		}

		// Token: 0x04000001 RID: 1
		public static string luapipename = "DeltaWins";

		// Token: 0x02000004 RID: 4
		[CompilerGenerated]
		private sealed class <>c__DisplayClass3_0
		{
			// Token: 0x06000007 RID: 7 RVA: 0x00002050 File Offset: 0x00000250
			public <>c__DisplayClass3_0()
			{
			}

			// Token: 0x06000008 RID: 8 RVA: 0x00002CD8 File Offset: 0x00000ED8
			internal void <LuaPipe>b__0()
			{
				try
				{
					using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", DLLPipe.luapipename, PipeDirection.Out))
					{
						namedPipeClientStream.Connect();
						using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, Encoding.Default, 999999))
						{
							streamWriter.Write(this.script);
							streamWriter.Dispose();
						}
						namedPipeClientStream.Dispose();
					}
				}
				catch (IOException)
				{
					MessageBox.Show("Can't Connect to Pipe, Connection Errot (Restart PC Or Kill Roblox)", "Delta");
				}
				catch (Exception)
				{
					MessageBox.Show("Unknown error", "Delta");
				}
			}

			// Token: 0x04000002 RID: 2
			public string script;
		}
	}
}
