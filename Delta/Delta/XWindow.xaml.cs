using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Delta.Classes;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Delta
{
	// Token: 0x02000017 RID: 23
	public partial class XWindow : Window, IStyleConnector
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00003E18 File Offset: 0x00002018
		public XWindow()
		{
			this.InitializeComponent();
			this.setupdelta();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003F08 File Offset: 0x00002108
		public void setupdelta()
		{
			XWindow.<setupdelta>d__11 <setupdelta>d__;
			<setupdelta>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<setupdelta>d__.<>4__this = this;
			<setupdelta>d__.<>1__state = -1;
			<setupdelta>d__.<>t__builder.Start<XWindow.<setupdelta>d__11>(ref <setupdelta>d__);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003F40 File Offset: 0x00002140
		public void setup_furk()
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					if (!Directory.Exists("./bin"))
					{
						Directory.CreateDirectory("./bin");
					}
					if (!Directory.Exists("./autoexec"))
					{
						Directory.CreateDirectory("./autoexec");
					}
					if (!Directory.Exists("./scripts"))
					{
						Directory.CreateDirectory("./scripts");
					}
					if (!File.Exists("./bin/Fluxteam_net_API.dll"))
					{
						webClient.DownloadFile("https://cdn.discordapp.com/attachments/1105318408347725864/1106617498608083055/Fluxteam_net_API.dll", "./bin/Fluxteam_net_API.dll");
					}
					if (!File.Exists("./bin/579-Module.dll"))
					{
						webClient.DownloadFile("https://cdn.discordapp.com/attachments/1113162812085260298/1122197818505961602/Delta.dll", "./bin/579-Module.dll");
					}
					if (!File.Exists("./bin/577-Delta-Module.dll"))
					{
						webClient.DownloadFile("https://cdn.discordapp.com/attachments/1077685725216125000/1111989033627832381/Delta.dll", "./bin/577-Delta-Module.dll");
					}
					if (!File.Exists("./bin/578-Delta-Module.dll"))
					{
						webClient.DownloadFile("https://cdn.discordapp.com/attachments/1074592834331623504/1114370701365886986/Module.dll", "./bin/578-Delta-Module.dll");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Delta - Unhandled Exception");
				Environment.Exit(0);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000404C File Offset: 0x0000224C
		private void Inject()
		{
			Process[] processesByName = Process.GetProcessesByName("Windows10Universal");
			if (processesByName.Length == 0)
			{
				if (MessageBox.Show("Make sure you use the Microsoft Store Version of Roblox. (Roblox.com is currently not supported)\nDo You want to see a video that explains, how you can setup the microsoft store version of roblox?", "Delta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					Process.Start("https://youtu.be/pOzOfL7Dea8?t=180");
				}
				return;
			}
			string a = XWindow.CalculateSHA256(processesByName[0].MainModule.FileName);
			if (!(a == "82826209ded0fb125064dc72db7e1ed2b970b47aa18984b74598dfa08652e6d4"))
			{
				if (!(a == "5e4e3b6758ad22338bd7354a4a0b85a376f809d1a523d2b7bba2e09c2f0642cf"))
				{
					if (a == "3d29341b6e65082db28be29f07bb354f9910d0b7b8d7b881ae6b3200cce736d9")
					{
						this.CurrentModule = this.Module575;
					}
				}
				else
				{
					this.CurrentModule = this.Module578;
				}
			}
			else
			{
				this.CurrentModule = this.Module577;
			}
			if (this.CurrentModule == "")
			{
				return;
			}
			switch (FURKAPI.r_inject(this.CurrentModule))
			{
			case FURKAPI.Result.Success:
				MessageBox.Show("Successfully attached to Roblox!", "Delta - Injection Result");
				return;
			case FURKAPI.Result.DLLNotFound:
				MessageBox.Show("The specified DLL could not be found. Please ensure that the DLL exists and that the path is correct.", "Delta - Injection Error");
				return;
			case FURKAPI.Result.OpenProcFail:
				MessageBox.Show("Failed to open the target process.", "Delta - Injection Error");
				return;
			case FURKAPI.Result.AllocFail:
				MessageBox.Show("Failed to allocate memory in the target process.", "Delta - Injection Error");
				return;
			case FURKAPI.Result.LoadLibFail:
				MessageBox.Show("Failed to load the specified DLL into the target process. Please ensure that the DLL is valid and that it can be loaded into the target process.", "Delta - Injection Error");
				return;
			case FURKAPI.Result.AlreadyInjected:
				MessageBox.Show("The specified DLL is already injected into the target process.", "Delta - Injection Error");
				return;
			case FURKAPI.Result.ProcNotOpen:
				MessageBox.Show("Make sure you use the Microsoft Store Version of Roblox. (Roblox.com is currently not supported)", "Delta - Injection Error");
				return;
			case FURKAPI.Result.Unknown:
				MessageBox.Show("An unknown error occurred. Please try again or contact support for assistance.", "Delta - Injection Error");
				return;
			default:
				return;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00002525 File Offset: 0x00000725
		public void RunScript(string Script)
		{
			if (this.CurrentModule == "")
			{
				MessageBox.Show("Make sure you inject before executing.", "Delta - Injection Error");
				return;
			}
			FURKAPI.run_script(this.CurrentModule, Script);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000041BC File Offset: 0x000023BC
		private static string CalculateSHA256(string Path)
		{
			string result;
			using (SHA256 sha = SHA256.Create())
			{
				using (FileStream fileStream = File.OpenRead(Path))
				{
					byte[] array = sha.ComputeHash(fileStream);
					StringBuilder stringBuilder = new StringBuilder();
					foreach (byte b in array)
					{
						stringBuilder.Append(b.ToString("x2"));
					}
					result = stringBuilder.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000424C File Offset: 0x0000244C
		private static string CalculateSHA384(string Path)
		{
			string result;
			using (SHA384 sha = SHA384.Create())
			{
				using (FileStream fileStream = File.OpenRead(Path))
				{
					byte[] array = sha.ComputeHash(fileStream);
					StringBuilder stringBuilder = new StringBuilder();
					foreach (byte b in array)
					{
						stringBuilder.Append(b.ToString("x2"));
					}
					result = stringBuilder.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002557 File Offset: 0x00000757
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[XWindow.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000042DC File Offset: 0x000024DC
		public void update_dll()
		{
			bool? isChecked = this.delta.IsChecked;
			bool flag = true;
			if (isChecked.GetValueOrDefault() == flag & isChecked != null)
			{
				if (!File.Exists(System.IO.Path.Combine(this.deltacore, "deltapath")))
				{
					File.Create(System.IO.Path.Combine(this.deltacore, "deltapath")).Close();
					this.fullpath = this.deltaspath + "\\" + XWindow.RandomString(15) + ".dll";
					Directory.CreateDirectory(new FileInfo(this.fullpath).Directory.FullName);
					File.WriteAllText(System.IO.Path.Combine(this.deltacore, "deltapath"), this.fullpath);
				}
				else
				{
					this.fullpath = File.ReadAllText(System.IO.Path.Combine(this.deltacore, "deltapath"));
					Directory.CreateDirectory(new FileInfo(this.fullpath).Directory.FullName);
				}
				if (File.ReadAllText(System.IO.Path.Combine(this.deltacore, "deltavers.txt")) != LinkOpener.DownloadStr("https://raw.githubusercontent.com/lxnnydev/DeltaHosting/main/NEWDLLVERSDIRECTLINK"))
				{
					this.download_progress.Opacity = 1.0;
					this.modals.Visibility = Visibility.Visible;
					this.download_progress.Visibility = Visibility.Visible;
					WebClient webClient = new WebClient();
					webClient.DownloadProgressChanged += this.client_DownloadProgressChanged;
					webClient.DownloadFileCompleted += this.client_DownloadFileCompleted;
					webClient.DownloadFileAsync(new Uri(LinkOpener.DownloadStr("https://raw.githubusercontent.com/lxnnydev/DeltaHosting/main/NEWDLLVERSDIRECTLINK")), this.fullpath);
				}
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004464 File Offset: 0x00002664
		private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			double num = double.Parse(e.BytesReceived.ToString());
			double num2 = double.Parse(e.TotalBytesToReceive.ToString());
			double num3 = num / num2 * 100.0;
			this.thxforusingdelta1_Copy.Text = string.Format("Downloaded {0}/100%", (int)num3);
			this.progrbar.Value = (double)int.Parse(Math.Truncate(num3).ToString());
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000044E0 File Offset: 0x000026E0
		private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			XWindow.<client_DownloadFileCompleted>d__27 <client_DownloadFileCompleted>d__;
			<client_DownloadFileCompleted>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<client_DownloadFileCompleted>d__.<>4__this = this;
			<client_DownloadFileCompleted>d__.<>1__state = -1;
			<client_DownloadFileCompleted>d__.<>t__builder.Start<XWindow.<client_DownloadFileCompleted>d__27>(ref <client_DownloadFileCompleted>d__);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004518 File Offset: 0x00002718
		private static bool IsValidJson(string strInput)
		{
			if (string.IsNullOrWhiteSpace(strInput))
			{
				return false;
			}
			strInput = strInput.Trim();
			if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || (strInput.StartsWith("[") && strInput.EndsWith("]")))
			{
				try
				{
					JToken.Parse(strInput);
					return true;
				}
				catch (JsonReaderException ex)
				{
					Console.WriteLine(ex.Message);
					return false;
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.ToString());
					return false;
				}
				return false;
			}
			return false;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000045B4 File Offset: 0x000027B4
		public void setup_themes()
		{
			if (this.theme_wrap_panel.Children.Count == 0)
			{
				using (WebClient webClient = new WebClient())
				{
					foreach (Theme this_theme in JsonConvert.DeserializeObject<Root>(webClient.DownloadString("https://gitlab.com/littlekiller2927/deltacore/-/raw/main/deltathemes.json")).themes)
					{
						this.theme_wrap_panel.Children.Add(new ThemeItem(this_theme));
					}
				}
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004654 File Offset: 0x00002854
		public void show_eula()
		{
			XWindow.<show_eula>d__30 <show_eula>d__;
			<show_eula>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<show_eula>d__.<>4__this = this;
			<show_eula>d__.<>1__state = -1;
			<show_eula>d__.<>t__builder.Start<XWindow.<show_eula>d__30>(ref <show_eula>d__);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000468C File Offset: 0x0000288C
		private void LoadSettings()
		{
			if (!File.Exists(System.IO.Path.Combine(this.deltacore, "Settings.json")) || !File.ReadAllText(System.IO.Path.Combine(this.deltacore, "Settings.json")).Contains("thai_thai") || !XWindow.IsValidJson(File.ReadAllText(System.IO.Path.Combine(this.deltacore, "Settings.json"))))
			{
				File.WriteAllText(System.IO.Path.Combine(this.deltacore, "Settings.json"), "[  {    \"CBName\": \"opacity\",    \"CBState\": false  },  {    \"CBName\": \"topmost\",    \"CBState\": false  },  {    \"CBName\": \"delta\",    \"CBState\": true  },  {    \"CBName\": \"wrd\",    \"CBState\": false  },  {    \"CBName\": \"autoinj\",    \"CBState\": false  },  {    \"CBName\": \"verscheck\",    \"CBState\": false  },  {    \"CBName\": \"autofade\",    \"CBState\": false  },  {    \"CBName\": \"fpsunlocker\",    \"CBState\": false  },  {    \"CBName\": \"eng_eng\",    \"CBState\": true  },  {    \"CBName\": \"ger_deutsch\",    \"CBState\": false  },  {    \"CBName\": \"tur_tur\",    \"CBState\": false  },  {    \"CBName\": \"spa_esp\",    \"CBState\": false  },  {    \"CBName\": \"ind_bah\",    \"CBState\": false  },  {    \"CBName\": \"por_por\",    \"CBState\": false  },  {    \"CBName\": \"fil_pil\",    \"CBState\": false  },  {    \"CBName\": \"pol_pol\",    \"CBState\": false  },  {    \"CBName\": \"fin_sou\",    \"CBState\": false  },  {    \"CBName\": \"fre_fra\",    \"CBState\": false  },  {    \"CBName\": \"thai_thai\",    \"CBState\": false  }]");
			}
			object arg = JsonConvert.DeserializeObject(File.ReadAllText(System.IO.Path.Combine(this.deltacore, "Settings.json")));
			if (XWindow.<>o__31.<>p__7 == null)
			{
				XWindow.<>o__31.<>p__7 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(XWindow)));
			}
			foreach (object arg2 in XWindow.<>o__31.<>p__7.Target(XWindow.<>o__31.<>p__7, arg))
			{
				if (XWindow.<>o__31.<>p__2 == null)
				{
					XWindow.<>o__31.<>p__2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(XWindow), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target = XWindow.<>o__31.<>p__2.Target;
				CallSite <>p__ = XWindow.<>o__31.<>p__2;
				if (XWindow.<>o__31.<>p__1 == null)
				{
					XWindow.<>o__31.<>p__1 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(XWindow), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, bool, object> target2 = XWindow.<>o__31.<>p__1.Target;
				CallSite <>p__2 = XWindow.<>o__31.<>p__1;
				if (XWindow.<>o__31.<>p__0 == null)
				{
					XWindow.<>o__31.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(XWindow), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				if (target(<>p__, target2(<>p__2, XWindow.<>o__31.<>p__0.Target(XWindow.<>o__31.<>p__0, arg2, "CBState"), true)))
				{
					if (XWindow.<>o__31.<>p__6 == null)
					{
						XWindow.<>o__31.<>p__6 = CallSite<Func<CallSite, object, CheckBox>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(CheckBox), typeof(XWindow)));
					}
					Func<CallSite, object, CheckBox> target3 = XWindow.<>o__31.<>p__6.Target;
					CallSite <>p__3 = XWindow.<>o__31.<>p__6;
					if (XWindow.<>o__31.<>p__5 == null)
					{
						XWindow.<>o__31.<>p__5 = CallSite<Func<CallSite, XWindow, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "FindName", null, typeof(XWindow), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, XWindow, object, object> target4 = XWindow.<>o__31.<>p__5.Target;
					CallSite <>p__4 = XWindow.<>o__31.<>p__5;
					if (XWindow.<>o__31.<>p__4 == null)
					{
						XWindow.<>o__31.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(XWindow), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target5 = XWindow.<>o__31.<>p__4.Target;
					CallSite <>p__5 = XWindow.<>o__31.<>p__4;
					if (XWindow.<>o__31.<>p__3 == null)
					{
						XWindow.<>o__31.<>p__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(XWindow), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					target3(<>p__3, target4(<>p__4, this, target5(<>p__5, XWindow.<>o__31.<>p__3.Target(XWindow.<>o__31.<>p__3, arg2, "CBName")))).IsChecked = new bool?(true);
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000049E4 File Offset: 0x00002BE4
		public void search_scriptblox(string query = "pet sim x", string filters = "hot")
		{
			XWindow.<search_scriptblox>d__32 <search_scriptblox>d__;
			<search_scriptblox>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<search_scriptblox>d__.<>4__this = this;
			<search_scriptblox>d__.query = query;
			<search_scriptblox>d__.filters = filters;
			<search_scriptblox>d__.<>1__state = -1;
			<search_scriptblox>d__.<>t__builder.Start<XWindow.<search_scriptblox>d__32>(ref <search_scriptblox>d__);
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00002592 File Offset: 0x00000792
		// (set) Token: 0x060000AF RID: 175 RVA: 0x0000259A File Offset: 0x0000079A
		private IEasingFunction EasingSmooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseOut
		};

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000025A3 File Offset: 0x000007A3
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000025AB File Offset: 0x000007AB
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x060000B2 RID: 178 RVA: 0x00004A2C File Offset: 0x00002C2C
		public void heightanim(DependencyObject Element, double one, double two)
		{
			Storyboard storyboard = new Storyboard();
			DoubleAnimation doubleAnimation = new DoubleAnimation(one, two, TimeSpan.Parse("00:00:1"));
			doubleAnimation.EasingFunction = this.Smooth;
			Storyboard.SetTarget(storyboard, Element);
			Storyboard.SetTargetProperty(storyboard, new PropertyPath(FrameworkElement.HeightProperty));
			storyboard.Children.Add(doubleAnimation);
			storyboard.Begin();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004A8C File Offset: 0x00002C8C
		public void opacityanim(DependencyObject Element, double one, double two)
		{
			Storyboard storyboard = new Storyboard();
			DoubleAnimation doubleAnimation = new DoubleAnimation(one, two, TimeSpan.Parse("00:00:1"));
			doubleAnimation.EasingFunction = this.Smooth;
			Storyboard.SetTarget(storyboard, Element);
			Storyboard.SetTargetProperty(storyboard, new PropertyPath(UIElement.OpacityProperty));
			storyboard.Children.Add(doubleAnimation);
			storyboard.Begin();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004AEC File Offset: 0x00002CEC
		public void widthanim(DependencyObject Element, double one, double two, IEasingFunction idk)
		{
			Storyboard storyboard = new Storyboard();
			DoubleAnimation doubleAnimation = new DoubleAnimation(one, two, TimeSpan.Parse("00:00:1"));
			doubleAnimation.EasingFunction = idk;
			Storyboard.SetTarget(storyboard, Element);
			Storyboard.SetTargetProperty(storyboard, new PropertyPath(FrameworkElement.WidthProperty));
			storyboard.Children.Add(doubleAnimation);
			storyboard.Begin();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004B48 File Offset: 0x00002D48
		public void marginanim(DependencyObject Element, Thickness one, Thickness two, IEasingFunction idk)
		{
			Storyboard storyboard = new Storyboard();
			ThicknessAnimation thicknessAnimation = new ThicknessAnimation(one, two, TimeSpan.Parse("00:00:1"));
			thicknessAnimation.EasingFunction = idk;
			Storyboard.SetTarget(storyboard, Element);
			Storyboard.SetTargetProperty(storyboard, new PropertyPath(FrameworkElement.MarginProperty));
			storyboard.Children.Add(thicknessAnimation);
			storyboard.Begin();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004BA4 File Offset: 0x00002DA4
		public void create_a_new_tab(string tabname = "NewScript.lua", string content = "")
		{
			this.tabControl1.Items.Add(this.CreateTab(tabname, ""));
			using (Stream stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\bin\\lua.xshd"))
			{
				using (XmlTextReader xmlTextReader = new XmlTextReader(stream))
				{
					(this.tabControl1.SelectedContent as TextEditor).SyntaxHighlighting = HighlightingLoader.Load(xmlTextReader, HighlightingManager.Instance);
				}
			}
			(this.tabControl1.SelectedContent as TextEditor).TextArea.TextView.LinkTextUnderline = false;
			(this.tabControl1.SelectedContent as TextEditor).TextArea.TextView.LinkTextForegroundBrush = new SolidColorBrush(Color.FromRgb(63, 139, 200));
			this.dolines();
			this.SetText(content);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000025B4 File Offset: 0x000007B4
		public TabItem GetCurrentTab()
		{
			if (this.tabControl.SelectedIndex == -1)
			{
				return null;
			}
			return this.tabControl1.SelectedItem as TabItem;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004CA0 File Offset: 0x00002EA0
		public TabItem CreateTab(string Header, string Text = "")
		{
			TextBox header = new TextBox
			{
				Text = Header,
				IsEnabled = false,
				TextWrapping = TextWrapping.NoWrap,
				IsHitTestVisible = false,
				Style = (base.TryFindResource("InvisibleTextBox") as Style)
			};
			TabItem tabItem = new TabItem();
			tabItem.Header = header;
			tabItem.FontSize = 11.0;
			tabItem.Foreground = new SolidColorBrush(Color.FromRgb(86, 154, 200));
			tabItem.Style = (base.TryFindResource("tab") as Style);
			tabItem.IsSelected = true;
			tabItem.Content = this.AvalonEdit(Text);
			tabItem.MouseDown += delegate(object sender, MouseButtonEventArgs e)
			{
				if (e.OriginalSource is Border && e.RightButton == MouseButtonState.Pressed)
				{
					TextBox textBox = this.GetCurrentTab().Header as TextBox;
					textBox.IsEnabled = true;
					textBox.Focus();
					textBox.SelectAll();
				}
			};
			return tabItem;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004D58 File Offset: 0x00002F58
		public TextEditor AvalonEdit(string Text)
		{
			return new TextEditor
			{
				FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Assets/Fonts/#Jetbrains Mono"),
				ShowLineNumbers = true,
				FontSize = 12.0,
				Text = Text,
				Background = Brushes.Transparent,
				Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
				HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
				VerticalScrollBarVisibility = ScrollBarVisibility.Auto
			};
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000025D6 File Offset: 0x000007D6
		private void dolines()
		{
			(this.tabControl1.SelectedContent as TextEditor).TextArea.TextView.ElementGenerators.Add(new AvalonLines());
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00002601 File Offset: 0x00000801
		private string GetText()
		{
			return (this.tabControl1.SelectedContent as TextEditor).Text;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00002618 File Offset: 0x00000818
		private void SetText(string Text = "")
		{
			(this.tabControl1.SelectedContent as TextEditor).Text = Text;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00002630 File Offset: 0x00000830
		private void button_Copy_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00002638 File Offset: 0x00000838
		private void button_Copy1_Click(object sender, RoutedEventArgs e)
		{
			if (base.WindowState != WindowState.Maximized)
			{
				base.WindowState = WindowState.Maximized;
				return;
			}
			base.WindowState = WindowState.Normal;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00002652 File Offset: 0x00000852
		private void button_Copy2_Click(object sender, RoutedEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004DDC File Offset: 0x00002FDC
		public void refresh_scriptbox(string query = "")
		{
			this.lbol.Items.Clear();
			string text = ".\\scripts";
			foreach (FileInfo fileInfo in new DirectoryInfo(text).GetFiles())
			{
				if (this.luaselected.IsChecked.Value)
				{
					if (fileInfo.Extension == ".lua" && fileInfo.Name.Contains(query))
					{
						this.lbol.Items.Add(new ListBoxItem
						{
							Content = fileInfo.Name,
							Tag = fileInfo.FullName,
							Style = (base.TryFindResource("listboxitem") as Style)
						});
					}
				}
				else if (this.txtselected.IsChecked.Value)
				{
					if (fileInfo.Extension == ".txt" && fileInfo.Name.Contains(query))
					{
						this.lbol.Items.Add(new ListBoxItem
						{
							Content = fileInfo.Name,
							Tag = fileInfo.FullName,
							Style = (base.TryFindResource("listboxitem") as Style)
						});
					}
				}
				else if (this.allselected.IsChecked.Value && fileInfo.Name.Contains(query))
				{
					this.lbol.Items.Add(new ListBoxItem
					{
						Content = fileInfo.Name,
						Tag = fileInfo.FullName,
						Style = (base.TryFindResource("listboxitem") as Style)
					});
				}
			}
			DirectoryInfo[] directories = new DirectoryInfo(text).GetDirectories("*.*", SearchOption.AllDirectories);
			for (int i = 0; i < directories.Length; i++)
			{
				foreach (FileInfo fileInfo2 in new DirectoryInfo(directories[i].FullName).GetFiles())
				{
					if (this.luaselected.IsChecked.Value)
					{
						if (fileInfo2.Extension == ".lua" && fileInfo2.Name.Contains(query))
						{
							this.lbol.Items.Add(new ListBoxItem
							{
								Content = fileInfo2.Name,
								Tag = fileInfo2.FullName,
								Style = (base.TryFindResource("listboxitem") as Style)
							});
						}
					}
					else if (this.txtselected.IsChecked.Value)
					{
						if (fileInfo2.Extension == ".txt" && fileInfo2.Name.Contains(query))
						{
							this.lbol.Items.Add(new ListBoxItem
							{
								Content = fileInfo2.Name,
								Tag = fileInfo2.FullName,
								Style = (base.TryFindResource("listboxitem") as Style)
							});
						}
					}
					else if (this.allselected.IsChecked.Value && fileInfo2.Name.Contains(query))
					{
						this.lbol.Items.Add(new ListBoxItem
						{
							Content = fileInfo2.Name,
							Tag = fileInfo2.FullName,
							Style = (base.TryFindResource("listboxitem") as Style)
						});
					}
				}
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00005168 File Offset: 0x00003368
		private void lbol_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.lbol.Items.Count > 0)
				{
					ListBoxItem listBoxItem = this.lbol.SelectedItem as ListBoxItem;
					string text = File.ReadAllText(string.Format("{0}", listBoxItem.Tag));
					this.create_a_new_tab(string.Format("{0}", listBoxItem.Content), "");
					this.SetText(text);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000051E8 File Offset: 0x000033E8
		public void uncheckalllangs(object sender)
		{
			foreach (object obj in this.etc1.Children)
			{
				CheckBox checkBox = (CheckBox)obj;
				if (checkBox != sender)
				{
					checkBox.IsChecked = new bool?(false);
				}
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00005250 File Offset: 0x00003450
		public void englishlang()
		{
			this.header1.Text = "Auto Execute";
			this.header_Copy1.Text = "This automatically executes all scripts you want everytime you inject/serverhop";
			this.header9.Text = "Open DLL Folder";
			this.header_Copy10.Text = "This opens Delta's DLL Folder, that includes the workspace, logs and autoexec folder";
			this.header2.Text = "FPS Unlocker";
			this.header_Copy2.Text = "Unlock your frames per second to get a much more enhanced experience on Roblox";
			this.header3.Text = "Kill Roblox";
			this.header_Copy3.Text = "This kills/closes all currently running Roblox processes";
			this.header4.Text = "Opacity";
			this.header_Copy5.Text = "Makes Delta transparent by lowering the window opacity";
			this.header5.Text = "TopMost";
			this.header_Copy6.Text = "Makes the Delta UI stay focused on top of your other windows";
			this.header6.Text = "Auto Fade";
			this.header_Copy7.Text = "Automatically lower opacity upon window focus being lost";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Use the powerful level 7 Delta API (recommended)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "Use the WeAreDevs API (level 7)";
			this.header8.Text = "Auto Inject";
			this.header_Copy9.Text = "This automatically injects for you everytime you open roblox";
			this.header7.Text = "Version Checking";
			this.header_Copy8.Text = "Corrects the roblox version if its wrong (Could slow injection)";
			this.header20.Text = "Reinstall DLL";
			this.header_Copy21.Text = "This option reinstalls Delta's DLL/Module which runs scripts";
			this.header21.Text = "Install Dependencies";
			this.header_Copy22.Text = "Reinstall VC Redist x64, x86 and DirectX automatically";
			this.no_results = "Sorry, We couldnt find any results :(";
			this.save_text = "Your settings were saved and will automatically load the next time you launch Delta!";
			this.auto_exec_prompt = "This can not be turned on/off because Delta automatically executes all files you put in the \"autoexec\" folder.\nDo you want to open the \"autoexec\" folder?";
			this.exec_btn.Content = "EXECUTE";
			this.clr_btn.Content = "CLEAR";
			this.opn_btn.Content = "OPEN";
			this.sve_btn.Content = "SAVE";
			this.inj_btn.Content = "INJECT";
			this.execute_again_button.Content = "Execute";
			this.browse_lbl.Text = "Browse";
			this.hot.Content = "Hot";
			this.old.Content = "Oldest";
			this.mostv.Content = "Most Viewed";
			this.FAVS.Content = "Favorites";
			this.desctxt.Text = "Description";
			this.search_scripts_folder_box.Tag = "Filter Items..";
			this.searchbox.Tag = "Filter Items..";
			this.allselected.Content = "ALL FILES";
			this.placeholdertext.Text = "We have over 4,000+ Scripts that you can search for! Start by doing a search :D";
			this.theme_title.Text = "Select a Theme!";
			this.theme_desc.Text = "Select a Theme to start! Apply it using the \"Use Theme\" Button";
			this.resettheme.Content = "Reset Theme";
			this.usetheme.Content = "Use Theme";
			this.homelbl.Text = "HOME";
			this.scrptslbl.Text = "SCRIPTS";
			this.thmlbl.Text = "THEMES";
			this.cnfglbl.Text = "CONFIG";
			this.header_Copy4.Text = "Configuration";
			this.saveset.Content = "Save Settings";
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000055C0 File Offset: 0x000037C0
		public void finnishlang()
		{
			this.header1.Text = "Automaattisesti suorita";
			this.header_Copy1.Text = "Tämä automaattisest suorittaa kaikki skriptit joka kerta kun sinä kiinnität Deltan peliisi/vaihdat serveriä";
			this.header9.Text = "Avaa DLL kansio";
			this.header_Copy10.Text = "Tämä avaa kaikki Deltan DLL kansiot, jotka sisältävät Työpaikan tallenettuihin skripteihisi ja autoexec kansiot";
			this.header2.Text = "FPS:n avaaja";
			this.header_Copy2.Text = "Tekee sinun Ruudunpäivitysnopeudesta isomman jotta saisit paljon paremman kokemuksen Robloxista";
			this.header3.Text = "Sulje Roblox";
			this.header_Copy3.Text = "Tämä tuhoaa/sulkee kaikki käynnissä olevat Roblox-prosessit";
			this.header4.Text = "Peittävyys";
			this.header_Copy5.Text = "Tekee Deltasta läpinäkyvän alentamalla ikkunan peittävyyttä ";
			this.header5.Text = "TopMost";
			this.header_Copy6.Text = "Saa Delta-käyttöliittymän keskittymään muiden ikkunojesi päälle";
			this.header6.Text = "Auto Fade";
			this.header_Copy7.Text = "Pienennä läpikuultamattomuutta automaattisesti, kun ikkunan tarkennus katoaa";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Käytä voimakasta tason 7 Deltan Ohjelmointirajapintaa (suositeltu)";
			this.header13.Text = "WRD Ohjelmointirajapinta";
			this.header_Copy14.Text = "Käytä WeAreDevs:in Ohjelmointirajapintaa (taso 7)";
			this.header8.Text = "Automaattisesti suorita";
			this.header_Copy9.Text = "Tämä automaattisesti suorittaa skriptisi sinulle joka kerta kun avaat robloxin";
			this.header7.Text = "Version Tarkistus";
			this.header_Copy8.Text = "Korjaa/päivittää robloxin version Jos se on väärin (Voi hidastaa suoritus nopeutta)";
			this.header20.Text = "Lataa uudelleen DLL:ät";
			this.header_Copy21.Text = "Tämä vaihtoehto asentaa Deltan DLL/moduulin uudelleen, joka suorittaa komentosarjoja/skriptisi";
			this.header21.Text = "Asenna riippuvuudet";
			this.header_Copy22.Text = "Asenna VC Redist x64, x86 ja DirectX automaattisesti uudelleen";
			this.no_results = "Anteeki, emme löytäneet yhtään tuloksia :C :(";
			this.save_text = "Asetuksesi tallennettiin ja latautuvat automaattisesti, kun seuraavan kerran käynnistät Deltan!";
			this.auto_exec_prompt = "Tätä ei voi kytkeä päälle tai pois päältä, koska Delta suorittaa automaattisesti kaikki \"autoexec\"-kansioon lisäämäsi tiedostot.\nHaluatko avata \"autoexec\"-kansion?";
			this.exec_btn.Content = "SUORITA";
			this.clr_btn.Content = "TYHJENNÄ";
			this.opn_btn.Content = "AVAA";
			this.sve_btn.Content = "TALLENNA";
			this.inj_btn.Content = "SUORITA INJEKTIO";
			this.execute_again_button.Content = "Suorita";
			this.browse_lbl.Text = "Hae";
			this.hot.Content = "Kuuminta";
			this.old.Content = "Vanhin";
			this.mostv.Content = "Eniten katsottuin";
			this.FAVS.Content = "Suosikit";
			this.desctxt.Text = "Kuvaus";
			this.search_scripts_folder_box.Tag = "Filter Items..";
			this.searchbox.Tag = "Suodata kohteet..";
			this.allselected.Content = "KAIKKI TIEDOSTOT";
			this.placeholdertext.Text = "Meillä on yli 4 000 komentosarjaa, joita voit etsiä! Aloita tekemällä haku c:";
			this.theme_title.Text = "Valitse teema!";
			this.theme_desc.Text = "Aloita valitsemalla teema! Käytä sitä käyttämällä \"Use Theme\" painiketta";
			this.resettheme.Content = "Resetoi teema";
			this.usetheme.Content = "Käytä teema";
			this.homelbl.Text = "KOTI";
			this.scrptslbl.Text = "SKRIPTIT";
			this.thmlbl.Text = "TEEMAT";
			this.cnfglbl.Text = "ASETUKSIA";
			this.header_Copy4.Text = "Kokoonpano";
			this.saveset.Content = "Tallenna asetukset";
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00005930 File Offset: 0x00003B30
		public void frenchlang()
		{
			this.header1.Text = "Éxecution Automatique";
			this.header_Copy1.Text = "Ceci éxecute automatiquement tous les scripts lorsque tu injectes";
			this.header9.Text = "Ouvrir le dossier DLL";
			this.header_Copy10.Text = "Ceci ouvre le dossier Delta, qui inclut l'espace de travail, les patchs de màj et l'éxecution automatique";
			this.header2.Text = "FPS Unlocker";
			this.header_Copy2.Text = "Débloquez vos FPS pour obtenir une expérience Roblox bien meilleure et fluide";
			this.header3.Text = "Arrêter Roblox";
			this.header_Copy3.Text = "Cela ferme tous les processus Roblox en cours";
			this.header4.Text = "Opacité";
			this.header_Copy5.Text = "Rend Delta transparent en réduisant l'opacité de la fenêtre";
			this.header5.Text = "PlusPopulaires";
			this.header_Copy6.Text = "Permet à l'interface utilisateur Delta de rester concentré sur vos autres fenêtres";
			this.header6.Text = "Fondu Automatique";
			this.header_Copy7.Text = "Réduction automatique de l'opacité lorsque le focus de la fenêtre est perdu";
			this.header12.Text = "Application Delta";
			this.header_Copy13.Text = "Utilisez la brillante application Delta au niveau 7 ! (recommandé)";
			this.header13.Text = "Application WRD";
			this.header_Copy14.Text = "Utilisez l'application WeAreDevs (Niveau 7)";
			this.header8.Text = "Injection Automatique";
			this.header_Copy9.Text = "Cela s'injecte automatiquement pour toi à chaque fois que tu lances Roblox !";
			this.header7.Text = "Check de la version";
			this.header_Copy8.Text = "Corrigez la version Roblox si ça ne fonctionne pas (Peut ralentir l'injection)";
			this.header20.Text = "Réinstallez le/les fichier/s DLL";
			this.header_Copy21.Text = "Cette option réinstalle le/les fichier(s) /le module qui éxecute le script";
			this.header21.Text = "Installez les dépendances";
			this.header_Copy22.Text = "Réinstalle VC Redist x64, x86 et DirectX automatiquement";
			this.no_results = "Désolé, nous n'avons pas pu trouver de résultats. :(";
			this.save_text = "Vos paramètres ont été sauvegardés et se chargeront automatiquement la prochaine fois que vous lancerez Delta !";
			this.auto_exec_prompt = "Cela ne peut pas être activé sur Activé/Désactivé parce que Delta éxecute automatiquement tous les fichiers que vous mettez dans le dossier \"autoexec\".\nVoulez-vous ouvrir le dossier \"autoexec\"?";
			this.exec_btn.Content = "ÉXECUTER";
			this.clr_btn.Content = "RETIRER";
			this.opn_btn.Content = "OUVRIR";
			this.sve_btn.Content = "SAUVEGARDER";
			this.inj_btn.Content = "INJECTER";
			this.execute_again_button.Content = "Éxecuter";
			this.browse_lbl.Text = "Parcourir";
			this.hot.Content = "Excellent";
			this.old.Content = "Plus vieux";
			this.mostv.Content = "Plus vus";
			this.FAVS.Content = "Préférés";
			this.desctxt.Text = "Description";
			this.search_scripts_folder_box.Tag = "Filtrer les éléments..";
			this.searchbox.Tag = "Filtrer les éléments..";
			this.allselected.Content = "LES DEUX";
			this.placeholdertext.Text = "Nous avons environ plus de 4000 scripts que vous pouvez rechercher ! Commencez en recherchant :D";
			this.theme_title.Text = "Sélectionnez un thème !";
			this.theme_desc.Text = "Sélectionnez un thème pour commencer ! Vous pouvez l'appliquer en utilisant le bouton \"Utiliser\"";
			this.resettheme.Content = "Réinitialiser";
			this.usetheme.Content = "Utiliser";
			this.homelbl.Text = "ACCUEIL";
			this.scrptslbl.Text = "SCRIPTS";
			this.thmlbl.Text = "THÈMES";
			this.cnfglbl.Text = "CONFIGS";
			this.header_Copy4.Text = "Configuration";
			this.saveset.Content = "Sauvegarder";
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00005CA0 File Offset: 0x00003EA0
		public void thailang()
		{
			this.header1.Text = "รันสคริปอัตโนมัติ";
			this.header_Copy1.Text = "สิ่งนี้จะรันสคริปต์ทั้งหมดที่คุณต้องการโดยอัตโนมัติทุกครั้งที่คุณฉีด";
			this.header9.Text = "เปิดไฟล์ตัวฉีด";
			this.header_Copy10.Text = "เปิดโฟลเดอร์ DLL ของ Delta ซึ่งมีเวิร์กสเปซ บันทึก และโฟลเดอร์ autoexec";
			this.header2.Text = "ปลดล็อค FPS";
			this.header_Copy2.Text = "ปลดล็อกเฟรมต่อวินาทีเพื่อรับประสบการณ์ที่ดียิ่งขึ้นใน Roblox";
			this.header3.Text = "ปิด Roblox";
			this.header_Copy3.Text = "สิ่งนี้จะปิดกระบวนการ Roblox ที่กำลังทำงานอยู่ทั้งหมด";
			this.header4.Text = "โปร่งใส";
			this.header_Copy5.Text = "ทำให้เดลต้าโปร่งใสโดยลดความทึบของหน้าต่าง";
			this.header5.Text = "โฟกัส Delta";
			this.header_Copy6.Text = "ทำให้ Delta โฟกัสอยู่ที่ด้านบนของหน้าต่างอื่นๆ ของคุณ";
			this.header6.Text = "ล่องหนอัตโนมัติ";
			this.header_Copy7.Text = "ลดความทึบโดยอัตโนมัติเมื่อโฟกัสของหน้าต่างหายไป ( ควรใช้กับ โฟกัส Delta )";
			this.header12.Text = "ฉีดแบบ Delta";
			this.header_Copy13.Text = "ใช้ตัวฉีดแบบ Delta ระดับ 7 อันทรงพลัง (แนะนำ)";
			this.header13.Text = "ฉีดแบบ WRD";
			this.header_Copy14.Text = "ใช้ตัวฉีดแบบ WRD (ระดับ 7)";
			this.header8.Text = "ฉีดอัตโนมัติ";
			this.header_Copy9.Text = "สิ่งนี้จะฉีดให้คุณโดยอัตโนมัติทุกครั้งที่คุณเปิด Roblox";
			this.header7.Text = "ตรวจสอบรุ่น";
			this.header_Copy8.Text = "แก้ไขเวอร์ชั่น roblox หากผิด (อาจทำให้การฉีดช้า)";
			this.header20.Text = "ดาวน์โหลดฉีดแบบ Delta ใหม่";
			this.header_Copy21.Text = "ตัวเลือกนี้จะติดตั้ง DLL ของ Delta ใหม่ซึ่งเรียกใช้สคริปต์";
			this.header21.Text = "ดาวน์โหลดตัวพึ่งพา";
			this.header_Copy22.Text = "ติดตั้ง VC Redist x64, x86 และ DirectX ใหม่โดยอัตโนมัติ";
			this.no_results = "พวกเราไม่สามารถหาสคริปได้ :(";
			this.save_text = "การตั้งค่าของคุณได้รับการบันทึกแล้ว และจะโหลดโดยอัตโนมัติในครั้งถัดไปที่คุณเปิดใช้ Delta!";
			this.auto_exec_prompt = "ไม่สามารถเปิด/ปิดได้เนื่องจาก Delta เรียกใช้ไฟล์ทั้งหมดที่คุณใส่ในโฟลเดอร์ \"autoexec\" โดยอัตโนมัติ\nคุณต้องการเปิดโฟลเดอร์ \"autoexec\" หรือไม่";
			this.exec_btn.Content = "รันสคริป";
			this.clr_btn.Content = "ลบ";
			this.opn_btn.Content = "เปิดสคริป";
			this.sve_btn.Content = "บันทึกสคริป";
			this.inj_btn.Content = "ฉีด";
			this.execute_again_button.Content = "รันสคริป";
			this.browse_lbl.Text = "ค้นหา";
			this.hot.Content = "มาแรง";
			this.old.Content = "เก่าที่สุด";
			this.mostv.Content = "ดูมากที่สุด";
			this.FAVS.Content = "ชอบ";
			this.desctxt.Text = "คำอธิบาย";
			this.search_scripts_folder_box.Tag = "หาสคริป";
			this.searchbox.Tag = "หาสคริป";
			this.allselected.Content = "ทุกไฟล์";
			this.placeholdertext.Text = "เรามีสคริปมากกว่า 4,000 รายการที่คุณสามารถค้นหาได้! เริ่มต้นด้วยการค้นหา :D";
			this.theme_title.Text = "เลือกธีม!";
			this.theme_desc.Text = "เลือกธีมในแปปของคุณ! โดยใช้ปุ่ม ใช้ธีม";
			this.resettheme.Content = "ลบธีม";
			this.usetheme.Content = "ใช้ธีม";
			this.homelbl.Text = "ตัวรัน";
			this.scrptslbl.Text = "หาสคริป";
			this.thmlbl.Text = "ธีม";
			this.cnfglbl.Text = "ตั้งค่า";
			this.header_Copy4.Text = "กำหนดค่า";
			this.saveset.Content = "บันทึกการตั้งค่า";
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00006010 File Offset: 0x00004210
		public void polishlang()
		{
			this.header1.Text = "Automatycznie Uzywanie Skryptów";
			this.header_Copy1.Text = "To automatycznie uzywa wszystkie skrypty ktore chcesz uzywać gdy wstrzykujesz lub zmieniasz serwery";
			this.header9.Text = "Włacz Folder DLL";
			this.header_Copy10.Text = "To Włacza Folder Delta DLL, to obejmuje obszar roboczy, logi i folder autoexec ";
			this.header2.Text = "Odblokuj Klatki Na sekundę";
			this.header_Copy2.Text = "Odblokuj swoje klatki na sekundę, aby uzyskać znacznie lepsze wrażenia z Roblox";
			this.header3.Text = "Zabij Roblox";
			this.header_Copy3.Text = "Zabija/Wylacza wszystkie processy robloxa";
			this.header4.Text = "Przezroczystość";
			this.header_Copy5.Text = "Sprawia że ​​Delta staje się przezroczysta zmniejszając przezroczystość okna";
			this.header5.Text = "Nad Oknami";
			this.header_Copy6.Text = "Sprawia, że ​​interfejs Delta pozostaje skupiony na innych oknach";
			this.header6.Text = "Automatyczne zanikanie";
			this.header_Copy7.Text = "Automatycznie zmniejszaj krycie po utracie ostrości okna";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Użyj potężnego interfejsu Delta poziomu 7 (zalecane)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "Użyj API WeAreDevs (poziom 7)";
			this.header8.Text = "Automatyczny Wstrzyk";
			this.header_Copy9.Text = "To automatycznie wstrzykuje ci za każdym razem, gdy otwierasz roblox";
			this.header7.Text = "Sprawdzanie wersji";
			this.header_Copy8.Text = "Poprawia wersję roblox, jeśli jest zła (może spowolnić wtrysk)";
			this.header20.Text = "Ponownie zainstaluj bibliotekę DLL";
			this.header_Copy21.Text = "Ta opcja powoduje ponowną instalację biblioteki DLL lub modułu Delta, który uruchamia skrypty";
			this.header21.Text = "Zainstaluj zależności";
			this.header_Copy22.Text = "Ponownie zainstaluj automatycznie VC Redist x64, x86 i DirectX";
			this.no_results = "Przepraszamy, nie znaleźliśmy żadnych wyników :(";
			this.save_text = "Twoje ustawienia zostały zapisane i zostaną automatycznie załadowane przy następnym uruchomieniu Delta!";
			this.auto_exec_prompt = "TNie można tego włączyć/wyłączyć, ponieważ Delta automatycznie uruchamia wszystkie pliki, które umieściłeś w folderze \"autoexec\".\nCzy chcesz otworzyć folder \"autoexec\"?";
			this.exec_btn.Content = "WYKONAĆ";
			this.clr_btn.Content = "WYCZYŚĆ";
			this.opn_btn.Content = "WŁĄCZ";
			this.sve_btn.Content = "ZAPISZ";
			this.inj_btn.Content = "WSTRZYKNIJ";
			this.execute_again_button.Content = "Wykonać";
			this.browse_lbl.Text = "Przeglądaj";
			this.hot.Content = "Gorące";
			this.old.Content = "Najstarszy";
			this.mostv.Content = "Najczęściej oglądane";
			this.FAVS.Content = "Ulubione";
			this.desctxt.Text = "Opis";
			this.search_scripts_folder_box.Tag = "Filtruj elementy..";
			this.searchbox.Tag = "Filtruj elementy..";
			this.allselected.Content = "WSZYSTKIE PLIKI";
			this.placeholdertext.Text = "Mamy ponad 4000 skryptów, które możesz wyszukać! Zacznij od szukania :D";
			this.theme_title.Text = "Wybierz motyw!";
			this.theme_desc.Text = "Wybierz motyw, aby rozpocząć! Zastosuj go za pomocą przycisku \"Użyj motywu\"";
			this.resettheme.Content = "Zresetuj motyw";
			this.usetheme.Content = "Uzyj Motyw";
			this.homelbl.Text = "DOM";
			this.scrptslbl.Text = "SKRYPTY";
			this.thmlbl.Text = "MOTYWY";
			this.cnfglbl.Text = "KONFIG";
			this.header_Copy4.Text = "Konfiguracja";
			this.saveset.Content = "Zapisz Ustawienia";
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00006380 File Offset: 0x00004580
		public void filipinolang()
		{
			this.header1.Text = "Auto Execute";
			this.header_Copy1.Text = "Awtomatiko nitong pinapagana ang lahat ng mga script na gusto mo sa tuwing mag-inject ka/serverhop";
			this.header9.Text = "Open ang DLL Folder";
			this.header_Copy10.Text = "Magopen Delta's DLL Folder, kasama ang workspace, logs at autoexec folder";
			this.header2.Text = "FPS Unlocker";
			this.header_Copy2.Text = "I-unlock ang iyong mga frame sa bawat segundo para makakuha ng mas pinahusay na karanasan sa Roblox";
			this.header3.Text = "Kill Roblox";
			this.header_Copy3.Text = "ito ay nagsasarado lahat nangyayari na Roblox processes";
			this.header4.Text = "Opacity";
			this.header_Copy5.Text = "Ginagawang transparent ang Delta sa pamamagitan ng pagpapababa sa opacity ng window";
			this.header5.Text = "TopMost";
			this.header_Copy6.Text = "Ginagawang manatiling nakatutok ang Delta UI sa itaas ng iyong iba pang mga windows";
			this.header6.Text = "Auto Fade";
			this.header_Copy7.Text = "Awtomatikong babaan ang opacity kapag nawala ang focus sa window";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "gamitin ang malakas na level 7 Delta API (recomended)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "Gamitin ang WeAreDevs API (level 7)";
			this.header8.Text = "Auto Inject";
			this.header_Copy9.Text = "Awtomatikong nag-iinject ito para sa iyo sa tuwing bubuksan mo ang roblox";
			this.header7.Text = "pagsusuri ng bersyon";
			this.header_Copy8.Text = "Itinatama ang bersyon ng roblox kung mali ito (pwede bumagal ang injection)";
			this.header20.Text = "muling i-install ang dll";
			this.header_Copy21.Text = "Ang pagpipiliang ito ay muling nag-install ng Delta DLL/Module ng Delta na nagpapatakbo ng mga script";
			this.header21.Text = "I-install ang Dependencies";
			this.header_Copy22.Text = "I-install muli VC Redist x64, x86 at DirectX automatically";
			this.no_results = "Paumanhin, wala kaming mahanap na anumang resulta :(";
			this.save_text = "ang mga settings mo ay na save at awtomatikong maglo-load sa susunod na ilunsad mo ang Delta!";
			this.auto_exec_prompt = "Hindi ito kaya i on/off dahil Delta nag awtomatikong ipapatupad lahat ng files na nilagay sa\"autoexec\" folder.\nGusto mo ba i buksan ang \"autoexec\" folder?";
			this.exec_btn.Content = "BUMITAY";
			this.clr_btn.Content = "TANGGALIN";
			this.opn_btn.Content = "BUKSAN";
			this.sve_btn.Content = "ILIGTAS";
			this.inj_btn.Content = "INJECTO";
			this.execute_again_button.Content = "Bumitay";
			this.browse_lbl.Text = "Paghahanap";
			this.hot.Content = "Sikat";
			this.old.Content = "Matanda";
			this.mostv.Content = "Pinaka viewed";
			this.FAVS.Content = "Paborito";
			this.desctxt.Text = "Paglalarawan";
			this.search_scripts_folder_box.Tag = "ifilter ang mga gamit..";
			this.searchbox.Tag = "ifilter ang mga gamit..";
			this.allselected.Content = "Lahat ng FILES";
			this.placeholdertext.Text = "Meron kaming lagpas na 4000+ skripts na kaya mo i gamitin ! magsimula sa pamamagitan ng paghahanap :D";
			this.theme_title.Text = "Pumili ng Tema!";
			this.theme_desc.Text = "Mag select ng theme para mag start! gamitin mo ito gamit ang \"Gamitin\" pindutan";
			this.resettheme.Content = "Reset Tema";
			this.usetheme.Content = "Gamitin";
			this.homelbl.Text = "HOME";
			this.scrptslbl.Text = "SKRIPTS";
			this.thmlbl.Text = "TEMAS";
			this.cnfglbl.Text = "CONFIG";
			this.header_Copy4.Text = "pagsasaayos";
			this.saveset.Content = "i-save ang mga setting";
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000066F0 File Offset: 0x000048F0
		public void germanlang()
		{
			this.header1.Text = "Auto Execute";
			this.header_Copy1.Text = "Diese Einstellung führt alle skripte beim injecten oder serverhoppen aus";
			this.header9.Text = "DLL Ordner öffnen";
			this.header_Copy10.Text = "Öffnet Delta's DLL Order, wo der workspace, logs und autoexec ordner ist";
			this.header2.Text = "FPS Entsperrer";
			this.header_Copy2.Text = "Entsperrt deine FPS, um Roblox viel besser zu erleben";
			this.header3.Text = "Schliesse Roblox";
			this.header_Copy3.Text = "Beendet/Schließt alle derzeit laufenden Roblox-Prozesse";
			this.header4.Text = "Transparenz";
			this.header_Copy5.Text = "Macht Delta durchsichtig bzw. Transparent";
			this.header5.Text = "TopMost";
			this.header_Copy6.Text = "Lässt die Delta-Benutzeroberfläche über Ihren anderen Fenstern fokussiert bleiben";
			this.header6.Text = "Auto Fade";
			this.header_Copy7.Text = "Verringert die Deckkraft automatisch, wenn ein anderes Fenster fokussiert wird";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Verwende die leistungsfähige Level-7-Delta-API (empfohlen)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "Verwende die WeAreDevs API (level 7)";
			this.header8.Text = "Auto Inject";
			this.header_Copy9.Text = "Injected Delta automatisch, wenn roblox geöffnet wird";
			this.header7.Text = "Versions Kontrolle";
			this.header_Copy8.Text = "Korrigiert die Roblox-Version, wenn sie falsch ist (könnte die Injection verlangsamen)";
			this.header20.Text = "Reinstall DLL";
			this.header_Copy21.Text = "Diese Option installiert Deltas DLL/Modul, das Skripte ausführt, nochmal";
			this.header21.Text = "Install Dependencies";
			this.header_Copy22.Text = "Installieren Sie VC Redist x64, x86 und DirectX automatisch neu";
			this.no_results = "Sorry, wir konnten keine Ergebnisse finden :(";
			this.save_text = "Die Einstellungen wurden gespeichert und werden automatisch geladen, wenn Delta das nächste Mal geöffnet wird!";
			this.auto_exec_prompt = "Das kann nicht ein-/ausgeschaltet werden, weil Delta automatisch alle Dateien ausführt, die im Ordner \"autoexec\" abgelegt sind.\nSoll der Ordner \"autoexec\" geöffnet werden?";
			this.exec_btn.Content = "AUSFÜHREN";
			this.clr_btn.Content = "LÖSCHEN";
			this.opn_btn.Content = "ÖFFNEN";
			this.sve_btn.Content = "SPEICHERN";
			this.inj_btn.Content = "INJECT";
			this.execute_again_button.Content = "Ausführen";
			this.browse_lbl.Text = "Suchen";
			this.hot.Content = "Im Trend";
			this.old.Content = "Älteste";
			this.mostv.Content = "Meiste Aufrufe";
			this.FAVS.Content = "Favoriten";
			this.desctxt.Text = "Beschreibung";
			this.search_scripts_folder_box.Tag = "Im Ordner suchen..";
			this.searchbox.Tag = "Skripte suchen..";
			this.allselected.Content = "ALLE [ * ]";
			this.placeholdertext.Text = "Delta hat über 4.000 Skripte nach denen du suchen kannst! Probier's doch aus :D";
			this.theme_title.Text = "Wähle ein Design aus!";
			this.theme_desc.Text = "Wähle ein Design aus! Du kannst es mit dem \"Verwenden\" Knopf benutzen!";
			this.resettheme.Content = "Standard";
			this.usetheme.Content = "Verwenden";
			this.homelbl.Text = "START";
			this.scrptslbl.Text = "SKRIPTE";
			this.thmlbl.Text = "DESIGNS";
			this.cnfglbl.Text = "KONFIG";
			this.header_Copy4.Text = "Einstellungen";
			this.saveset.Content = "Speichern";
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00006A60 File Offset: 0x00004C60
		public void turkishlang()
		{
			this.header1.Text = "Otomatik Yürüt";
			this.header_Copy1.Text = "Bu, her enjekte ettiğinizde/serverhop yaptığınızda istediğiniz tüm komut dosyalarını otomatik olarak yürütür";
			this.header9.Text = "DLL Klasörünü Aç";
			this.header_Copy10.Text = "Bu, çalışma alanını, günlükleri ve autoexec klasörünü içeren Delta'nın DLL Klasörünü açar";
			this.header2.Text = "FPS Kilidi Açıcı";
			this.header_Copy2.Text = "Roblox'ta çok daha gelişmiş bir deneyim elde etmek için saniyedeki karelerinizin kilidini açın";
			this.header3.Text = "Roblox'u Öldür";
			this.header_Copy3.Text = "Bu, şu anda çalışan tüm Roblox işlemlerini öldürür/kapatır";
			this.header4.Text = "Opaklık";
			this.header_Copy5.Text = "Pencere opaklığını düşürerek Delta'yı şeffaf yapar";
			this.header5.Text = "TopMost";
			this.header_Copy6.Text = "Delta Kullanıcı Arayüzünün diğer pencerelerinizin üzerinde odaklanmış durumda kalmasını sağlar";
			this.header6.Text = "Otomatik Solma";
			this.header_Copy7.Text = "Pencere odağı kaybolduğunda opaklığı otomatik olarak azalt";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Güçlü seviye 7 Delta API'sini kullanın (önerilir)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "WeAreDevs API'sini kullanın (seviye 7)";
			this.header8.Text = "Otomatik Enjeksiyon";
			this.header_Copy9.Text = "Bu, roblox'u her açtığınızda sizin için otomatik olarak enjekte eder";
			this.header7.Text = "Sürüm Kontrolü";
			this.header_Copy8.Text = "Yanlış ise roblox sürümünü düzeltir (Enjeksiyon yavaşlayabilir)";
			this.header20.Text = "DLL'yi Yeniden Yükle";
			this.header_Copy21.Text = "Bu seçenek, Delta'nın komut dosyalarını çalıştıran DLL/Modülünü yeniden yükler";
			this.header21.Text = "Bağımlılıkları Kur";
			this.header_Copy22.Text = "VC Redist x64, x86 ve DirectX'i otomatik olarak yeniden kurun";
			this.no_results = "Üzgünüz, herhangi bir sonuç bulamadık :(";
			this.save_text = "Ayarlarınız kaydedildi ve Delta'yı bir sonraki başlatışınızda otomatik olarak yüklenecek!";
			this.auto_exec_prompt = "Delta, \"autoexec\" klasörüne koyduğunuz tüm dosyaları otomatik olarak yürüttüğü için bu açılamaz/kapatılamaz.\n\"autoexec\" klasörünü açmak istiyor musunuz";
			this.exec_btn.Content = "YÜRÜT";
			this.clr_btn.Content = "SİL";
			this.opn_btn.Content = "AÇIK";
			this.sve_btn.Content = "KAYDET";
			this.inj_btn.Content = "ENJEKT";
			this.execute_again_button.Content = "Yürüt";
			this.browse_lbl.Text = "Gözt";
			this.hot.Content = "Sıcak";
			this.old.Content = "En Eski";
			this.mostv.Content = "En Çok Görüntülenen";
			this.FAVS.Content = "Favoriler";
			this.desctxt.Text = "Açıklama";
			this.search_scripts_folder_box.Tag = "Öğeleri Filtrele..";
			this.searchbox.Tag = "Öğeleri Filtrele..";
			this.allselected.Content = "TÜM DOSYALAR";
			this.placeholdertext.Text = "Arayabileceğiniz 4.000'den fazla Komut Dosyamız var! Bir arama yaparak başlayın :D";
			this.theme_title.Text = "Bir Tema Seçin!";
			this.theme_desc.Text = "Başlamak için bir Tema seçin! \"Temayı Kullan\" Düğmesini kullanarak uygulayın";
			this.resettheme.Content = "Temayı Sıfırla";
			this.usetheme.Content = "Temayı Kullan";
			this.homelbl.Text = "GİRİŞ";
			this.scrptslbl.Text = "SCRIPTS";
			this.thmlbl.Text = "TEMALAR";
			this.cnfglbl.Text = "KONFİG";
			this.header_Copy4.Text = "Yapılandırma";
			this.saveset.Content = "Ayarları Kaydet";
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00006DD0 File Offset: 0x00004FD0
		public void spanishlang()
		{
			this.header1.Text = "Ejecutado Automatico";
			this.header_Copy1.Text = "Automaticamente ejecuta todos los scripts que quieres cada vez que inyectas/cambias de servidor";
			this.header9.Text = "Abrir La Carpeta De DLL";
			this.header_Copy10.Text = "Abre la carpeta de DLL de Delta, incluye las carpetas de workspace, logs y autoejecutado";
			this.header2.Text = "FPS Unlocker";
			this.header_Copy2.Text = "Desbloquea los cuadros por segundo para una experiencia mejorada en Roblox";
			this.header3.Text = "Cerrar Roblox";
			this.header_Copy3.Text = "Cierra todos los procesos relacionados con Roblox";
			this.header4.Text = "Opacidad";
			this.header_Copy5.Text = "Hace que Delta sea transparente disminuyendo la opacidad de la ventana.+";
			this.header5.Text = "TopMost";
			this.header_Copy6.Text = "Hace que la IU de Delta se mantenga encima de todas las ventanas";
			this.header6.Text = "Auto Fade";
			this.header_Copy7.Text = "Automaticamente disminuye la opacidad de la ventana si no la estas usando";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Usa la poderosa API Delta nivel 7 (recomendado)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "Usa la API WeAreDevs (nivel 7)";
			this.header8.Text = "Inyectado Automatico";
			this.header_Copy9.Text = "Automaticamente inyecta Delta cuando abres Roblox";
			this.header7.Text = "Verificacion De Version";
			this.header_Copy8.Text = "Corrige la version de Roblox si es incorrecta (Puede causar lentitud al inyectar)";
			this.header20.Text = "Reinstalar DLL";
			this.header_Copy21.Text = "Esta opcion reinstala el modulo/dll de Delta el cual ejecuta scripts.";
			this.header21.Text = "Instalar Dependencias";
			this.header_Copy22.Text = "Reinstalar VC Redist x64, x86 y DirectX automaticamente";
			this.no_results = "Lo sentimos, no podimos encontrar ningun resultado :C";
			this.save_text = "!Tu configuracion fue guardada y se aplicara cuando abras Delta de nuevo¡";
			this.auto_exec_prompt = "Esto no puede ser habilitado/desabilitado porque Delta automaticamente ejecuta todos los archivos que colocas en la carpeta \"autoexec\" .\n¿Quieres abrir el \"autoexec\" folder?";
			this.exec_btn.Content = "EJECUTAR";
			this.clr_btn.Content = "BORRAR";
			this.opn_btn.Content = "ABRIR";
			this.sve_btn.Content = "GUARDAR";
			this.inj_btn.Content = "INYECTAR";
			this.execute_again_button.Content = "Ejecutar";
			this.browse_lbl.Text = "Navegar";
			this.hot.Content = "Tendencia";
			this.old.Content = "Antiguo";
			this.mostv.Content = "Mas Visitado";
			this.FAVS.Content = "Favoritos";
			this.desctxt.Text = "Descripcion";
			this.search_scripts_folder_box.Tag = "Filtrar elementos..";
			this.searchbox.Tag = "Filtrar elementos..";
			this.allselected.Content = "TODOS LOS ARCHIVOS";
			this.placeholdertext.Text = "¡Tenemos mas de 4000+ scripts que puedes buscar! Intenta hacer una busqueda :D";
			this.theme_title.Text = "¡Elige un tema!";
			this.theme_desc.Text = "¡Elige un tema para empezar! Aplicalo usando el boton \"Usar Tema\"";
			this.resettheme.Content = "Tema Predeterminado";
			this.usetheme.Content = "Usar Tema";
			this.homelbl.Text = "INICIO";
			this.scrptslbl.Text = "SCRIPTS";
			this.thmlbl.Text = "TEMAS";
			this.cnfglbl.Text = "AJUSTES";
			this.header_Copy4.Text = "Ajustes";
			this.saveset.Content = "Guardar Ajustes";
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00007140 File Offset: 0x00005340
		public void indonesianlang()
		{
			this.header1.Text = "Otomatis Jalankan";
			this.header_Copy1.Text = "Ini akan otomatis mengjalankan semua script yang kamu mau setiap kamu menginjeksi atau melakukan server hop(berpindah server)";
			this.header9.Text = "Buka Folder DLL";
			this.header_Copy10.Text = "Ini Akan Membuka folder DLL Delta , yang meliputi workspace, logs(histori) dan Folder Otomatis Jalankan ";
			this.header2.Text = "Membuka FPS";
			this.header_Copy2.Text = "Ini Akan membuka fps kamu agar kamu mendapatkan pengalaman yang lebih baik dan berkualitas di roblox";
			this.header3.Text = "Tutup Roblox";
			this.header_Copy3.Text = "Ini Akan menutup semua proses roblox yang sedang berjalan";
			this.header4.Text = "Opasitas";
			this.header_Copy5.Text = "Ini Akan membuat delta transparan dengan menurunkan opasitas window kamu";
			this.header5.Text = "Paling Atas";
			this.header_Copy6.Text = "Ini Akan membuat UI Delta tetap berada di paling depan/atas diantara windows yang lain";
			this.header6.Text = "Pudar Otomatis";
			this.header_Copy7.Text = "Ini Akan Membuat Delta otomatis menurunkan opasitas saat pengguna melihat windows lain";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Gunakan Level 7 Delta APi Yang Kuat(Rekomendasi)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "Gunakan WeAreDevs APi (Level 7)";
			this.header8.Text = "Otomatis Injeksi";
			this.header_Copy9.Text = "Ini Akan Membuat Delta Otomatis Menginjeksi untuk kamu setiap kamu membuka roblox";
			this.header7.Text = "Pemeriksa Versi";
			this.header_Copy8.Text = "Memperbaiki versi roblox jika versi tersebut salah (bisa memperlambat injeksi)";
			this.header20.Text = "Instal Ulang DLL";
			this.header_Copy21.Text = "Opsi Ini akan menginstal ulang Dll/Modul yang fungsinya menjalankan script";
			this.header21.Text = "Instal Dependencies";
			this.header_Copy22.Text = "Menginstal Ulang VC Redist x64, x86 dan DirectX Secara Otomatis";
			this.no_results = "Maaf, Kita Tidak Bisa Menemukan Apapun :(";
			this.save_text = "Pengaturan Anda Telah Disimpan Telah Disimpan Dan Akan Dimuat Secara Otomatis Saat Anda Membuka Delta Lagi!";
			this.auto_exec_prompt = "Ini Tidak Bisa Dinyalakan/Dimatikan karena Delta Secara Otomatis Menjalankan Semua File/Script Yang Anda masukan ke dalam folder \"otomatisjalankan\" .\nApakah Kamu Mau Membuka \"otomatisjalankan\" folder?";
			this.exec_btn.Content = "JALANKAN";
			this.clr_btn.Content = "BERSIHKAN";
			this.opn_btn.Content = "BUKA";
			this.sve_btn.Content = "SIMPAN";
			this.inj_btn.Content = "INJEKSI";
			this.execute_again_button.Content = "Jalankan";
			this.browse_lbl.Text = "Cari";
			this.hot.Content = "Populer";
			this.old.Content = "Paling Tua";
			this.mostv.Content = "Paling Banyak Dilihat";
			this.FAVS.Content = "Favorit";
			this.desctxt.Text = "Deskripsi";
			this.search_scripts_folder_box.Tag = "Sortir Item..";
			this.searchbox.Tag = "Sortir Items..";
			this.allselected.Content = "SEMUA FILE";
			this.placeholdertext.Text = "Kami Memiliki Lebih Dari 4.000+ Skrip Yang Anda Dapat Cari! Mulailah Dengan Melakukan Pencarian :D";
			this.theme_title.Text = "Select a Theme!";
			this.theme_desc.Text = "Pilih Tema Untuk Mulai! Terapkan Dengan \"Gunakan\" Tombol";
			this.resettheme.Content = "Ulang Tema";
			this.usetheme.Content = "Gunakan";
			this.homelbl.Text = "RUMAH";
			this.scrptslbl.Text = "SKRIP";
			this.thmlbl.Text = "TEMA";
			this.cnfglbl.Text = "KONFIG";
			this.header_Copy4.Text = "Konfigurasi";
			this.saveset.Content = "Simpan";
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000074B0 File Offset: 0x000056B0
		public void portlang()
		{
			this.header1.Text = "Auto execucao";
			this.header_Copy1.Text = "Isso vai executar automaticamente todos os scripts que voce quer toda vez que voce injetar/trocar de server";
			this.header9.Text = "Abrir DLL Folder";
			this.header_Copy10.Text = "Isso abre o Delta DLL Folder, isso inclui a area de trabalho, historico e a pasta de auto execucao ";
			this.header2.Text = "Desbloqueador de FSP";
			this.header_Copy2.Text = "Desbloqueia os frames por segundo para obter uma experiencia muito mais aprimorada no Roblox";
			this.header3.Text = "Kill Roblox";
			this.header_Copy3.Text = "Isso mata/fecha todos os roblox em processo";
			this.header4.Text = "Opacidade";
			this.header_Copy5.Text = "Torna o delta transparente ao baixar a opacidade da janela";
			this.header5.Text = "Acima";
			this.header_Copy6.Text = "Faz a UI do Delta continuar acima das outras janelas";
			this.header6.Text = "Auto Fade";
			this.header_Copy7.Text = "diminui a opacidade automaticamente quando a janela esta sem foco";
			this.header12.Text = "Delta API";
			this.header_Copy13.Text = "Usa o poderoso level 7 Delta API (recommended)";
			this.header13.Text = "WRD API";
			this.header_Copy14.Text = "Usa o WeAreDevs API (level 7)";
			this.header8.Text = "Injetar automaticamente";
			this.header_Copy9.Text = "Isso injeta automaticamente para voce toda vez que voce abrir o roblox";
			this.header7.Text = "Checando versao";
			this.header_Copy8.Text = "Corrige a vers?o do roblox se estiver errada (PODE desacelerar a injetar)";
			this.header20.Text = "Reinstala DLL";
			this.header_Copy21.Text = "Essa opcao reinstala a DLL/Modulo do Delta que executar os scripts";
			this.header21.Text = "Instala dependencias";
			this.header_Copy22.Text = "Reinstala VC Redist x64, x86 e o DirectX automaticamente";
			this.no_results = "Desculpa, nos nao encontramos nenhum resultado :(";
			this.save_text = "As configuracoes sao salvas e sao automaticamente carregadas quando voce abre o Delta!";
			this.auto_exec_prompt = "Isso nao pode ser ligado/desligado porque o Delta automaticamente executa todos os arquivos que voce coloca em \"autoexec\" folder.\nDo voce quer abrir a pasta \"autoexec\" ?";
			this.exec_btn.Content = "EXECUTAR";
			this.clr_btn.Content = "LIMPAR";
			this.opn_btn.Content = "ABRIR";
			this.sve_btn.Content = "SALVAR";
			this.inj_btn.Content = "INJETAR";
			this.execute_again_button.Content = "Executar";
			this.browse_lbl.Text = "Navegar";
			this.hot.Content = "Tendendo";
			this.old.Content = "Antigo";
			this.mostv.Content = "Mais visto";
			this.FAVS.Content = "Favoritos";
			this.desctxt.Text = "Descricao";
			this.search_scripts_folder_box.Tag = "Filtrar Itens..";
			this.searchbox.Tag = "Filtrar Itens..";
			this.allselected.Content = "TODOS OS ARQUIVOS";
			this.placeholdertext.Text = "Nos temos mais de 4,000+ Scripts that voce pode pesquisar! Comece fazendo uma pesquisa :D";
			this.theme_title.Text = "Selecione um Tema!";
			this.theme_desc.Text = "Selecione um tema para comecar! Aplique-o clicando no botao \"Use Theme\" ";
			this.resettheme.Content = "Resetar Tema";
			this.usetheme.Content = "Usar Tema";
			this.homelbl.Text = "INICIO";
			this.scrptslbl.Text = "SCRIPTS";
			this.thmlbl.Text = "TEMAS";
			this.cnfglbl.Text = "CONFIG";
			this.header_Copy4.Text = "Configuracao";
			this.saveset.Content = "Salvar config";
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000265B File Offset: 0x0000085B
		private void dispatcherTimer1_Tick(object sender, EventArgs e)
		{
			if (DLLPipe.NamedPipeExist())
			{
				this.DT1.Stop();
				this.DT.Start();
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00007820 File Offset: 0x00005A20
		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			XWindow.<dispatcherTimer_Tick>d__70 <dispatcherTimer_Tick>d__;
			<dispatcherTimer_Tick>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<dispatcherTimer_Tick>d__.<>4__this = this;
			<dispatcherTimer_Tick>d__.<>1__state = -1;
			<dispatcherTimer_Tick>d__.<>t__builder.Start<XWindow.<dispatcherTimer_Tick>d__70>(ref <dispatcherTimer_Tick>d__);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000267A File Offset: 0x0000087A
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.create_a_new_tab("NewScript.lua", "");
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000268C File Offset: 0x0000088C
		private void button_Click_1(object sender, RoutedEventArgs e)
		{
			if (this.tabControl1.Items.Count != 1)
			{
				this.tabControl1.Items.Remove(this.tabControl1.SelectedItem);
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000026BC File Offset: 0x000008BC
		private void allselected_Checked(object sender, RoutedEventArgs e)
		{
			this.luaselected.IsChecked = new bool?(false);
			this.txtselected.IsChecked = new bool?(false);
			this.refresh_scriptbox("");
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000026EB File Offset: 0x000008EB
		private void luaselected_Checked(object sender, RoutedEventArgs e)
		{
			this.allselected.IsChecked = new bool?(false);
			this.txtselected.IsChecked = new bool?(false);
			this.refresh_scriptbox("");
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000271A File Offset: 0x0000091A
		private void txtselected_Checked(object sender, RoutedEventArgs e)
		{
			this.luaselected.IsChecked = new bool?(false);
			this.allselected.IsChecked = new bool?(false);
			this.refresh_scriptbox("");
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00007858 File Offset: 0x00005A58
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				base.DragMove();
			}
			catch
			{
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002749 File Offset: 0x00000949
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.refresh_scriptbox(this.search_scripts_folder_box.Text);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000275C File Offset: 0x0000095C
		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			this.SetText(string.Empty);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00007880 File Offset: 0x00005A80
		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Delta | " + this.opn_btn.Content.ToString().Substring(0, 1) + this.opn_btn.Content.ToString().Substring(1).ToLower();
			openFileDialog.Filter = "Text Files|*.txt|Lua Files|*.lua|All Files|*.*";
			if (openFileDialog.ShowDialog().Value)
			{
				this.create_a_new_tab(openFileDialog.SafeFileName, "");
				this.SetText(File.ReadAllText(openFileDialog.FileName));
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00007914 File Offset: 0x00005B14
		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = ((this.GetCurrentTab().Header as TextBox).Text ?? "");
			saveFileDialog.Title = "Delta | " + this.sve_btn.Content.ToString().Substring(0, 1) + this.sve_btn.Content.ToString().Substring(1).ToLower();
			saveFileDialog.Filter = "Text Files|*.txt|Lua Files|*.lua|All Files|*.*";
			if (saveFileDialog.ShowDialog().Value)
			{
				File.WriteAllText(saveFileDialog.FileName, this.GetText());
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000079BC File Offset: 0x00005BBC
		private void autoexec_Checked(object sender, RoutedEventArgs e)
		{
			XWindow.<autoexec_Checked>d__81 <autoexec_Checked>d__;
			<autoexec_Checked>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<autoexec_Checked>d__.<>4__this = this;
			<autoexec_Checked>d__.<>1__state = -1;
			<autoexec_Checked>d__.<>t__builder.Start<XWindow.<autoexec_Checked>d__81>(ref <autoexec_Checked>d__);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00002769 File Offset: 0x00000969
		private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
		{
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000079F4 File Offset: 0x00005BF4
		private void autoupdate_Copy_Checked(object sender, RoutedEventArgs e)
		{
			if (!File.Exists("./bin\\fpsunlocker.exe"))
			{
				using (WebClient webClient = new WebClient
				{
					Proxy = null
				})
				{
					webClient.DownloadFile("https://cdn.discordapp.com/attachments/1041093775671435335/1048686669634752512/rbxfpsunlocker.exe", "./bin\\fpsunlocker.exe");
				}
			}
			Process.Start("./bin\\fpsunlocker.exe");
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00007A54 File Offset: 0x00005C54
		private void autoupdate_Copy_Unchecked(object sender, RoutedEventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("fpsunlocker");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00007A84 File Offset: 0x00005C84
		private void autoexec_Copy_Checked(object sender, RoutedEventArgs e)
		{
			XWindow.<autoexec_Copy_Checked>d__85 <autoexec_Copy_Checked>d__;
			<autoexec_Copy_Checked>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<autoexec_Copy_Checked>d__.<>4__this = this;
			<autoexec_Copy_Checked>d__.<>1__state = -1;
			<autoexec_Copy_Checked>d__.<>t__builder.Start<XWindow.<autoexec_Copy_Checked>d__85>(ref <autoexec_Copy_Checked>d__);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00007ABC File Offset: 0x00005CBC
		private void autoupdate5_Checked(object sender, RoutedEventArgs e)
		{
			XWindow.<autoupdate5_Checked>d__86 <autoupdate5_Checked>d__;
			<autoupdate5_Checked>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<autoupdate5_Checked>d__.<>4__this = this;
			<autoupdate5_Checked>d__.<>1__state = -1;
			<autoupdate5_Checked>d__.<>t__builder.Start<XWindow.<autoupdate5_Checked>d__86>(ref <autoupdate5_Checked>d__);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00007AF4 File Offset: 0x00005CF4
		private void autoexec5_Checked(object sender, RoutedEventArgs e)
		{
			XWindow.<autoexec5_Checked>d__87 <autoexec5_Checked>d__;
			<autoexec5_Checked>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<autoexec5_Checked>d__.<>4__this = this;
			<autoexec5_Checked>d__.<>1__state = -1;
			<autoexec5_Checked>d__.<>t__builder.Start<XWindow.<autoexec5_Checked>d__87>(ref <autoexec5_Checked>d__);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00007B2C File Offset: 0x00005D2C
		private void Window_Activated(object sender, EventArgs e)
		{
			if (this.autofade.IsChecked.Value)
			{
				this.opacityanim(this.mwyes, base.Opacity, 1.0);
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00007B6C File Offset: 0x00005D6C
		private void Window_Deactivated(object sender, EventArgs e)
		{
			if (this.autofade.IsChecked.Value)
			{
				this.opacityanim(this.mwyes, base.Opacity, 0.7);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000276B File Offset: 0x0000096B
		private void opacity_Checked(object sender, RoutedEventArgs e)
		{
			this.opacityanim(this.mwyes, base.Opacity, 0.7);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00002788 File Offset: 0x00000988
		private void opacity_Unchecked(object sender, RoutedEventArgs e)
		{
			this.opacityanim(this.mwyes, base.Opacity, 1.0);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000027A5 File Offset: 0x000009A5
		private void topmost_Checked(object sender, RoutedEventArgs e)
		{
			base.Topmost = true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000027AE File Offset: 0x000009AE
		private void topmost_Unchecked(object sender, RoutedEventArgs e)
		{
			base.Topmost = false;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00007BAC File Offset: 0x00005DAC
		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			try
			{
				ContentControl contentControl = this.search_filter_selection.SelectedItem as ComboBoxItem;
				string filters = "";
				string text = contentControl.Content as string;
				if (text != null)
				{
					if (!(text == "Hot"))
					{
						if (!(text == "Newest"))
						{
							if (!(text == "Oldest"))
							{
								if (text == "Most Viewed")
								{
									filters = "mostviewed";
								}
							}
							else
							{
								filters = "oldest";
							}
						}
						else
						{
							filters = "newest";
						}
					}
					else
					{
						filters = "hot";
					}
				}
				this.search_scriptblox(this.searchbox.Text, filters);
			}
			catch (Exception ex)
			{
				this.exceptionhandling(ex);
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000027B7 File Offset: 0x000009B7
		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			this.RunScript(this.GetText());
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00007C60 File Offset: 0x00005E60
		private void Button_Click_7(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Inject();
			}
			catch (Exception ex)
			{
				this.exceptionhandling(ex);
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00007C90 File Offset: 0x00005E90
		public void exceptionhandling(Exception ex)
		{
			try
			{
				MessageBox.Show(ex.Message, "Delta Error");
				Directory.CreateDirectory(System.IO.Path.Combine(this.deltacore, "error_logs"));
				string text = System.IO.Path.Combine(System.IO.Path.Combine(new string[]
				{
					System.IO.Path.Combine(this.deltacore, "error_logs")
				}), "ERROR_LOG_" + DateTime.UtcNow.TimeOfDay.TotalMilliseconds.ToString() + ".txt");
				string contents = string.Format("GO TO OUR DISCORD MAKE A TICKET AND SEND THIS\r\n\r\nDelta Error Log {0}\r\n\r\nFile Name: {1}\r\nHResult: {2}\r\nException Data: {3}\r\nCausing Func: {4}\r\nTarget Site: {5}\r\nOuter Exception Message: {6}\r\nOuter Exception Source: {7}\r\n\r\n\r\nException as String: {8}\r\n", new object[]
				{
					DateTime.Now,
					text,
					ex.HResult,
					ex.Data,
					new StackTrace(ex, true).GetFrame(0).GetMethod().Name,
					ex.TargetSite,
					ex.Message,
					ex.Source,
					ex
				});
				File.WriteAllText(text, contents);
				Process.Start(text);
			}
			catch
			{
				MessageBox.Show(ex.Message, "Delta Error");
				Directory.CreateDirectory(System.IO.Path.Combine(this.deltacore, "error_logs"));
				string text2 = System.IO.Path.Combine(System.IO.Path.Combine(new string[]
				{
					System.IO.Path.Combine(this.deltacore, "error_logs")
				}), "ERROR_LOG_" + DateTime.UtcNow.TimeOfDay.TotalMilliseconds.ToString() + ".txt");
				string contents2 = string.Format("GO TO OUR DISCORD MAKE A TICKET AND SEND THIS\r\n\r\nDelta Error Log {0}\r\n\r\nFile Name: {1}\r\nHResult: {2}\r\nException Data: {3}\r\nCausing Func: {4}\r\nTarget Site: {5}\r\nOuter Exception Message: {6}\r\nInner Exception Message: {7}\r\nOuter Exception Source: {8}\r\n\r\n\r\nException as String: {9}\r\n", new object[]
				{
					DateTime.Now,
					text2,
					ex.HResult,
					ex.Data,
					new StackTrace(ex, true).GetFrame(0).GetMethod().Name,
					ex.TargetSite,
					ex.Message,
					ex.InnerException.Message,
					ex.Source,
					ex
				});
				File.WriteAllText(text2, contents2);
				Process.Start(text2);
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000027C5 File Offset: 0x000009C5
		private void theme_Checked(object sender, RoutedEventArgs e)
		{
			if (this.theme_wrap_panel.Children.Count == 0)
			{
				this.setup_themes();
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000027DF File Offset: 0x000009DF
		private void wrd_Checked(object sender, RoutedEventArgs e)
		{
			this.delta.IsChecked = new bool?(false);
			this.API.SwitchAPI(Module.API.WEAREDEVS);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000027FE File Offset: 0x000009FE
		private void delta_Checked(object sender, RoutedEventArgs e)
		{
			this.wrd.IsChecked = new bool?(false);
			this.API.SwitchAPI(Module.API.DELTA);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00007EC8 File Offset: 0x000060C8
		private void Button_Click_8(object sender, RoutedEventArgs e)
		{
			try
			{
				object arg = JsonConvert.DeserializeObject(File.ReadAllText(System.IO.Path.Combine(this.deltacore, "Settings.json")));
				foreach (object obj in ((IEnumerable)this.options.Items))
				{
					TabItem tabItem = (TabItem)obj;
					if (tabItem.Name != "langtab")
					{
						using (IEnumerator enumerator2 = (tabItem.Content as StackPanel).Children.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								object obj2 = enumerator2.Current;
								CheckBox checkBox = (CheckBox)obj2;
								if (XWindow.<>o__101.<>p__5 == null)
								{
									XWindow.<>o__101.<>p__5 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(XWindow)));
								}
								foreach (object arg2 in XWindow.<>o__101.<>p__5.Target(XWindow.<>o__101.<>p__5, arg))
								{
									if (XWindow.<>o__101.<>p__3 == null)
									{
										XWindow.<>o__101.<>p__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(XWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, bool> target = XWindow.<>o__101.<>p__3.Target;
									CallSite <>p__ = XWindow.<>o__101.<>p__3;
									if (XWindow.<>o__101.<>p__2 == null)
									{
										XWindow.<>o__101.<>p__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(XWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
										}));
									}
									Func<CallSite, object, string, object> target2 = XWindow.<>o__101.<>p__2.Target;
									CallSite <>p__2 = XWindow.<>o__101.<>p__2;
									if (XWindow.<>o__101.<>p__1 == null)
									{
										XWindow.<>o__101.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(XWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, object> target3 = XWindow.<>o__101.<>p__1.Target;
									CallSite <>p__3 = XWindow.<>o__101.<>p__1;
									if (XWindow.<>o__101.<>p__0 == null)
									{
										XWindow.<>o__101.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(XWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									if (target(<>p__, target2(<>p__2, target3(<>p__3, XWindow.<>o__101.<>p__0.Target(XWindow.<>o__101.<>p__0, arg2, "CBName")), checkBox.Name)))
									{
										if (XWindow.<>o__101.<>p__4 == null)
										{
											XWindow.<>o__101.<>p__4 = CallSite<Func<CallSite, object, string, bool?, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(XWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
											}));
										}
										XWindow.<>o__101.<>p__4.Target(XWindow.<>o__101.<>p__4, arg2, "CBState", checkBox.IsChecked);
									}
								}
							}
							continue;
						}
					}
					foreach (object obj3 in ((tabItem.Content as ScrollViewer).Content as StackPanel).Children)
					{
						CheckBox checkBox2 = (CheckBox)obj3;
						if (XWindow.<>o__101.<>p__11 == null)
						{
							XWindow.<>o__101.<>p__11 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(XWindow)));
						}
						foreach (object arg3 in XWindow.<>o__101.<>p__11.Target(XWindow.<>o__101.<>p__11, arg))
						{
							if (XWindow.<>o__101.<>p__9 == null)
							{
								XWindow.<>o__101.<>p__9 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(XWindow), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, bool> target4 = XWindow.<>o__101.<>p__9.Target;
							CallSite <>p__4 = XWindow.<>o__101.<>p__9;
							if (XWindow.<>o__101.<>p__8 == null)
							{
								XWindow.<>o__101.<>p__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(XWindow), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							Func<CallSite, object, string, object> target5 = XWindow.<>o__101.<>p__8.Target;
							CallSite <>p__5 = XWindow.<>o__101.<>p__8;
							if (XWindow.<>o__101.<>p__7 == null)
							{
								XWindow.<>o__101.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(XWindow), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object> target6 = XWindow.<>o__101.<>p__7.Target;
							CallSite <>p__6 = XWindow.<>o__101.<>p__7;
							if (XWindow.<>o__101.<>p__6 == null)
							{
								XWindow.<>o__101.<>p__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(XWindow), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							if (target4(<>p__4, target5(<>p__5, target6(<>p__6, XWindow.<>o__101.<>p__6.Target(XWindow.<>o__101.<>p__6, arg3, "CBName")), checkBox2.Name)))
							{
								if (XWindow.<>o__101.<>p__10 == null)
								{
									XWindow.<>o__101.<>p__10 = CallSite<Func<CallSite, object, string, bool?, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(XWindow), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
									}));
								}
								XWindow.<>o__101.<>p__10.Target(XWindow.<>o__101.<>p__10, arg3, "CBState", checkBox2.IsChecked);
							}
						}
					}
				}
				if (XWindow.<>o__101.<>p__13 == null)
				{
					XWindow.<>o__101.<>p__13 = CallSite<Action<CallSite, Type, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "WriteAllText", null, typeof(XWindow), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, Type, string, object> target7 = XWindow.<>o__101.<>p__13.Target;
				CallSite <>p__7 = XWindow.<>o__101.<>p__13;
				Type typeFromHandle = typeof(File);
				string arg4 = System.IO.Path.Combine(this.deltacore, "Settings.json");
				if (XWindow.<>o__101.<>p__12 == null)
				{
					XWindow.<>o__101.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(XWindow), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				target7(<>p__7, typeFromHandle, arg4, XWindow.<>o__101.<>p__12.Target(XWindow.<>o__101.<>p__12, arg));
				MessageBox.Show(this.save_text, "Delta", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
			catch
			{
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000085A4 File Offset: 0x000067A4
		private void Button_Click_9(object sender, RoutedEventArgs e)
		{
			try
			{
				bool flag = false;
				Theme theme = new Theme();
				foreach (object obj in this.theme_wrap_panel.Children)
				{
					ThemeItem themeItem = (ThemeItem)obj;
					if (themeItem.cyan.IsChecked.Value)
					{
						flag = true;
						theme = themeItem.this__theme;
						this.Overlay.Opacity = theme.opacity * 1.2;
					}
				}
				if (flag)
				{
					this.Overlay.Visibility = Visibility.Visible;
					this.img_theme.Source = new BitmapImage(new Uri(theme.imageURL, UriKind.Absolute));
					File.WriteAllText(this.deltacore + "\\themes.txt", string.Format("{0}", theme.id));
				}
			}
			catch (Exception ex)
			{
				this.exceptionhandling(ex);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000281D File Offset: 0x00000A1D
		private void Button_Click_10(object sender, RoutedEventArgs e)
		{
			this.Overlay.Visibility = Visibility.Hidden;
			File.WriteAllText(this.deltacore + "\\themes.txt", "0");
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000086B0 File Offset: 0x000068B0
		private void opendllfolder_Checked(object sender, RoutedEventArgs e)
		{
			XWindow.<opendllfolder_Checked>d__104 <opendllfolder_Checked>d__;
			<opendllfolder_Checked>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<opendllfolder_Checked>d__.<>4__this = this;
			<opendllfolder_Checked>d__.<>1__state = -1;
			<opendllfolder_Checked>d__.<>t__builder.Start<XWindow.<opendllfolder_Checked>d__104>(ref <opendllfolder_Checked>d__);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00002845 File Offset: 0x00000A45
		private void autoinj_Checked(object sender, RoutedEventArgs e)
		{
			this.DT.Start();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00002852 File Offset: 0x00000A52
		private void autoinj_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DT.Stop();
			this.DT1.Stop();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000086E8 File Offset: 0x000068E8
		private void mwyes_Closed(object sender, EventArgs e)
		{
			try
			{
				List<Tab> list = new List<Tab>();
				foreach (object obj in ((IEnumerable)this.tabControl1.Items))
				{
					TabItem tabItem = (TabItem)obj;
					list.Add(new Tab
					{
						title = (tabItem.Header as TextBox).Text,
						content = (tabItem.Content as TextEditor).Text
					});
				}
				File.WriteAllText(System.IO.Path.Combine(this.deltacore, "saved_tabs.json"), JsonConvert.SerializeObject(list));
				this.save_ui_data();
			}
			catch (Exception ex)
			{
				this.exceptionhandling(ex);
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000087BC File Offset: 0x000069BC
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			(((XWindow)Application.Current.MainWindow).TryFindResource("scriptdetailsback") as Storyboard).Begin();
			(((XWindow)Application.Current.MainWindow).TryFindResource("showsidebar") as Storyboard).Begin();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000286A File Offset: 0x00000A6A
		private void search_filter_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.load_favs();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00008810 File Offset: 0x00006A10
		public void load_favs()
		{
			try
			{
				if ((this.search_filter_selection.SelectedItem as ComboBoxItem).Name == "FAVS")
				{
					this.searchbox.Text = "";
					this.placeholdertext.Visibility = Visibility.Hidden;
					this.wrap_panel.Children.Clear();
					if (!File.Exists(System.IO.Path.Combine(this.deltacore, "saved_scripts")))
					{
						goto IL_173;
					}
					object arg = JsonConvert.DeserializeObject(File.ReadAllText(System.IO.Path.Combine(this.deltacore, "saved_scripts")));
					if (XWindow.<>o__110.<>p__0 == null)
					{
						XWindow.<>o__110.<>p__0 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(XWindow)));
					}
					using (IEnumerator enumerator = XWindow.<>o__110.<>p__0.Target(XWindow.<>o__110.<>p__0, arg).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (XWindow.<>o__110.<>p__1 == null)
							{
								XWindow.<>o__110.<>p__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(XWindow)));
							}
							string id = XWindow.<>o__110.<>p__1.Target(XWindow.<>o__110.<>p__1, enumerator.Current);
							this.wrap_panel.Children.Add(new ScriptBox(id, true, this.execute_again_button.Content.ToString()));
						}
						goto IL_173;
					}
				}
				this.placeholdertext.Visibility = Visibility.Visible;
				this.wrap_panel.Children.Clear();
				IL_173:;
			}
			catch (Exception ex)
			{
				this.exceptionhandling(ex);
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000089D4 File Offset: 0x00006BD4
		private void button_Copy3_Checked(object sender, RoutedEventArgs e)
		{
			if (!this.is_liked)
			{
				this.is_liked = true;
				this.current_scriptbox.button.IsChecked = new bool?(true);
				this.like_count.Text = string.Format("{0}", int.Parse(this.like_count.Text) + 1);
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00008A34 File Offset: 0x00006C34
		private void button_Copy3_Unchecked(object sender, RoutedEventArgs e)
		{
			if (this.is_liked)
			{
				this.is_liked = false;
				this.current_scriptbox.button.IsChecked = new bool?(false);
				this.like_count.Text = string.Format("{0}", int.Parse(this.like_count.Text) - 1);
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00002872 File Offset: 0x00000A72
		private void execute_again_button_Click(object sender, RoutedEventArgs e)
		{
			this.RunScript(this.execute_again_button.Tag.ToString());
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000288A File Offset: 0x00000A8A
		private void Button_Click_11(object sender, RoutedEventArgs e)
		{
			this.create_a_new_tab(this.script_title.Text + " description.txt", this.description_text.Text);
			this.home.IsChecked = new bool?(true);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000028C3 File Offset: 0x00000AC3
		private void autoupdate1_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.englishlang();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000028D2 File Offset: 0x00000AD2
		private void ger_deutsch_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.germanlang();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000028E1 File Offset: 0x00000AE1
		private void ger_deutsch_Copy_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.turkishlang();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000028F0 File Offset: 0x00000AF0
		private void spa_esp_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.spanishlang();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000028FF File Offset: 0x00000AFF
		private void ind_bah_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.indonesianlang();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000290E File Offset: 0x00000B0E
		private void por_por_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.portlang();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000291D File Offset: 0x00000B1D
		private void fil_pil_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.filipinolang();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002769 File Offset: 0x00000969
		private void radioButton2_Checked(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000292C File Offset: 0x00000B2C
		private void fre_fra_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.frenchlang();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000293B File Offset: 0x00000B3B
		private void fin_sou_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.finnishlang();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000294A File Offset: 0x00000B4A
		private void pol_pol_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.polishlang();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00008A94 File Offset: 0x00006C94
		private void Button_Click_12(object sender, RoutedEventArgs e)
		{
			this.create_a_new_tab(this.script_title.Text + ".lua", this.current_scriptbox.Data.script.script);
			this.home.IsChecked = new bool?(true);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00008AE4 File Offset: 0x00006CE4
		private void save_ui_data()
		{
			WindowSize value = new WindowSize(base.Width, base.Height);
			File.WriteAllText(System.IO.Path.Combine(this.deltacore, "windowsize.json"), JsonConvert.SerializeObject(value));
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00008B20 File Offset: 0x00006D20
		private void load_ui_data()
		{
			if (File.Exists(System.IO.Path.Combine(this.deltacore, "windowsize.json")) && File.ReadAllText(System.IO.Path.Combine(this.deltacore, "windowsize.json")) != "[]" && XWindow.IsValidJson(File.ReadAllText(System.IO.Path.Combine(this.deltacore, "windowsize.json"))))
			{
				WindowSize windowSize = JsonConvert.DeserializeObject<WindowSize>(File.ReadAllText(System.IO.Path.Combine(this.deltacore, "windowsize.json")));
				base.Width = windowSize.width;
				base.Height = windowSize.height;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00008BB4 File Offset: 0x00006DB4
		private void searchbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				try
				{
					ContentControl contentControl = this.search_filter_selection.SelectedItem as ComboBoxItem;
					string filters = "";
					string text = contentControl.Content as string;
					if (text != null)
					{
						if (!(text == "Hot"))
						{
							if (!(text == "Newest"))
							{
								if (!(text == "Oldest"))
								{
									if (text == "Most Viewed")
									{
										filters = "mostviewed";
									}
								}
								else
								{
									filters = "oldest";
								}
							}
							else
							{
								filters = "newest";
							}
						}
						else
						{
							filters = "hot";
						}
					}
					this.search_scriptblox(this.searchbox.Text, filters);
				}
				catch (Exception ex)
				{
					this.exceptionhandling(ex);
				}
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00002959 File Offset: 0x00000B59
		private void thai_thai_Checked(object sender, RoutedEventArgs e)
		{
			this.uncheckalllangs(sender);
			this.thailang();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00002968 File Offset: 0x00000B68
		private void Button_Click_13(object sender, RoutedEventArgs e)
		{
			LinkOpener.openlink("https://deltaexploits.com");
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00002974 File Offset: 0x00000B74
		private void execute_again_button_Copy_Click(object sender, RoutedEventArgs e)
		{
			File.Create(System.IO.Path.Combine(this.deltacore, "EULA.txt"));
			(base.TryFindResource("hide_eula") as Storyboard).Begin();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000029A1 File Offset: 0x00000BA1
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 2)
			{
				((Button)target).Click += this.button_Click_1;
				return;
			}
			if (connectionId != 3)
			{
				return;
			}
			((Button)target).Click += this.Button_Click;
		}

		// Token: 0x04000068 RID: 104
		private string no_results;

		// Token: 0x04000069 RID: 105
		private string save_text;

		// Token: 0x0400006A RID: 106
		private string auto_exec_prompt;

		// Token: 0x0400006B RID: 107
		public bool is_liked;

		// Token: 0x0400006C RID: 108
		public ScriptBox current_scriptbox;

		// Token: 0x0400006D RID: 109
		public string current_id;

		// Token: 0x0400006E RID: 110
		private DispatcherTimer DT = new DispatcherTimer();

		// Token: 0x0400006F RID: 111
		private DispatcherTimer DT1 = new DispatcherTimer();

		// Token: 0x04000070 RID: 112
		private Module API = new Module();

		// Token: 0x04000071 RID: 113
		private string deltacore = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "delta_core");

		// Token: 0x04000072 RID: 114
		private string Module575 = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\579-Module.dll";

		// Token: 0x04000073 RID: 115
		private string Module577 = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\577-Delta-Module.dll";

		// Token: 0x04000074 RID: 116
		private string Module578 = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\578-Delta-Module.dll";

		// Token: 0x04000075 RID: 117
		private string CurrentModule = "";

		// Token: 0x04000076 RID: 118
		private static Random random = new Random();

		// Token: 0x04000077 RID: 119
		private string fullpath;

		// Token: 0x04000078 RID: 120
		private string deltaspath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), XWindow.RandomString(17));
	}
}
