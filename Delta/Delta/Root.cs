using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Delta
{
	// Token: 0x02000014 RID: 20
	public class Root
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000024AE File Offset: 0x000006AE
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000024B6 File Offset: 0x000006B6
		public List<Theme> themes
		{
			[CompilerGenerated]
			get
			{
				return this.<themes>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<themes>k__BackingField = value;
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002050 File Offset: 0x00000250
		public Root()
		{
		}

		// Token: 0x0400005A RID: 90
		[CompilerGenerated]
		private List<Theme> <themes>k__BackingField;
	}
}
