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