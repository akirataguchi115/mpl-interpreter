namespace MPLInterpreter;

public class ParserTests
{
	[Fact]
	public void ParserProducesCorrectAST()
	{
		List<List<string>> expected = new List<List<string>>();
		expected.Add(new List<string>{"null", "var"});
		expected.Add(new List<string>{"ident", "X"});
		expected.Add(new List<string>{"null", ":"});
		expected.Add(new List<string>{"type", "int"});
		expected.Add(new List<string>{"null", ":="});
		expected.Add(new List<string>{"int", "4"});
		expected.Add(new List<string>{"null", "+"});
		expected.Add(new List<string>{"int", "6"});
		expected.Add(new List<string>{"null", "*"});
		expected.Add(new List<string>{"int", "2"});
		expected.Add(new List<string>{"null", ";"});
		expected.Add(new List<string>{"null", "print"});
		expected.Add(new List<string>{"ident", "X"});
		expected.Add(new List<string>{"null", ";"});
		string source = "var X : int := 4 + (6 * 2);\nprint X;";
		Scanner scanner = new Scanner(source);
		scanner.tokens = expected;

		Node program = new Node("program");
		Node assign = new Node("assign");
		Node print = new Node("print");
		Node idx1 = new Node("id: X");
		Node plus = new Node("+");
		Node idx2 = new Node("id: X");
		Node lit4 = new Node("Literal: 4");
		Node star = new Node("*");
		Node lit6 = new Node("Literal: 6");
		Node lit2 = new Node("Literal: 2");

		program.children = new List<Node> { assign, print };
		assign.parent = program;
		assign.children = new List<Node> { idx1, plus };
		print.children = new List<Node> { idx2 };
		print.parent = program;
		plus.children = new List<Node> { lit4, star };
		plus.parent = assign;
		lit4.parent = plus;
		star.children = new List<Node> { lit6, lit2 };
		star.parent = plus;
		lit6.parent = star;
		lit2.parent = star;

		Parser parser = new Parser(scanner);
		Assert.Equal(program, parser.makeAST());
	}
}