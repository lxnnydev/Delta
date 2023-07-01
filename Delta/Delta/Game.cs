using System;
using System.Runtime.CompilerServices;

namespace Delta
{
	// Token: 0x0200000E RID: 14
	public class Game
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000218A File Offset: 0x0000038A
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002192 File Offset: 0x00000392
		public long gameId
		{
			[CompilerGenerated]
			get
			{
				return this.<gameId>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<gameId>k__BackingField = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600002A RID: 42 RVA: 0x0000219B File Offset: 0x0000039B
		// (set) Token: 0x0600002B RID: 43 RVA: 0x000021A3 File Offset: 0x000003A3
		public string name
		{
			[CompilerGenerated]
			get
			{
				return this.<name>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<name>k__BackingField = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000021AC File Offset: 0x000003AC
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000021B4 File Offset: 0x000003B4
		public string imageUrl
		{
			[CompilerGenerated]
			get
			{
				return this.<imageUrl>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<imageUrl>k__BackingField = value;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002050 File Offset: 0x00000250
		public Game()
		{
		}

		// Token: 0x0400002C RID: 44
		[CompilerGenerated]
		private long <gameId>k__BackingField;

		// Token: 0x0400002D RID: 45
		[CompilerGenerated]
		private string <name>k__BackingField;

		// Token: 0x0400002E RID: 46
		[CompilerGenerated]
		private string <imageUrl>k__BackingField;
	}
}
