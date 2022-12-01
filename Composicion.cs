using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composicion
{
    internal class Composicion : ComposicionBaseVisitor<string>
    {
        public override string VisitBold([NotNull] ComposicionParser.BoldContext context)
        {
            return base.VisitBold(context);
        }

        public override string VisitCommand([NotNull] ComposicionParser.CommandContext context)
        {
            return base.VisitCommand(context);
        }

        public override string VisitDocument([NotNull] ComposicionParser.DocumentContext context)
        {
            return base.VisitDocument(context);
        }

        public override string VisitH1([NotNull] ComposicionParser.H1Context context)
        {
            return base.VisitH1(context);
        }

        public override string VisitH2([NotNull] ComposicionParser.H2Context context)
        {
            return base.VisitH2(context);
        }

        public override string VisitH3([NotNull] ComposicionParser.H3Context context)
        {
            return base.VisitH3(context);
        }

        public override string VisitItalic([NotNull] ComposicionParser.ItalicContext context)
        {
            return base.VisitItalic(context);
        }

        public override string VisitJustText([NotNull] ComposicionParser.JustTextContext context)
        {
            return base.VisitJustText(context);
        }

        public override string VisitList([NotNull] ComposicionParser.ListContext context)
        {
            return base.VisitList(context);
        }

        public override string VisitListItem([NotNull] ComposicionParser.ListItemContext context)
        {
            return base.VisitListItem(context);
        }

        public override string VisitName([NotNull] ComposicionParser.NameContext context)
        {
            return base.VisitName(context);
        }

        public override string VisitPara([NotNull] ComposicionParser.ParaContext context)
        {
            return base.VisitPara(context);
        }

        public override string VisitRef([NotNull] ComposicionParser.RefContext context)
        {
            return base.VisitRef(context);
        }

        public override string VisitRefItem([NotNull] ComposicionParser.RefItemContext context)
        {
            return base.VisitRefItem(context);
        }

        public override string VisitTable([NotNull] ComposicionParser.TableContext context)
        {
            return base.VisitTable(context);
        }

        public override string VisitTableCell([NotNull] ComposicionParser.TableCellContext context)
        {
            return base.VisitTableCell(context);
        }

        public override string VisitTableRow([NotNull] ComposicionParser.TableRowContext context)
        {
            return base.VisitTableRow(context);
        }

        public override string VisitTextComp([NotNull] ComposicionParser.TextCompContext context)
        {
            return base.VisitTextComp(context);
        }

        public override string VisitTextWithCommand([NotNull] ComposicionParser.TextWithCommandContext context)
        {
            return base.VisitTextWithCommand(context);
        }

        public override string VisitTitle([NotNull] ComposicionParser.TitleContext context)
        {
            return base.VisitTitle(context);
        }

        public override string VisitUnderline([NotNull] ComposicionParser.UnderlineContext context)
        {
            return base.VisitUnderline(context);
        }
    }
}
