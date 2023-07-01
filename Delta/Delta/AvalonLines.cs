using System;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace Delta
{
	// Token: 0x02000028 RID: 40
	public class AvalonLines : VisualLineElementGenerator
	{
		// Token: 0x0600012D RID: 301 RVA: 0x0000B950 File Offset: 0x00009B50
		public override int GetFirstInterestedOffset(int startOffset)
		{
			DocumentLine lastDocumentLine = base.CurrentContext.VisualLine.LastDocumentLine;
			if (lastDocumentLine.Length > 400)
			{
				int num = lastDocumentLine.Offset + 400 - "...".Length;
				if (startOffset <= num)
				{
					return num;
				}
			}
			return -1;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00002B00 File Offset: 0x00000D00
		public override VisualLineElement ConstructElement(int offset)
		{
			return new FormattedTextElement("...", base.CurrentContext.VisualLine.LastDocumentLine.EndOffset - offset);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00002B23 File Offset: 0x00000D23
		public AvalonLines()
		{
		}
	}
}
