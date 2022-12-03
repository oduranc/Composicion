using Antlr4.Runtime.Misc;
using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Composicion
{
    internal class Composicion : ComposicionBaseVisitor<string>
    {
        Aspose.Words.Document doc = new Aspose.Words.Document();
        DocumentBuilder builder;
        Font font;
        string docName;
        public Composicion()
        {
            builder = new DocumentBuilder(doc);
            font = builder.Font;
            font.Color = System.Drawing.Color.Black;
            font.Name = "Arial";
            font.Size = 12;
            font.Bold = false;
            font.Italic = false;
            font.Underline = Underline.None;
        }
        public override string VisitTextComp([NotNull] ComposicionParser.TextCompContext context)
        {
            base.VisitTextComp(context);
            doc.Save($"{docName}.docx");
            return "";
        }
        public override string VisitDocument([NotNull] ComposicionParser.DocumentContext context)
        {
            return base.VisitDocument(context);
        }
        public override string VisitCommand([NotNull] ComposicionParser.CommandContext context)
        {
            return base.VisitCommand(context);
        }
        public override string VisitName([NotNull] ComposicionParser.NameContext context)
        {
            string name = context.TEXT().GetText();
            docName = name;
            return "";
        }
        public override string VisitTitle([NotNull] ComposicionParser.TitleContext context)
        {
            font.Size = 32;
            font.Bold = true;
            Visit(context.content());
            builder.Writeln();
            builder.Writeln();
            font.Size = 12;
            font.Bold = false;
            return "";
        }
        public override string VisitH1([NotNull] ComposicionParser.H1Context context)
        {
            font.Size = 24;
            font.Bold = true;
            Visit(context.content());
            builder.Writeln();
            builder.Writeln();
            font.Size = 12;
            font.Bold = false;
            return "";
        }
        public override string VisitH2([NotNull] ComposicionParser.H2Context context)
        {
            font.Size = 20;
            font.Bold = true;
            Visit(context.content());
            builder.Writeln();
            builder.Writeln();
            font.Size = 12;
            font.Bold = false;
            return "";
        }
        public override string VisitH3([NotNull] ComposicionParser.H3Context context)
        {
            font.Size = 16;
            font.Bold = true;
            Visit(context.content());
            builder.Writeln();
            builder.Writeln();
            font.Size = 12;
            font.Bold = false;
            return "";
        }
        public override string VisitBold([NotNull] ComposicionParser.BoldContext context)
        {
            font.Bold = true;
            Visit(context.content());
            font.Bold = false;
            return "";
        }
        public override string VisitItalic([NotNull] ComposicionParser.ItalicContext context)
        {
            font.Italic = true;
            Visit(context.content());
            font.Italic = false;
            return "";
        }
        public override string VisitUnderline([NotNull] ComposicionParser.UnderlineContext context)
        {
            font.Underline = Underline.Single;
            Visit(context.content());
            font.Underline = Underline.None;
            return "";
        }
        public override string VisitPara([NotNull] ComposicionParser.ParaContext context)
        {
            Visit(context.content());
            builder.Writeln();
            builder.Writeln();
            return "";
        }
        public override string VisitRef([NotNull] ComposicionParser.RefContext context)
        {
            foreach (var item in context.refItem())
            {
                Visit(item);
            }
            builder.Writeln();
            return "";
        }
        public override string VisitRefItem([NotNull] ComposicionParser.RefItemContext context)
        {
            string name = context.TEXT().GetText();
            string url = context.URL().GetText();
            font.Italic = true;
            builder.Write($"\t {name}.");
            font.Italic = false;
            font.Underline = Underline.Single;
            font.Color = System.Drawing.Color.Blue;
            builder.Write($"{url}");
            font.Underline = Underline.None;
            font.Color = System.Drawing.Color.Black;
            return "";
        }
        public override string VisitList([NotNull] ComposicionParser.ListContext context)
        {
            builder.ListFormat.ApplyBulletDefault();
            foreach (var item in context.listItem())
            {
                builder.Write(Visit(item));
            }
            builder.ListFormat.RemoveNumbers();
            builder.Writeln();
            return "";
        }
        public override string VisitListItem([NotNull] ComposicionParser.ListItemContext context)
        {
            return Visit(context.content());
        }
        public override string VisitTable([NotNull] ComposicionParser.TableContext context)
        {
            Table table = builder.StartTable();
            foreach (var item in context.tableRow())
            {
                Visit(item);
            }
            table.AutoFit(AutoFitBehavior.AutoFitToContents);
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            builder.EndTable();
            builder.Writeln();
            return "";
        }
        public override string VisitTableRow([NotNull] ComposicionParser.TableRowContext context)
        {
            foreach (var item in context.tableCell())
            {
                builder.InsertCell();
                builder.Write(Visit(item));
            }
            builder.EndRow();
            return "";
        }
        public override string VisitTableCell([NotNull] ComposicionParser.TableCellContext context)
        {
            return Visit(context.content());
        }
        public override string VisitJustText([NotNull] ComposicionParser.JustTextContext context)
        {
            string text = context.TEXT().GetText();
            builder.Write(text);
            try
            {
                if (!context.content().IsEmpty)
                {
                    string content = Visit(context.content());
                    builder.Write(content);
                }
            }
            catch (NullReferenceException e)
            {
            }
            return "";
        }
        public override string VisitJustCommand([NotNull] ComposicionParser.JustCommandContext context)
        {
            string command = Visit(context.command());
            builder.Write(command);
            try
            {
                if (!context.content().IsEmpty)
                {
                    string content = Visit(context.content());
                    builder.Write(content);
                }
            }
            catch (NullReferenceException e)
            {
            }
            return "";
        }
    }
}
