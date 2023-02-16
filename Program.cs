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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Mini-PL!");
            string source = System.IO.File.ReadAllText(args[0]);
            List<List<String>> tokens = new List<List<String>>();
            tokens.Add(new List<string>());
            int line = 0;
            int index = 0;
            string token = "";
            while (index != source.Length)
            {
                if (source[index] == char.Parse(" "))
                {
                    tokens[line].Add(token);
                    token = "";
                    index++;
                }
                token += source[index];
                index++;
            }
            tokens[line].Add(token);
            Console.WriteLine("Parsed tokens");
            foreach (var parsedToken in tokens[0])
            {
                Console.WriteLine(parsedToken);
            }
        }
    }
}