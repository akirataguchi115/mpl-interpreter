namespace MPLInterpreter
{
	public class Node
	{
	  private Node? _parent;
		public Node? parent
		{
			get => _parent;
			set => _parent = value;
		}
	  private List<Node>? _children;
		public List<Node>? children
		{
			get => _children;
			set => _children = value;
		}
	  private string? _token;
		public string? token
		{
			get => _token;
			set => _token = value;
		}

		public Node(string token)
		{
			this.token = token;
		}
	}

  public class Parser
  {
		private Scanner scanner;
		public Parser(Scanner scanner)
		{
			this.scanner = scanner;
		}

	public Node makeAST()
	{
	  Node tree = new Node("program");
	  return tree;
	}
	}
}