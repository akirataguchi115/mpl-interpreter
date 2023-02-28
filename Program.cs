namespace HelloWorld
{
  class Program
  {

	static string ScanString(string literal)
	{
	  int index = 0;
	  while (index < literal.Length)
	  {
		Console.WriteLine(literal[index]);
		if (literal[index].Equals('\\'))
		{
		  return "found escape character!";
		}
		index++;
	  }
	  return literal;
	}

	static List<List<String>> Scanner(string source)
	{
	  List<List<String>> tokens = new List<List<String>>();
	  int index = 0;
	  int tokenIndex = 0;
	  string token = "";
	  while (index != source.Length)
	  {
		if (source[index] == char.Parse(" "))
		{
		  tokens.Add(new List<string>());
		  string type = "";
		  switch (token)
		  {
			case "int":
			  type = "type";
			  break;
			case "string":
			  type = "type";
			  break;
			case "bool":
			  type = "type";
			  break;
			default:
			  type = "null";
			  break;
		  }
		  tokens[tokenIndex].Add(type);
		  tokens[tokenIndex].Add(token);
		  token = "";
		  tokenIndex++;
		  index++;
		}
		else
		{
		  token += source[index];
		  index++;
		}
	  }
	  Console.WriteLine("Parsed tokens");
	  Console.Write("{");
	  foreach (var parsedToken in tokens)
	  {
		Console.Write("{");
		Console.Write(parsedToken[0] + ", " + parsedToken[1]);
		Console.Write("}");
	  }
	  Console.Write("}");
	  Console.WriteLine();
	  return tokens;
	}
	static void Main(string[] args)
	{
	  Console.WriteLine("Hello, Mini-PL!");
	  string source = System.IO.File.ReadAllText(args[0]);
	  List<List<String>> tokens = Scanner(source);
	}
  }
}