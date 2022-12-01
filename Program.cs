
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using Composicion;
using Antlr4.Runtime.Misc;

var textFile = CharStreams.fromPath(@"..\..\..\ejemplo.txt");

Console.WriteLine(textFile);


IParseTree parse(string textFile)
{
    ImmediateErrorListener errListener = ImmediateErrorListener.Instance;
    var inputStream = CharStreams.fromString(textFile);
    var lexer = new ComposicionLexer(inputStream);
    var tokenStream = new CommonTokenStream(lexer);
    var parser = new ComposicionParser(tokenStream);
    parser.RemoveErrorListeners();
    parser.AddErrorListener(errListener);
    var tree = parser.textComp();
    return tree;
}
IParseTree? tree = null;
var composicion = new Composicion.Composicion();


Console.ReadLine();
