using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace YTBootstrapper
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020B8 File Offset: 0x000002B8
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[Program.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002104 File Offset: 0x00000304
		public static bool IsVC2015Installed()
		{
			string text = "SOFTWARE\\Classes\\Installer\\Dependencies";
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(text))
			{
				bool flag = registryKey == null;
				if (flag)
				{
					return false;
				}
				foreach (string str in from n in registryKey.GetSubKeyNames()
				where !n.ToLower().Contains("dotnet") && !n.ToLower().Contains("microsoft")
				select n)
				{
					using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey(text + "\\" + str))
					{
						object value = registryKey2.GetValue("DisplayName");
						string text2 = ((value != null) ? value.ToString() : null) ?? null;
						bool flag2 = string.IsNullOrEmpty(text2);
						if (!flag2)
						{
							bool flag3 = Regex.IsMatch(text2, "C\\+\\+ 2015.*\\((x64|x86)\\)") && Regex.IsMatch(text2, "C\\+\\+ 2015.*\\(x86\\)");
							if (flag3)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002250 File Offset: 0x00000450
		[DebuggerStepThrough]
		private static Task Main(string[] args)
		{
			Program.<Main>d__3 <Main>d__ = new Program.<Main>d__3();
			<Main>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Main>d__.args = args;
			<Main>d__.<>1__state = -1;
			<Main>d__.<>t__builder.Start<Program.<Main>d__3>(ref <Main>d__);
			return <Main>d__.<>t__builder.Task;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002050 File Offset: 0x00000250
		public Program()
		{
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002059 File Offset: 0x00000259
		// Note: this type is marked as 'beforefieldinit'.
		static Program()
		{
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002294 File Offset: 0x00000494
		[DebuggerStepThrough]
		private static void <Main>(string[] args)
		{
			Program.Main(args).GetAwaiter().GetResult();
		}

		// Token: 0x04000001 RID: 1
		private static Random random = new Random();

		// Token: 0x02000003 RID: 3
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x06000007 RID: 7 RVA: 0x00002065 File Offset: 0x00000265
			// Note: this type is marked as 'beforefieldinit'.
			static <>c()
			{
			}

			// Token: 0x06000008 RID: 8 RVA: 0x00002050 File Offset: 0x00000250
			public <>c()
			{
			}

			// Token: 0x06000009 RID: 9 RVA: 0x00002071 File Offset: 0x00000271
			internal char <RandomString>b__1_0(string s)
			{
				return s[Program.random.Next(s.Length)];
			}

			// Token: 0x0600000A RID: 10 RVA: 0x00002089 File Offset: 0x00000289
			internal bool <IsVC2015Installed>b__2_0(string n)
			{
				return !n.ToLower().Contains("dotnet") && !n.ToLower().Contains("microsoft");
			}

			// Token: 0x04000002 RID: 2
			public static readonly Program.<>c <>9 = new Program.<>c();

			// Token: 0x04000003 RID: 3
			public static Func<string, char> <>9__1_0;

			// Token: 0x04000004 RID: 4
			public static Func<string, bool> <>9__2_0;
		}

		// Token: 0x02000004 RID: 4
		[CompilerGenerated]
		private sealed class <Main>d__3 : IAsyncStateMachine
		{
			// Token: 0x0600000B RID: 11 RVA: 0x00002050 File Offset: 0x00000250
			public <Main>d__3()
			{
			}

			// Token: 0x0600000C RID: 12 RVA: 0x000022B4 File Offset: 0x000004B4
			void IAsyncStateMachine.MoveNext()
			{
				int num = this.<>1__state;
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter6;
					TaskAwaiter awaiter7;
					TaskAwaiter awaiter8;
					TaskAwaiter awaiter9;
					TaskAwaiter awaiter10;
					TaskAwaiter awaiter11;
					TaskAwaiter awaiter12;
					switch (num)
					{
					case 0:
						awaiter = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						break;
					case 1:
						awaiter2 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_28B;
					case 2:
						awaiter3 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_314;
					case 3:
						goto IL_394;
					case 4:
						awaiter4 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_4FB;
					case 5:
						awaiter5 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_7F9;
					case 6:
						awaiter6 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_88E;
					case 7:
						awaiter7 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_917;
					case 8:
						awaiter8 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_BD9;
					case 9:
						awaiter9 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_C97;
					case 10:
						awaiter10 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_D2D;
					case 11:
						awaiter11 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_DB7;
					case 12:
						goto IL_E72;
					case 13:
						awaiter12 = this.<>u__1;
						this.<>u__1 = default(TaskAwaiter);
						num = (this.<>1__state = -1);
						goto IL_FBC;
					default:
					{
						this.<exploitname>5__1 = "Delta";
						Console.Title = this.<exploitname>5__1 + " Installer";
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Delta Installer/Updater\n");
						this.<deltaspath>5__3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Program.RandomString(17));
						this.<wc>5__4 = new WebClient();
						this.<version>5__5 = this.<wc>5__4.DownloadString("https://gitlab.com/littlekiller2927/deltacore/-/raw/main/deltadownload");
						this.<deltacore>5__6 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "delta_core");
						Directory.CreateDirectory(this.<deltacore>5__6);
						bool flag = !Directory.Exists(Environment.CurrentDirectory + "/" + this.<exploitname>5__1);
						if (flag)
						{
							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("[INFO]: Downloading " + this.<exploitname>5__1 + ".zip");
							this.<wc>5__4.DownloadFile(this.<wc>5__4.DownloadString("https://gitlab.com/littlekiller2927/deltacore/-/raw/main/deltadownload"), Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip");
							awaiter = Task.Delay(100).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (this.<>1__state = 0);
								this.<>u__1 = awaiter;
								Program.<Main>d__3 <Main>d__ = this;
								this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter, ref <Main>d__);
								return;
							}
						}
						else
						{
							bool flag2 = !File.Exists(Path.Combine(this.<deltacore>5__6, "bootstrapperdownloadvers"));
							if (flag2)
							{
								this.<dir>5__10 = new DirectoryInfo(Environment.CurrentDirectory + "/" + this.<exploitname>5__1);
								Console.WriteLine("[INFO]: Old Version Found");
								this.<>s__11 = this.<dir>5__10.GetFiles();
								this.<>s__12 = 0;
								while (this.<>s__12 < this.<>s__11.Length)
								{
									this.<fl>5__13 = this.<>s__11[this.<>s__12];
									try
									{
										this.<fl>5__13.Delete();
									}
									catch
									{
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("[ERROR]: An error happened while trying to reinstall");
									}
									this.<fl>5__13 = null;
									this.<>s__12++;
								}
								this.<>s__11 = null;
								this.<>s__14 = this.<dir>5__10.GetFiles();
								this.<>s__15 = 0;
								while (this.<>s__15 < this.<>s__14.Length)
								{
									this.<file>5__16 = this.<>s__14[this.<>s__15];
									this.<file>5__16.Delete();
									this.<file>5__16 = null;
									this.<>s__15++;
								}
								this.<>s__14 = null;
								this.<>s__17 = this.<dir>5__10.GetDirectories();
								this.<>s__18 = 0;
								while (this.<>s__18 < this.<>s__17.Length)
								{
									this.<subDirectory>5__19 = this.<>s__17[this.<>s__18];
									this.<subDirectory>5__19.Delete(true);
									this.<subDirectory>5__19 = null;
									this.<>s__18++;
								}
								this.<>s__17 = null;
								Directory.Delete(Environment.CurrentDirectory + "/" + this.<exploitname>5__1);
								Console.ForegroundColor = ConsoleColor.Cyan;
								Console.WriteLine("[INFO]: Downloading " + this.<exploitname>5__1 + ".zip");
								this.<wc>5__4.DownloadFile(this.<wc>5__4.DownloadString("https://gitlab.com/littlekiller2927/deltacore/-/raw/main/deltadownload"), Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip");
								awaiter5 = Task.Delay(100).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (this.<>1__state = 5);
									this.<>u__1 = awaiter5;
									Program.<Main>d__3 <Main>d__ = this;
									this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter5, ref <Main>d__);
									return;
								}
								goto IL_7F9;
							}
							else
							{
								this.<installedvers>5__20 = File.ReadAllText(Path.Combine(this.<deltacore>5__6, "bootstrapperdownloadvers"));
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("[INFO]: Delta is already Downloaded");
								Console.WriteLine("[INFO]: Checking Version");
								Console.ForegroundColor = ConsoleColor.Cyan;
								bool flag3 = this.<installedvers>5__20 != this.<version>5__5;
								if (!flag3)
								{
									goto IL_E21;
								}
								this.<dir>5__21 = new DirectoryInfo(Environment.CurrentDirectory + "/" + this.<exploitname>5__1);
								Console.WriteLine("[INFO]: Old Version Found");
								this.<>s__22 = this.<dir>5__21.GetFiles();
								this.<>s__23 = 0;
								while (this.<>s__23 < this.<>s__22.Length)
								{
									this.<fl>5__24 = this.<>s__22[this.<>s__23];
									try
									{
										this.<fl>5__24.Delete();
									}
									catch
									{
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("[ERROR]: An error happened while trying to reinstall");
									}
									this.<fl>5__24 = null;
									this.<>s__23++;
								}
								this.<>s__22 = null;
								this.<>s__25 = this.<dir>5__21.GetFiles();
								this.<>s__26 = 0;
								while (this.<>s__26 < this.<>s__25.Length)
								{
									this.<file>5__27 = this.<>s__25[this.<>s__26];
									this.<file>5__27.Delete();
									this.<file>5__27 = null;
									this.<>s__26++;
								}
								this.<>s__25 = null;
								this.<>s__28 = this.<dir>5__21.GetDirectories();
								this.<>s__29 = 0;
								while (this.<>s__29 < this.<>s__28.Length)
								{
									this.<subDirectory>5__30 = this.<>s__28[this.<>s__29];
									this.<subDirectory>5__30.Delete(true);
									this.<subDirectory>5__30 = null;
									this.<>s__29++;
								}
								this.<>s__28 = null;
								Directory.Delete(Environment.CurrentDirectory + "/" + this.<exploitname>5__1);
								awaiter8 = Task.Delay(750).GetAwaiter();
								if (!awaiter8.IsCompleted)
								{
									num = (this.<>1__state = 8);
									this.<>u__1 = awaiter8;
									Program.<Main>d__3 <Main>d__ = this;
									this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter8, ref <Main>d__);
									return;
								}
								goto IL_BD9;
							}
						}
						break;
					}
					}
					awaiter.GetResult();
					Console.WriteLine("[INFO]: Successfully Downloaded " + this.<exploitname>5__1 + ".zip");
					Console.WriteLine("[INFO]: Extracting & Installing " + this.<exploitname>5__1);
					awaiter2 = Task.Delay(100).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (this.<>1__state = 1);
						this.<>u__1 = awaiter2;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter2, ref <Main>d__);
						return;
					}
					IL_28B:
					awaiter2.GetResult();
					ZipFile.ExtractToDirectory(Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip", Environment.CurrentDirectory);
					awaiter3 = Task.Delay(100).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (this.<>1__state = 2);
						this.<>u__1 = awaiter3;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter3, ref <Main>d__);
						return;
					}
					IL_314:
					awaiter3.GetResult();
					Console.WriteLine("[INFO]: Successfully installed " + this.<exploitname>5__1);
					Console.ForegroundColor = ConsoleColor.White;
					File.WriteAllText(Path.Combine(this.<deltacore>5__6, "bootstrapperdownloadvers"), this.<version>5__5);
					Console.WriteLine("[INFO]: Checking Dependencies");
					bool flag4 = !Program.IsVC2015Installed();
					if (!flag4)
					{
						Console.WriteLine("[INFO]: Dependencies already installed");
						goto IL_466;
					}
					Console.WriteLine("[INFO]: Dependencies are not installed\n[INFO]: Installing Dependencies");
					Console.WriteLine("[INFO]: Press \"Start Fix\" on the new Window");
					this.<wbc>5__8 = new WebClient();
					IL_394:
					try
					{
						TaskAwaiter awaiter13;
						if (num != 3)
						{
							this.<wbc>5__8.DownloadFile("https://github.com/lxnnydev/DeltaHosting/raw/main/Rbx_Error_Fix.exe", ".\\Rbx_Error_Fix.exe");
							Process.Start(".\\Rbx_Error_Fix.exe").WaitForExit();
							awaiter13 = Task.Delay(100).GetAwaiter();
							if (!awaiter13.IsCompleted)
							{
								num = (this.<>1__state = 3);
								this.<>u__1 = awaiter13;
								Program.<Main>d__3 <Main>d__ = this;
								this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter13, ref <Main>d__);
								return;
							}
						}
						else
						{
							awaiter13 = this.<>u__1;
							this.<>u__1 = default(TaskAwaiter);
							num = (this.<>1__state = -1);
						}
						awaiter13.GetResult();
						File.Delete(".\\Rbx_Error_Fix.exe");
					}
					finally
					{
						if (num < 0 && this.<wbc>5__8 != null)
						{
							((IDisposable)this.<wbc>5__8).Dispose();
						}
					}
					this.<wbc>5__8 = null;
					IL_466:
					Console.WriteLine("[INFO]: Starting " + this.<exploitname>5__1);
					File.Delete(Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip");
					awaiter4 = Task.Delay(1000).GetAwaiter();
					if (!awaiter4.IsCompleted)
					{
						num = (this.<>1__state = 4);
						this.<>u__1 = awaiter4;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter4, ref <Main>d__);
						return;
					}
					IL_4FB:
					awaiter4.GetResult();
					this.<proc>5__7 = new Process();
					this.<proc>5__7.StartInfo.UseShellExecute = false;
					this.<proc>5__7.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "/" + this.<exploitname>5__1;
					this.<proc>5__7.StartInfo.FileName = Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + "/Delta.exe";
					this.<proc>5__7.Start();
					this.<proc>5__7 = null;
					goto IL_1046;
					IL_7F9:
					awaiter5.GetResult();
					Console.WriteLine("[INFO]: Successfully Downloaded " + this.<exploitname>5__1 + ".zip");
					Console.WriteLine("[INFO]: Extracting & Installing " + this.<exploitname>5__1);
					awaiter6 = Task.Delay(100).GetAwaiter();
					if (!awaiter6.IsCompleted)
					{
						num = (this.<>1__state = 6);
						this.<>u__1 = awaiter6;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter6, ref <Main>d__);
						return;
					}
					IL_88E:
					awaiter6.GetResult();
					ZipFile.ExtractToDirectory(Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip", Environment.CurrentDirectory);
					awaiter7 = Task.Delay(100).GetAwaiter();
					if (!awaiter7.IsCompleted)
					{
						num = (this.<>1__state = 7);
						this.<>u__1 = awaiter7;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter7, ref <Main>d__);
						return;
					}
					IL_917:
					awaiter7.GetResult();
					Console.WriteLine("[INFO]: Successfully installed " + this.<exploitname>5__1);
					Console.ForegroundColor = ConsoleColor.White;
					File.WriteAllText(Path.Combine(this.<deltacore>5__6, "bootstrapperdownloadvers"), this.<version>5__5);
					File.Delete(Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip");
					this.<dir>5__10 = null;
					goto IL_E29;
					IL_BD9:
					awaiter8.GetResult();
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("[INFO]: Downloading " + this.<exploitname>5__1 + ".zip");
					this.<wc>5__4.DownloadFile(this.<wc>5__4.DownloadString("https://gitlab.com/littlekiller2927/deltacore/-/raw/main/deltadownload"), Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip");
					awaiter9 = Task.Delay(100).GetAwaiter();
					if (!awaiter9.IsCompleted)
					{
						num = (this.<>1__state = 9);
						this.<>u__1 = awaiter9;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter9, ref <Main>d__);
						return;
					}
					IL_C97:
					awaiter9.GetResult();
					Console.WriteLine("[INFO]: Successfully Downloaded " + this.<exploitname>5__1 + ".zip");
					Console.WriteLine("[INFO]: Extracting & Installing " + this.<exploitname>5__1);
					awaiter10 = Task.Delay(100).GetAwaiter();
					if (!awaiter10.IsCompleted)
					{
						num = (this.<>1__state = 10);
						this.<>u__1 = awaiter10;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter10, ref <Main>d__);
						return;
					}
					IL_D2D:
					awaiter10.GetResult();
					ZipFile.ExtractToDirectory(Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip", Environment.CurrentDirectory);
					awaiter11 = Task.Delay(100).GetAwaiter();
					if (!awaiter11.IsCompleted)
					{
						num = (this.<>1__state = 11);
						this.<>u__1 = awaiter11;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter11, ref <Main>d__);
						return;
					}
					IL_DB7:
					awaiter11.GetResult();
					Console.WriteLine("[INFO]: Successfully installed " + this.<exploitname>5__1);
					Console.ForegroundColor = ConsoleColor.White;
					File.WriteAllText(Path.Combine(this.<deltacore>5__6, "bootstrapperdownloadvers"), this.<version>5__5);
					File.Delete(Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + ".zip");
					this.<dir>5__21 = null;
					IL_E21:
					this.<installedvers>5__20 = null;
					IL_E29:
					Console.WriteLine("[INFO]: Newest Version already installed");
					Console.WriteLine("[INFO]: Checking Dependencies");
					bool flag5 = !Program.IsVC2015Installed();
					if (!flag5)
					{
						Console.WriteLine("[INFO]: Dependencies already installed");
						goto IL_F46;
					}
					Console.WriteLine("[INFO]: Dependencies are not installed\n[INFO]: Installing Dependencies");
					Console.WriteLine("[INFO]: Press \"Start Fix\" on the new Window");
					this.<wbc>5__31 = new WebClient();
					IL_E72:
					try
					{
						TaskAwaiter awaiter14;
						if (num != 12)
						{
							this.<wbc>5__31.DownloadFile("https://github.com/lxnnydev/DeltaHosting/raw/main/Rbx_Error_Fix.exe", ".\\Rbx_Error_Fix.exe");
							Process.Start(".\\Rbx_Error_Fix.exe").WaitForExit();
							awaiter14 = Task.Delay(100).GetAwaiter();
							if (!awaiter14.IsCompleted)
							{
								num = (this.<>1__state = 12);
								this.<>u__1 = awaiter14;
								Program.<Main>d__3 <Main>d__ = this;
								this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter14, ref <Main>d__);
								return;
							}
						}
						else
						{
							awaiter14 = this.<>u__1;
							this.<>u__1 = default(TaskAwaiter);
							num = (this.<>1__state = -1);
						}
						awaiter14.GetResult();
						File.Delete(".\\Rbx_Error_Fix.exe");
					}
					finally
					{
						if (num < 0 && this.<wbc>5__31 != null)
						{
							((IDisposable)this.<wbc>5__31).Dispose();
						}
					}
					this.<wbc>5__31 = null;
					IL_F46:
					Console.WriteLine("[INFO]: Starting " + this.<exploitname>5__1);
					awaiter12 = Task.Delay(1000).GetAwaiter();
					if (!awaiter12.IsCompleted)
					{
						num = (this.<>1__state = 13);
						this.<>u__1 = awaiter12;
						Program.<Main>d__3 <Main>d__ = this;
						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.<Main>d__3>(ref awaiter12, ref <Main>d__);
						return;
					}
					IL_FBC:
					awaiter12.GetResult();
					this.<proc>5__9 = new Process();
					this.<proc>5__9.StartInfo.UseShellExecute = false;
					this.<proc>5__9.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "/" + this.<exploitname>5__1;
					this.<proc>5__9.StartInfo.FileName = Environment.CurrentDirectory + "/" + this.<exploitname>5__1 + "/Delta.exe";
					this.<proc>5__9.Start();
					this.<proc>5__9 = null;
					IL_1046:;
				}
				catch (Exception exception)
				{
					this.<>1__state = -2;
					this.<exploitname>5__1 = null;
					this.<fullpath>5__2 = null;
					this.<deltaspath>5__3 = null;
					this.<wc>5__4 = null;
					this.<version>5__5 = null;
					this.<deltacore>5__6 = null;
					this.<>t__builder.SetException(exception);
					return;
				}
				this.<>1__state = -2;
				this.<exploitname>5__1 = null;
				this.<fullpath>5__2 = null;
				this.<deltaspath>5__3 = null;
				this.<wc>5__4 = null;
				this.<version>5__5 = null;
				this.<deltacore>5__6 = null;
				this.<>t__builder.SetResult();
			}

			// Token: 0x0600000D RID: 13 RVA: 0x000020B3 File Offset: 0x000002B3
			[DebuggerHidden]
			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			// Token: 0x04000005 RID: 5
			public int <>1__state;

			// Token: 0x04000006 RID: 6
			public AsyncTaskMethodBuilder <>t__builder;

			// Token: 0x04000007 RID: 7
			public string[] args;

			// Token: 0x04000008 RID: 8
			private string <exploitname>5__1;

			// Token: 0x04000009 RID: 9
			private string <fullpath>5__2;

			// Token: 0x0400000A RID: 10
			private string <deltaspath>5__3;

			// Token: 0x0400000B RID: 11
			private WebClient <wc>5__4;

			// Token: 0x0400000C RID: 12
			private string <version>5__5;

			// Token: 0x0400000D RID: 13
			private string <deltacore>5__6;

			// Token: 0x0400000E RID: 14
			private Process <proc>5__7;

			// Token: 0x0400000F RID: 15
			private WebClient <wbc>5__8;

			// Token: 0x04000010 RID: 16
			private Process <proc>5__9;

			// Token: 0x04000011 RID: 17
			private DirectoryInfo <dir>5__10;

			// Token: 0x04000012 RID: 18
			private FileInfo[] <>s__11;

			// Token: 0x04000013 RID: 19
			private int <>s__12;

			// Token: 0x04000014 RID: 20
			private FileInfo <fl>5__13;

			// Token: 0x04000015 RID: 21
			private FileInfo[] <>s__14;

			// Token: 0x04000016 RID: 22
			private int <>s__15;

			// Token: 0x04000017 RID: 23
			private FileInfo <file>5__16;

			// Token: 0x04000018 RID: 24
			private DirectoryInfo[] <>s__17;

			// Token: 0x04000019 RID: 25
			private int <>s__18;

			// Token: 0x0400001A RID: 26
			private DirectoryInfo <subDirectory>5__19;

			// Token: 0x0400001B RID: 27
			private string <installedvers>5__20;

			// Token: 0x0400001C RID: 28
			private DirectoryInfo <dir>5__21;

			// Token: 0x0400001D RID: 29
			private FileInfo[] <>s__22;

			// Token: 0x0400001E RID: 30
			private int <>s__23;

			// Token: 0x0400001F RID: 31
			private FileInfo <fl>5__24;

			// Token: 0x04000020 RID: 32
			private FileInfo[] <>s__25;

			// Token: 0x04000021 RID: 33
			private int <>s__26;

			// Token: 0x04000022 RID: 34
			private FileInfo <file>5__27;

			// Token: 0x04000023 RID: 35
			private DirectoryInfo[] <>s__28;

			// Token: 0x04000024 RID: 36
			private int <>s__29;

			// Token: 0x04000025 RID: 37
			private DirectoryInfo <subDirectory>5__30;

			// Token: 0x04000026 RID: 38
			private WebClient <wbc>5__31;

			// Token: 0x04000027 RID: 39
			private TaskAwaiter <>u__1;
		}
	}
}
