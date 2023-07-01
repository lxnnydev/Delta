using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Delta.Classes
{
	// Token: 0x02000031 RID: 49
	public class Injector
	{
		// Token: 0x0600014F RID: 335
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint access, bool inhert_handle, int pid);

		// Token: 0x06000150 RID: 336
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x06000151 RID: 337
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, int lpNumberOfBytesWritten);

		// Token: 0x06000152 RID: 338
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x06000153 RID: 339
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000154 RID: 340
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x06000155 RID: 341
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		// Token: 0x06000156 RID: 342
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool WaitNamedPipe(string pipe, int timeout = 10);

		// Token: 0x06000157 RID: 343 RVA: 0x00002C6F File Offset: 0x00000E6F
		public bool Exists(string Name)
		{
			return Injector.WaitNamedPipe("\\\\.\\pipe\\" + Name, 10);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000C3E4 File Offset: 0x0000A5E4
		public bool is_ghost_proc(ProcessModuleCollection a1)
		{
			foreach (object obj in a1)
			{
				string text = ((ProcessModule)obj).FileName.ToString();
				if (text.Contains("cryptnet") || text.Contains("mswsock") || text.Contains("urlmon") || text.Contains("XInput1_4") || text.Contains("CoreUIComponents"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000C484 File Offset: 0x0000A684
		private Injector.Result r_inject(string dll_path, bool ghostcheck)
		{
			Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
			uint num = 0U;
			while ((ulong)num < (ulong)((long)processesByName.Length))
			{
				Process process = processesByName[(int)num];
				string name = "DeltaPipe";
				bool flag = ghostcheck;
				if (flag)
				{
					flag = !this.is_ghost_proc(process.Modules);
				}
				if (!this.Exists(name) && flag)
				{
					IntPtr intPtr = Injector.OpenProcess(1082U, false, process.Id);
					if (intPtr == Injector.NULL)
					{
						return Injector.Result.Unknown;
					}
					IntPtr procAddress = Injector.GetProcAddress(Injector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
					if (procAddress == Injector.NULL)
					{
						return Injector.Result.Unknown;
					}
					IntPtr intPtr2 = Injector.VirtualAllocEx(intPtr, (IntPtr)null, (IntPtr)dll_path.Length, 12288U, 64U);
					if (intPtr2 == Injector.NULL)
					{
						return Injector.Result.Unknown;
					}
					byte[] bytes = Encoding.ASCII.GetBytes(dll_path);
					if (Injector.WriteProcessMemory(intPtr, intPtr2, bytes, bytes.Length, 0) == 0)
					{
						return Injector.Result.Unknown;
					}
					if (Injector.CreateRemoteThread(intPtr, (IntPtr)null, Injector.NULL, procAddress, intPtr2, 0U, (IntPtr)null) == Injector.NULL)
					{
						return Injector.Result.Unknown;
					}
					Injector.CloseHandle(intPtr);
					return Injector.Result.Success;
				}
				else
				{
					num += 1U;
				}
			}
			return Injector.Result.Success;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000C5BC File Offset: 0x0000A7BC
		public Injector.Result inject(string path, bool ghostcheck)
		{
			try
			{
				if (!File.Exists(path))
				{
					return Injector.Result.DLLNotFound;
				}
				return this.r_inject(path, ghostcheck);
			}
			catch (Exception ex)
			{
				if (ex.ToString().Contains("(0x80004005)"))
				{
					LinkOpener.openlink("https://delta-documentation.gitbook.io/delta-error-fixes/error-fixes/access-is-denied");
				}
				MessageBox.Show("Injection Error\n" + ex.ToString(), "Injection", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			return Injector.Result.Unknown;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00002050 File Offset: 0x00000250
		public Injector()
		{
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00002C83 File Offset: 0x00000E83
		// Note: this type is marked as 'beforefieldinit'.
		static Injector()
		{
		}

		// Token: 0x040001AA RID: 426
		private static readonly IntPtr NULL = (IntPtr)0;

		// Token: 0x02000032 RID: 50
		public enum Result : uint
		{
			// Token: 0x040001AC RID: 428
			Success,
			// Token: 0x040001AD RID: 429
			DLLNotFound,
			// Token: 0x040001AE RID: 430
			OpenProcFail,
			// Token: 0x040001AF RID: 431
			AllocFail,
			// Token: 0x040001B0 RID: 432
			LoadLibFail,
			// Token: 0x040001B1 RID: 433
			RobloxNotOpen,
			// Token: 0x040001B2 RID: 434
			Unknown
		}
	}
}
