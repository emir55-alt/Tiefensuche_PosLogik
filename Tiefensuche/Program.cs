class Program
{
    public List<int>DFS(Dictionary<int, List<int>> graph, int start)
    {
       HashSet<int> visited = new HashSet<int>(); //Merkt sich welche Knoten besucht werden
        Stack<int> stack = new Stack<int>();
        stack.Push(start); //Startknoten
        while (stack.Count > 0) { //Solange noch was auf dem Stack ist
            int node = stack.Pop(); //löscht den obersten Knoten
            if (!visited.Contains(node)) { //Nur bearbeiten wenn noch nicht besucht
                visited.Add(node); //Als besucht markieren

                List<int> nachbarn = graph.GetValueOrDefault(node); //Holt die Werte aus dem Dictionary
                if (nachbarn != null) { //Hat der Knoten noch Nachabarn
                    foreach(int nachbar in nachbarn) //Geht alle Nachbarn durch
                    {
                        stack.Push(nachbar); //Fügt die Nachbarn zum Stack hinzu
                    }
                }
            }
        }
        return visited.ToList();
    }
    
    static void Main()
    {
        var graph = new Dictionary<int, List<int>>
        {
            [0] = [1, 2],
            [1] = [3, 4],
            [2] = [5],
            [3] = [],
            [4] = [],
            [5] = []
        };
        var p = new Program();
        var ergebnis = p.DFS(graph, 0);
        Console.WriteLine(string.Join("->", ergebnis));
    }

}