namespace MPLInterpreter;

public class ScannerTests
{
	[Fact]
	public void ScannerTagsTokensCorrectly()
	{
		string source = "var X : int := 4 + (6 * 2);";
		Scanner scanner = new Scanner(source);
		List<List<String>> expected = new List<List<String>>();
		expected.Add(new List<String>{"null", "var"});
		expected.Add(new List<string>{"ident", "X"});
		expected.Add(new List<string>{"null", ":"});
		expected.Add(new List<string>{"type", "int"});
		expected.Add(new List<string>{"null", ":="});
		expected.Add(new List<string>{"ident", "4"});
		expected.Add(new List<string>{"ident", "+"});
		expected.Add(new List<string>{"ident", "(6"});
		expected.Add(new List<string>{"ident", "*"});
		expected.Add(new List<string>{"ident", "2)"});
		List<List<String>> actual = scanner.Scan(source);
		Assert.Equal(expected, actual);
	}
}