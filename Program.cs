using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using Composicion;
using Antlr4.Runtime.Misc;

string textFile = @"..\..\..\ejemplo.txt";

Console.WriteLine("");
Console.WriteLine("\tLenguaje de composición de textos\n");

Console.WriteLine("Verificando el texto... \n");

IParseTree parse(string textFile)
{
    ImmediateErrorListener errListener = ImmediateErrorListener.Instance;
    var inputStream = CharStreams.fromPath(textFile);
    var lexer = new ComposicionLexer(inputStream);
    var tokenStream = new CommonTokenStream(lexer);
    var parser = new ComposicionParser(tokenStream);
    parser.RemoveErrorListeners();
    parser.AddErrorListener(errListener);
    var tree = parser.textComp();
    return tree;
}


bool ok = true;
IParseTree? tree = null;
string input;
int count = 0;

do
{
    input = textFile;
    try
    {
        tree = parse(input);
        var composicion = new Composicion.Composicion();
        composicion.Visit(tree);
        ok = true;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Documento de word ha sido generado exitosamente!!");
        Console.ResetColor();

    }
    catch (ParseCanceledException e)
    {
        count++;
        Console.WriteLine("No se ha podido generar el documento de word debido a errores\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
        Console.WriteLine($"{count}");

        

    }

} while (!ok);




Console.ReadLine();
