using System;
using System.Runtime.CompilerServices;

namespace Delta
{
	// Token: 0x02000012 RID: 18
	public class WindowSize
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002443 File Offset: 0x00000643
		// (set) Token: 0x0600007F RID: 127 RVA: 0x0000244B File Offset: 0x0000064B
		public double width
		{
			[CompilerGenerated]
			get
			{
				return this.<width>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<width>k__BackingField = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002454 File Offset: 0x00000654
		// (set) Token: 0x06000081 RID: 129 RVA: 0x0000245C File Offset: 0x0000065C
		public double height
		{
			[CompilerGenerated]
			get
			{
				return this.<height>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<height>k__BackingField = value;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002465 File Offset: 0x00000665
		public WindowSize(double width1, double height1)
		{
			this.width = width1;
			this.height = height1;
		}

		// Token: 0x04000055 RID: 85
		[CompilerGenerated]
		private double <width>k__BackingField;

		// Token: 0x04000056 RID: 86
		[CompilerGenerated]
		private double <height>k__BackingField;
	}
}
