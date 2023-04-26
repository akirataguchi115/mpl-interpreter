namespace MPLInterpreter

{
  class Program
  {

	static void Main(string[] args)
	{
	  string source = System.IO.File.ReadAllText(args[0]);
	  Scanner scanner = new Scanner(source);
		Parser parser = new Parser(scanner);
	  Node AST = parser.makeAST();
	}
  }
}