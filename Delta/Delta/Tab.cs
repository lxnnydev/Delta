using System;
using System.Runtime.CompilerServices;

namespace Delta
{
	// Token: 0x02000013 RID: 19
	public class Tab
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000247B File Offset: 0x0000067B
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00002483 File Offset: 0x00000683
		public string title
		{
			[CompilerGenerated]
			get
			{
				return this.<title>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<title>k__BackingField = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000248C File Offset: 0x0000068C
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00002494 File Offset: 0x00000694
		public int id
		{
			[CompilerGenerated]
			get
			{
				return this.<id>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<id>k__BackingField = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000087 RID: 135 RVA: 0x0000249D File Offset: 0x0000069D
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000024A5 File Offset: 0x000006A5
		public string content
		{
			[CompilerGenerated]
			get
			{
				return this.<content>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<content>k__BackingField = value;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002050 File Offset: 0x00000250
		public Tab()
		{
		}

		// Token: 0x04000057 RID: 87
		[CompilerGenerated]
		private string <title>k__BackingField;

		// Token: 0x04000058 RID: 88
		[CompilerGenerated]
		private int <id>k__BackingField;

		// Token: 0x04000059 RID: 89
		[CompilerGenerated]
		private string <content>k__BackingField;
	}
}
