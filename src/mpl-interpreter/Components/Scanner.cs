namespace MPLInterpreter
{

  public class Scanner
  {
	List<List<String>> tokens = new List<List<String>>();
	private string source;
	public Scanner(string source)
	{
		this.source = source;
	}
	public Tuple<string, string> GetString()
	{
	  return new Tuple<string, string>("", "");
	}
	static Tuple<string?, int> ScanString(string literal)
	{
	  string lexeme = "";
	  int index = 0;
	  if (literal[index] != Char.Parse("\"")) return new Tuple<string?, int>(null, index);
	  index++;
	  while (true)
	  {
		char ch = literal[index];
		if (ch.Equals('\\'))
		{
		  index++;
		  switch (literal[index])
		  {
			case 'n':
			  lexeme += 'n';
			  break;
			case 't':
			  lexeme += 't';
			  break;
			default:
			  lexeme += literal[index];
			  break;
		  }
		}
		else if (ch.Equals('\"'))
		{
		  return new Tuple<string?, int>(lexeme, index);
		}
		else if (ch.Equals('\n'))
		{
		  return new Tuple<string?, int>(null, ++index);
		}
		else
		{
		  lexeme += ch;
		}
		index++;
	  }
	}

	public List<List<String>> Scan(string source)
	{
	  int index = 0;
	  int tokenIndex = 0;
	  string token = "";
	  while (index != source.Length)
	  {
		if (source[index] == '\"')
		{
		  Tuple<string?, int> scannedToken = ScanString(source.Substring(index));
		  if (scannedToken.Item1 == null)
		  {
			token = "error";
			index += scannedToken.Item2 + 1;
		  }
		  else
		  {
			token = "string";
			index += scannedToken.Item2 + 1;
		  }
		}
		else if (source[index] == char.Parse(" ")
			|| source[index] == char.Parse("\n")
			|| index == source.Length - 1
			|| source[index] == char.Parse(";"))
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
			case "var":
			  type = "null";
			  break;
			case ":":
			  type = "null";
			  break;
			case ":=":
			  type = "null";
			  break;
			case "-":
			  type = "null";
			  break;
			case ";":
			  type = "null";
			  break;
			case "error":
			  type = "error";
			  break;
			default:
			  type = "ident";
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
		if (index == source.Length) Console.Write("}"); else Console.Write("}, ");
	  }
	  Console.Write("}");
	  Console.WriteLine();
	  return tokens;
	}
  }
}