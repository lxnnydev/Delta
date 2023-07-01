using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Windows;

namespace Delta
{
	// Token: 0x02000006 RID: 6
	public static class FURKAPI
	{
		// Token: 0x0600000B RID: 11
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint access, bool inhert_handle, int pid);

		// Token: 0x0600000C RID: 12
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x0600000D RID: 13
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, IntPtr nSize, int lpNumberOfBytesWritten);

		// Token: 0x0600000E RID: 14
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x0600000F RID: 15
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000010 RID: 16
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x06000011 RID: 17
		[DllImport("./bin/Fluxteam_net_API.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern bool run_script(IntPtr proc, int pid, string path, [MarshalAs(UnmanagedType.LPWStr)] string script);

		// Token: 0x06000012 RID: 18
		[DllImport("./bin/Fluxteam_net_API.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern bool is_injected(IntPtr proc, int pid, string path);

		// Token: 0x06000013 RID: 19 RVA: 0x00002DD4 File Offset: 0x00000FD4
		public static FURKAPI.Result r_inject(string dll_path)
		{
			FileInfo fileInfo = new FileInfo(dll_path);
			FileSecurity accessControl = fileInfo.GetAccessControl();
			SecurityIdentifier identity = new SecurityIdentifier("S-1-15-2-1");
			accessControl.AddAccessRule(new FileSystemAccessRule(identity, FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
			fileInfo.SetAccessControl(accessControl);
			Process[] processesByName = Process.GetProcessesByName("Windows10Universal");
			if (processesByName.Length == 0)
			{
				return FURKAPI.Result.ProcNotOpen;
			}
			uint num = 0U;
			while ((ulong)num < (ulong)((long)processesByName.Length))
			{
				Process process = processesByName[(int)num];
				if (FURKAPI.pid != process.Id)
				{
					IntPtr intPtr = FURKAPI.OpenProcess(1082U, false, process.Id);
					if (intPtr == FURKAPI.NULL)
					{
						return FURKAPI.Result.OpenProcFail;
					}
					IntPtr intPtr2 = FURKAPI.VirtualAllocEx(intPtr, FURKAPI.NULL, (IntPtr)((dll_path.Length + 1) * Marshal.SizeOf(typeof(char))), 12288U, 64U);
					if (intPtr2 == FURKAPI.NULL)
					{
						return FURKAPI.Result.AllocFail;
					}
					byte[] bytes = Encoding.Default.GetBytes(dll_path);
					int num2 = FURKAPI.WriteProcessMemory(intPtr, intPtr2, bytes, (IntPtr)((dll_path.Length + 1) * Marshal.SizeOf(typeof(char))), 0);
					if (num2 == 0 || (long)num2 == 6L)
					{
						return FURKAPI.Result.Unknown;
					}
					if (FURKAPI.CreateRemoteThread(intPtr, FURKAPI.NULL, FURKAPI.NULL, FURKAPI.GetProcAddress(FURKAPI.GetModuleHandle("kernel32.dll"), "LoadLibraryA"), intPtr2, 0U, FURKAPI.NULL) == FURKAPI.NULL)
					{
						return FURKAPI.Result.LoadLibFail;
					}
					FURKAPI.pid = process.Id;
					FURKAPI.phandle = intPtr;
					return FURKAPI.Result.Success;
				}
				else
				{
					if (FURKAPI.pid == process.Id)
					{
						return FURKAPI.Result.AlreadyInjected;
					}
					num += 1U;
				}
			}
			return FURKAPI.Result.Unknown;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000207C File Offset: 0x0000027C
		public static bool is_injected(string dll_path)
		{
			return FURKAPI.is_injected(FURKAPI.phandle, FURKAPI.pid, dll_path);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000208E File Offset: 0x0000028E
		public static bool run_script(string dll_path, string script)
		{
			if (FURKAPI.pid == 0)
			{
				MessageBox.Show("The specified DLL is not attached to the target process.", "Furk Ultra - Injection Error");
				return false;
			}
			if (script == string.Empty)
			{
				return FURKAPI.is_injected(dll_path);
			}
			return FURKAPI.run_script(FURKAPI.phandle, FURKAPI.pid, dll_path, script);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002F5C File Offset: 0x0000115C
		public static void create_files()
		{
			string text = "";
			foreach (string text2 in Directory.GetDirectories(Environment.GetEnvironmentVariable("LocalAppData") + "\\Packages"))
			{
				if (text2.Contains("OBLOXCORPORATION"))
				{
					if (Directory.GetDirectories(text2 + "\\AC").Any((string dir) => dir.Contains("Temp")))
					{
						text = text2 + "\\AC";
					}
				}
			}
			if (text == "")
			{
				return;
			}
			try
			{
				if (Directory.Exists("workspace"))
				{
					Directory.Move("workspace", "old_workspace");
				}
				if (Directory.Exists("autoexec"))
				{
					Directory.Move("autoexec", "old_autoexec");
				}
			}
			catch
			{
			}
			string path = Path.Combine(text, "workspace");
			string path2 = Path.Combine(text, "autoexec");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (!Directory.Exists(path2))
			{
				Directory.CreateDirectory(path2);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000020CE File Offset: 0x000002CE
		static FURKAPI()
		{
		}

		// Token: 0x04000003 RID: 3
		private static IntPtr phandle;

		// Token: 0x04000004 RID: 4
		private static int pid = 0;

		// Token: 0x04000005 RID: 5
		private static readonly IntPtr NULL = (IntPtr)0;

		// Token: 0x02000007 RID: 7
		public enum Result : uint
		{
			// Token: 0x04000007 RID: 7
			Success,
			// Token: 0x04000008 RID: 8
			DLLNotFound,
			// Token: 0x04000009 RID: 9
			OpenProcFail,
			// Token: 0x0400000A RID: 10
			AllocFail,
			// Token: 0x0400000B RID: 11
			LoadLibFail,
			// Token: 0x0400000C RID: 12
			AlreadyInjected,
			// Token: 0x0400000D RID: 13
			ProcNotOpen,
			// Token: 0x0400000E RID: 14
			Unknown
		}

		// Token: 0x02000008 RID: 8
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x06000018 RID: 24 RVA: 0x000020E1 File Offset: 0x000002E1
			// Note: this type is marked as 'beforefieldinit'.
			static <>c()
			{
			}

			// Token: 0x06000019 RID: 25 RVA: 0x00002050 File Offset: 0x00000250
			public <>c()
			{
			}

			// Token: 0x0600001A RID: 26 RVA: 0x000020ED File Offset: 0x000002ED
			internal bool <create_files>b__11_0(string dir)
			{
				return dir.Contains("Temp");
			}

			// Token: 0x0400000F RID: 15
			public static readonly FURKAPI.<>c <>9 = new FURKAPI.<>c();

			// Token: 0x04000010 RID: 16
			public static Func<string, bool> <>9__11_0;
		}
	}
}
