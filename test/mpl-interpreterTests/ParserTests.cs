namespace MPLInterpreter;

using System.Collections.Generic;
using Newtonsoft.Json;

[Collection("Test")]
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
		expected.Add(new List<string>{"null", ";"});
		string source = "var X : int := 4 + 6;";
		Scanner scanner = new Scanner(source);
		scanner.tokens = expected;

		Node program = new Node("program");
		Node assign = new Node("assign");
		Node idx1 = new Node("id: X");
		Node plus = new Node("+");
		Node lit4 = new Node("Literal: 4");
		Node lit6 = new Node("Literal: 6");

		program.children = new List<Node> { assign };
		program.parent = null;
		assign.parent = program;
		assign.children = new List<Node> { idx1, plus };
		plus.children = new List<Node> { lit4, lit6 };
		idx1.parent = assign;
		plus.parent = assign;
		lit4.parent = plus;
		lit6.parent = plus;

		System.Console.WriteLine(program.children);

		Parser parser = new Parser(scanner);
		Node ast = parser.makeAST();
		var obj1 = JsonConvert.SerializeObject(program, Formatting.None,
		new JsonSerializerSettings()
		{
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		});
		var obj2 = JsonConvert.SerializeObject(ast, Formatting.None,
		new JsonSerializerSettings()
		{
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		});
		Assert.Equivalent(obj1, obj2);
	}
}