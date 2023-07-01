using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using WeAreDevs_API;

namespace Delta.Classes
{
	// Token: 0x0200002B RID: 43
	public class Module
	{
		// Token: 0x06000137 RID: 311
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool WaitNamedPipe(string pipe, int timeout = 10);

		// Token: 0x06000138 RID: 312 RVA: 0x0000B9A4 File Offset: 0x00009BA4
		public Module()
		{
			this.SwitchAPI(Module.API.DELTA);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00002B8B File Offset: 0x00000D8B
		public bool IsAttached()
		{
			return Module.WaitNamedPipe(this.Pipe, 10);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00002B9A File Offset: 0x00000D9A
		public bool IsRobloxRunning()
		{
			return Process.GetProcessesByName("RobloxPlayerBeta").Length != 0;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00002BAA File Offset: 0x00000DAA
		public bool DLLExists()
		{
			if (this.Pipe.Contains("Delta"))
			{
				return File.Exists(this.fullpath);
			}
			return File.Exists(this.DLLPath);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000BA54 File Offset: 0x00009C54
		public void SwitchAPI(Module.API _API)
		{
			Module.<SwitchAPI>d__16 <SwitchAPI>d__;
			<SwitchAPI>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<SwitchAPI>d__.<>4__this = this;
			<SwitchAPI>d__._API = _API;
			<SwitchAPI>d__.<>1__state = -1;
			<SwitchAPI>d__.<>t__builder.Start<Module.<SwitchAPI>d__16>(ref <SwitchAPI>d__);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000BA94 File Offset: 0x00009C94
		private string get_roblox_md5(string path)
		{
			string result;
			using (FileStream fileStream = File.OpenRead(path))
			{
				result = BitConverter.ToString(new SHA384Managed().ComputeHash(fileStream)).Replace("-", string.Empty).ToLower();
			}
			return result;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000BAEC File Offset: 0x00009CEC
		private void repair_client(string RobloxPath, bool kill = true)
		{
			ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
			if (kill)
			{
				Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
				for (int i = 0; i < processesByName.Length; i++)
				{
					processesByName[i].Kill();
				}
			}
			MessageBox.Show("You are running an unsupported ROBLOX version. Delta will attempt to install the correct version.\r\n\r\n**DELTA WILL FREEZE WHILE THIS HAPPENS, DO NOT TOUCH IT**\r\n", "Injection Failed", MessageBoxButton.OK, MessageBoxImage.Hand);
			MemoryStream memoryStream = new MemoryStream();
			using (WebClient webClient = new WebClient())
			{
				string text = webClient.DownloadString("https://clientsettingscdn.roblox.com/v2/client-version/WindowsPlayer");
				text = text.Substring(text.IndexOf("version-"));
				text = text.Substring(0, text.IndexOf("\""));
				using (ZipArchive zipArchive = new ZipArchive(new MemoryStream(webClient.DownloadData("http://setup.roblox.com/" + text + "-RobloxApp.zip"))))
				{
					foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
					{
						if (zipArchiveEntry.FullName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) && Path.GetFullPath(Path.Combine(RobloxPath, zipArchiveEntry.FullName)).StartsWith(RobloxPath, StringComparison.Ordinal))
						{
							zipArchiveEntry.Open().CopyTo(memoryStream);
						}
					}
				}
				if (memoryStream.Length == 0L)
				{
					MessageBox.Show("Data Writing Failed!", "Downgrading", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					if (File.Exists(RobloxPath + "\\RobloxPlayerBeta.exe"))
					{
						File.Delete(RobloxPath + "\\RobloxPlayerBeta.exe");
					}
					File.WriteAllBytes(RobloxPath + "\\RobloxPlayerBeta.exe", memoryStream.ToArray());
					MessageBox.Show("Delta has completed installing the correct version. Please reinject!", "Delta", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00002BD5 File Offset: 0x00000DD5
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[Module.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00002C10 File Offset: 0x00000E10
		public void Execute(string Script)
		{
			DLLPipe.luapipename = this.Pipe;
			DLLPipe.LuaPipe(Script);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000BCDC File Offset: 0x00009EDC
		public void openpopup()
		{
			if (!File.Exists("provider.delta"))
			{
				LinkOpener.openlink("https://beforeignunlig.com/redirect?tid=962340");
				return;
			}
			if (new Random().Next(2) != 1)
			{
				LinkOpener.openlink("https://beforeignunlig.com/redirect?tid=962340");
				return;
			}
			string a = File.ReadAllText("provider.delta");
			if (a == "ark")
			{
				LinkOpener.openlink("https://consultantpatientslaughter.com/rn0n075y08?key=c14c65dde19fab7daba7a0fc9c175b09");
				return;
			}
			if (a == "xerus")
			{
				LinkOpener.openlink("https://entlyhaveb.autos/redirect?tid=972018");
				return;
			}
			if (!(a == "ariel"))
			{
				LinkOpener.openlink("https://beforeignunlig.com/redirect?tid=962340");
				return;
			}
			LinkOpener.openlink("https://www.highperformancecpmgate.com/qcet7d2je1?key=677f048e773e773c22d9c6443e48063d");
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000BD78 File Offset: 0x00009F78
		public bool Inject(bool PMI = false, bool AutoExecute = false, bool verscheck = false)
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
			this.openpopup();
			Module.API api = this.selected_api;
			if (api != Module.API.DELTA)
			{
				return api != Module.API.WEAREDEVS || this.wrdAPI.LaunchExploit();
			}
			if (verscheck)
			{
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Roblox");
				string mainModuleFileName = Process.GetProcessesByName("RobloxPlayerBeta")[0].GetMainModuleFileName(1024);
				File.Exists(Path.Combine(Path.GetDirectoryName(mainModuleFileName), "RobloxPlayerBeta.dll"));
			}
			if (this.IsAttached())
			{
				MessageBox.Show("Injection Failed! Already Injected!\n", "Injection");
				return true;
			}
			if (!this.DLLExists())
			{
				MessageBox.Show("Injection Failed! DLL not found! Press OK and wait while we are trying to fix it (ReInject after)\n", "Injection");
				Module.Functions.Download(Module.Functions.DownloadStr("https://raw.githubusercontent.com/lxnnydev/DeltaHosting/main/NEWDLLVERSDIRECTLINK"), this.fullpath);
				File.WriteAllText(Path.Combine(this.deltacore, "deltavers.txt"), Module.Functions.DownloadStr("https://raw.githubusercontent.com/lxnnydev/DeltaHosting/main/NEWDLLVERSDIRECTLINK"));
				return true;
			}
			if (!PMI)
			{
				if (this.Pipe.Contains("Delta"))
				{
					string path = File.ReadAllText(Path.Combine(this.deltacore, "deltapath"));
					switch (this.Inject_Delta.inject(path, true))
					{
					case Injector.Result.DLLNotFound:
					{
						MessageBox.Show("Injection Failed! DLL not found! Press OK and wait while we are trying to fix it (ReInject after)\n", "Injection");
						Module.Functions.Download(Module.Functions.DownloadStr("https://raw.githubusercontent.com/lxnnydev/DeltaHosting/main/NEWDLLVERSDIRECTLINK"), this.fullpath);
						File.WriteAllText(Path.Combine(this.deltacore, "deltavers.txt"), Module.Functions.DownloadStr("https://raw.githubusercontent.com/lxnnydev/DeltaHosting/main/NEWDLLVERSDIRECTLINK"));
						string fullName = new FileInfo(this.deltaspath).Directory.FullName;
						if (!File.Exists(Path.Combine(fullName, "README.txt")))
						{
							File.WriteAllText(Path.Combine(fullName, "README.txt"), "Hey! This DLL file in here is the Delta Module File.\nIts the most important part to make delta work, so please make sure to exclude this path from your anti-virus :)");
						}
						break;
					}
					case Injector.Result.OpenProcFail:
						MessageBox.Show("Injection Failed - OpenProcFail failed!\n", "Injection");
						break;
					case Injector.Result.LoadLibFail:
						MessageBox.Show("Injection Failed - LoadLibFail failed!\n", "Injection");
						break;
					case Injector.Result.RobloxNotOpen:
						MessageBox.Show("Injection Failed - The Browser version of Roblox isnt running!\n", "Injection");
						break;
					case Injector.Result.Unknown:
						MessageBox.Show("Injection Failed - Unknown!\n", "Injection");
						break;
					}
				}
				else
				{
					this.openpopup();
				}
			}
			else
			{
				Process.Start(new ProcessStartInfo("./bin\\PuppyMilkInjector.exe")
				{
					Arguments = this.DLLPath,
					CreateNoWindow = true
				}).WaitForExit();
			}
			return true;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000BFD4 File Offset: 0x0000A1D4
		private void autoexec()
		{
			Module.<autoexec>d__24 <autoexec>d__;
			<autoexec>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<autoexec>d__.<>4__this = this;
			<autoexec>d__.<>1__state = -1;
			<autoexec>d__.<>t__builder.Start<Module.<autoexec>d__24>(ref <autoexec>d__);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00002C23 File Offset: 0x00000E23
		// Note: this type is marked as 'beforefieldinit'.
		static Module()
		{
		}

		// Token: 0x0400018F RID: 399
		private DeltaHWID deltakey = new DeltaHWID();

		// Token: 0x04000190 RID: 400
		private Injector Inject_Delta = new Injector();

		// Token: 0x04000191 RID: 401
		private ExploitAPI wrdAPI = new ExploitAPI();

		// Token: 0x04000192 RID: 402
		private string DLLPath;

		// Token: 0x04000193 RID: 403
		private string Pipe;

		// Token: 0x04000194 RID: 404
		private List<string> APIList = new List<string>
		{
			"DeltaDLL-DeltaPipe",
			"OxygenBytecode-OxygenU",
			"WeAreDevs-WeAreDevsPublicAPI_Lua",
			"EasyExploits-ocybedam",
			"Krnl-krnlpipe"
		};

		// Token: 0x04000195 RID: 405
		private string fullpath;

		// Token: 0x04000196 RID: 406
		private Module.API selected_api;

		// Token: 0x04000197 RID: 407
		private string deltaspath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Module.RandomString(17));

		// Token: 0x04000198 RID: 408
		private string deltacore = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "delta_core");

		// Token: 0x04000199 RID: 409
		private static Random random = new Random();

		// Token: 0x0200002C RID: 44
		public enum API
		{
			// Token: 0x0400019B RID: 411
			DELTA,
			// Token: 0x0400019C RID: 412
			OXYGEN,
			// Token: 0x0400019D RID: 413
			WEAREDEVS,
			// Token: 0x0400019E RID: 414
			EASYEXPLOITS,
			// Token: 0x0400019F RID: 415
			KRNL
		}

		// Token: 0x0200002D RID: 45
		public class Functions
		{
			// Token: 0x06000145 RID: 325 RVA: 0x0000C00C File Offset: 0x0000A20C
			public static bool Download(string Link, string Path)
			{
				using (WebClient webClient = new WebClient
				{
					Proxy = null
				})
				{
					webClient.DownloadFile(Link, Path);
				}
				return File.Exists(Path);
			}

			// Token: 0x06000146 RID: 326 RVA: 0x000030D0 File Offset: 0x000012D0
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

			// Token: 0x06000147 RID: 327 RVA: 0x00002050 File Offset: 0x00000250
			public Functions()
			{
			}
		}

		// Token: 0x0200002E RID: 46
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct <SwitchAPI>d__16 : IAsyncStateMachine
		{
			// Token: 0x06000148 RID: 328 RVA: 0x0000C050 File Offset: 0x0000A250
			void IAsyncStateMachine.MoveNext()
			{
				Module module = this.<>4__this;
				try
				{
					ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
					Directory.CreateDirectory(module.deltacore);
					if (!File.Exists(Path.Combine(module.deltacore, "deltavers.txt")))
					{
						File.Create(Path.Combine(module.deltacore, "deltavers.txt")).Close();
						File.WriteAllText(Path.Combine(module.deltacore, "deltavers.txt"), "update required");
					}
					string a = File.ReadAllText(Path.Combine(module.deltacore, "deltavers.txt"));
					module.DLLPath = Environment.CurrentDirectory + "/DLLs/" + module.APIList[(int)this._API].Split(new char[]
					{
						'-'
					})[0] + ".dll";
					module.Pipe = module.APIList[(int)this._API].Split(new char[]
					{
						'-'
					})[1];
					if (!File.Exists(Path.Combine(module.deltacore, "deltapath")))
					{
						File.Create(Path.Combine(module.deltacore, "deltapath")).Close();
						module.fullpath = module.deltaspath + "\\" + Module.RandomString(15) + ".dll";
						Directory.CreateDirectory(new FileInfo(module.fullpath).Directory.FullName);
						File.WriteAllText(Path.Combine(module.deltacore, "deltapath"), module.fullpath);
					}
					else
					{
						module.fullpath = File.ReadAllText(Path.Combine(module.deltacore, "deltapath"));
						Directory.CreateDirectory(new FileInfo(module.fullpath).Directory.FullName);
					}
					switch (this._API)
					{
					case Module.API.DELTA:
						module.selected_api = Module.API.DELTA;
						if (a != Module.Functions.DownloadStr("https://raw.githubusercontent.com/lxnnydev/DeltaHosting/main/NEWDLLVERSDIRECTLINK"))
						{
						}
						break;
					case Module.API.OXYGEN:
						Module.Functions.Download("https://github.com/iDevastate/Oxygen-v2/raw/main/OxygenBytecode.vmp.dll", "./DLLs\\OxygenBytecode.dll");
						break;
					case Module.API.WEAREDEVS:
						module.selected_api = Module.API.WEAREDEVS;
						break;
					case Module.API.EASYEXPLOITS:
						Module.Functions.Download(Module.Functions.DownloadStr("https://easyexploits.com/Module").Split("\r\n".ToCharArray())[1], "./DLLs\\EasyExploits.dll");
						break;
					case Module.API.KRNL:
						Module.Functions.Download("https://k-storage.com/bootstrapper/files/krnl.dll", "./DLLs\\Krnl.dll");
						break;
					}
				}
				catch (Exception exception)
				{
					this.<>1__state = -2;
					this.<>t__builder.SetException(exception);
					return;
				}
				this.<>1__state = -2;
				this.<>t__builder.SetResult();
			}

			// Token: 0x06000149 RID: 329 RVA: 0x00002C2F File Offset: 0x00000E2F
			[DebuggerHidden]
			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				this.<>t__builder.SetStateMachine(stateMachine);
			}

			// Token: 0x040001A0 RID: 416
			public int <>1__state;

			// Token: 0x040001A1 RID: 417
			public AsyncVoidMethodBuilder <>t__builder;

			// Token: 0x040001A2 RID: 418
			public Module <>4__this;

			// Token: 0x040001A3 RID: 419
			public Module.API _API;
		}

		// Token: 0x0200002F RID: 47
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x0600014A RID: 330 RVA: 0x00002C3D File Offset: 0x00000E3D
			// Note: this type is marked as 'beforefieldinit'.
			static <>c()
			{
			}

			// Token: 0x0600014B RID: 331 RVA: 0x00002050 File Offset: 0x00000250
			public <>c()
			{
			}

			// Token: 0x0600014C RID: 332 RVA: 0x00002C49 File Offset: 0x00000E49
			internal char <RandomString>b__20_0(string s)
			{
				return s[Module.random.Next(s.Length)];
			}

			// Token: 0x040001A4 RID: 420
			public static readonly Module.<>c <>9 = new Module.<>c();

			// Token: 0x040001A5 RID: 421
			public static Func<string, char> <>9__20_0;
		}

		// Token: 0x02000030 RID: 48
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct <autoexec>d__24 : IAsyncStateMachine
		{
			// Token: 0x0600014D RID: 333 RVA: 0x0000C2DC File Offset: 0x0000A4DC
			void IAsyncStateMachine.MoveNext()
			{
				int num = this.<>1__state;
				Module module = this.<>4__this;
				try
				{
					if (num != 0)
					{
						goto IL_6F;
					}
					TaskAwaiter awaiter = this.<>u__1;
					this.<>u__1 = default(TaskAwaiter);
					this.<>1__state = -1;
					IL_68:
					awaiter.GetResult();
					IL_6F:
					if (module.Inject_Delta.Exists(module.Pipe))
					{
						foreach (string path in Directory.GetFiles(Environment.CurrentDirectory + "/autoexecute"))
						{
							module.Execute(File.ReadAllText(path));
						}
					}
					else
					{
						awaiter = Task.Delay(25).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.<>1__state = 0;
							this.<>u__1 = awaiter;
							this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Module.<autoexec>d__24>(ref awaiter, ref this);
							return;
						}
						goto IL_68;
					}
				}
				catch (Exception exception)
				{
					this.<>1__state = -2;
					this.<>t__builder.SetException(exception);
					return;
				}
				this.<>1__state = -2;
				this.<>t__builder.SetResult();
			}

			// Token: 0x0600014E RID: 334 RVA: 0x00002C61 File Offset: 0x00000E61
			[DebuggerHidden]
			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				this.<>t__builder.SetStateMachine(stateMachine);
			}

			// Token: 0x040001A6 RID: 422
			public int <>1__state;

			// Token: 0x040001A7 RID: 423
			public AsyncVoidMethodBuilder <>t__builder;

			// Token: 0x040001A8 RID: 424
			public Module <>4__this;

			// Token: 0x040001A9 RID: 425
			private TaskAwaiter <>u__1;
		}
	}
}
