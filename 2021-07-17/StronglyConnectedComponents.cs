namespace Google
{
    using System.Collections.Generic;

    public class Stack
    {
        private readonly IList<int> stack = new List<int>();

        public void Push(int num)
        {
            this.stack.Add(num);
        }

        public int Pop()
        {
            int last = this.stack.Count - 1;
            int num = this.stack[last];
            this.stack.RemoveAt(last);
            return num;
        }

        public bool IsEmpty()
        {
            return this.stack.Count == 0;
        }
    }

    public class StronglyConnectedComponents
    {
        public IList<IList<int>> KosarajuAlgorithm(int[][] adjacency)
        {
            Dictionary<int, List<int>> graph = this.GetGraph(adjacency);
            IList<int> vertices = this.GetVertices(adjacency);

            HashSet<int> visited = new HashSet<int>();
            Stack vertexStack = new Stack();
            for (int i = 0; i < vertices.Count; i++)
            {
                this.Traverse(vertices[i], graph, vertexStack, visited);
            }

            visited.Clear();
            Dictionary<int, List<int>> transposedGraph = this.GetTransposedGraph(adjacency);

            IList<IList<int>> result = new List<IList<int>>();
            while (!vertexStack.IsEmpty())
            {
                List<int> connectedComponents = new List<int>();
                this.TraverseOnTransposed(
                    vertexStack.Pop(),
                    transposedGraph,
                    connectedComponents,
                    visited);

                if (connectedComponents.Count > 0)
                {
                    result.Add(connectedComponents);
                }
            }

            return result;
        }

        private Dictionary<int, List<int>> GetGraph(int[][] adjacency)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < adjacency.Length; i++)
            {
                int source = adjacency[i][0];
                int destination = adjacency[i][1];

                if (graph.ContainsKey(source))
                {
                    graph[source].Add(destination);
                }
                else
                {
                    graph[source] = new List<int> { destination };
                }
            }

            return graph;
        }

        private IList<int> GetVertices(int[][] adjacency)
        {
            HashSet<int> seen = new HashSet<int>();
            IList<int> vertices = new List<int>();

            for (int i = 0; i < adjacency.Length; i++)
            {
                int source = adjacency[i][0];
                int destination = adjacency[i][1];

                if (!seen.Contains(source))
                {
                    vertices.Add(source);
                    seen.Add(source);
                }

                if (!seen.Contains(destination))
                {
                    vertices.Add(destination);
                    seen.Add(destination);
                }
            }

            return vertices;
        }

        private void Traverse(
            int vertex,
            Dictionary<int, List<int>> graph,
            Stack vertexStack,
            HashSet<int> visited)
        {
            if (visited.Contains(vertex))
            {
                return;
            }

            visited.Add(vertex);

            if (!graph.ContainsKey(vertex) || graph[vertex].Count == 0)
            {
                vertexStack.Push(vertex);
                return;
            }

            for (int i = 0; i < graph[vertex].Count; i++)
            {
                Traverse(graph[vertex][i], graph, vertexStack, visited);
            }

            vertexStack.Push(vertex);
        }

        private Dictionary<int, List<int>> GetTransposedGraph(int[][] adjacency)
        {
            Dictionary<int, List<int>> transposedGraph = new Dictionary<int, List<int>>();
            for (int i = 0; i < adjacency.Length; i++)
            {
                int source = adjacency[i][1];
                int destination = adjacency[i][0];

                if (transposedGraph.ContainsKey(source))
                {
                    transposedGraph[source].Add(destination);
                }
                else
                {
                    transposedGraph[source] = new List<int> { destination };
                }
            }

            return transposedGraph;
        }

        private void TraverseOnTransposed(
            int vertex,
            Dictionary<int, List<int>> transposedGraph,
            List<int> connectedComponents,
            HashSet<int> visited)
        {
            if (visited.Contains(vertex))
            {
                return;
            }

            visited.Add(vertex);

            if (!transposedGraph.ContainsKey(vertex) || transposedGraph[vertex].Count == 0)
            {
                connectedComponents.Add(vertex);
                return;
            }

            for (int i = 0; i < transposedGraph[vertex].Count; i++)
            {
                TraverseOnTransposed(
                    transposedGraph[vertex][i],
                    transposedGraph,
                    connectedComponents,
                    visited);
            }

            connectedComponents.Add(vertex);
        }
    }
}