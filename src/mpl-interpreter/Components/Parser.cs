namespace MPLInterpreter
{
	public class Node
	{
	  public Node? parent;
	  public List<Node>? children;
	  public Tuple<string, string>? token;
	}

	public struct Tree<Node>
	{
	  public Node n;
	}
  class Parser
  {
		private Scanner scanner;
		public Parser(Scanner scanner)
		{
			this.scanner = scanner;
		}

	public Tree<Node> CreateAST()
	{
	  Tree<Node> tree = new Tree<Node>();
	  while (true)
	  {
		return tree;
	  }
	}
  }
}