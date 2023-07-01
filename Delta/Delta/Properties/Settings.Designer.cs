using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Delta.Properties
{
	// Token: 0x0200002A RID: 42
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00002B66 File Offset: 0x00000D66
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400018E RID: 398
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
