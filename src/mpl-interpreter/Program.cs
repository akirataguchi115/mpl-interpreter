namespace MPLInterpreter

{
  class Program
  {

	static void Main(string[] args)
	{
	  string source = System.IO.File.ReadAllText(args[0]);
	  Scanner scanner = new Scanner(source);
		Parser parser = new Parser(scanner);
	  Tree<Node> ASTTree = parser.CreateAST();
	}
  }
}