using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Delta.Properties
{
	// Token: 0x02000029 RID: 41
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000130 RID: 304 RVA: 0x00002050 File Offset: 0x00000250
		internal Resources()
		{
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00002B2B File Offset: 0x00000D2B
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Delta.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00002B57 File Offset: 0x00000D57
		// (set) Token: 0x06000133 RID: 307 RVA: 0x00002B5E File Offset: 0x00000D5E
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400018C RID: 396
		private static ResourceManager resourceMan;

		// Token: 0x0400018D RID: 397
		private static CultureInfo resourceCulture;
	}
}
