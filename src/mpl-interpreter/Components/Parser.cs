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
	  private List<Node> _children;
		public List<Node> children
		{
			get => _children;
			set
			{
				_children = value;
			}
		}
	  private string? _token;
		public string? token
		{
			get => _token;
			set => _token = value;
		}

		public Node(string token, Node? parent, List<Node> children)
		{
			this.token = token;
			this.parent = parent;
			this._children = children == null ? new List<Node>() : children;
		}

		public Node(string token)
		{
			this.token = token;
			this._children = new List<Node>();
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
	  Node root = new Node("program",null, new List<Node>());
		while (true)
		{
			List<string> token = scanner.GetToken();
			if (token[0] == "eol")
			{
				break;
			}
			
			switch (token[1])
			{
				case "var":
					Node assign = new Node("assign", root, new List<Node>());
					List<Node> list = root.children;
					list.Add(assign);
					root.children = list;
					token = scanner.GetToken();

					Node id = new Node("id: " + token[1], assign, new List<Node>());
					list = assign.children;
					list.Add(id);
					assign.children = list;
					scanner.GetToken();
					// this could get the type of the value
					scanner.GetToken();
					scanner.GetToken();
					string value1 = scanner.GetToken()[1];
					string op = scanner.GetToken()[1];
					string value2 = scanner.GetToken()[1];
					Node nodeop = new Node(op, assign, new List<Node>());
					Node nodeval1 = new Node("Literal: " + value1, nodeop, new List<Node>());
					Node nodeval2 = new Node("Literal: " + value2, nodeop, new List<Node>());
					list = nodeop.children;
					list.Add(nodeval1);
					list.Add(nodeval2);
					nodeop.children = list;
					list = assign.children;
					list.Add(nodeop);
					assign.children = list;
					break;
				default:
					break;
			}
		}
	  return root;
	}
	}
}