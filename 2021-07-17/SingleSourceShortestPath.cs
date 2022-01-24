namespace Practice
{
    using System;
    using System.Collections.Generic;

    public class Edge
    {
        public int Destination { get; set; }

        public int Distance { get; set; }

        public Edge(int destination, int distance)
        {
            this.Destination = destination;
            this.Distance = distance;
        }
    }

    public class SingleSourceShortestPath
    {
        public IList<IList<int>> DijkstraAlgorithm(int[][] adjacency, int source)
        {
            Dictionary<int, List<Edge>> graph = this.GetGraph(adjacency);
            Dictionary<int, int> weightedVertices = this.GetWeightedVertices(adjacency, source);

            HashSet<int> seen = new HashSet<int>();
            int i = 0;
            int limit = weightedVertices.Count - 1;

            while (i < limit)
            {
                int minVertex = source;
                int minWeight = int.MaxValue;

                foreach (var weightedVertex in weightedVertices)
                {
                    if (seen.Contains(weightedVertex.Key))
                    {
                        continue;
                    }

                    if (weightedVertex.Value < minWeight)
                    {
                        minVertex = weightedVertex.Key;
                        minWeight = weightedVertex.Value;
                    }
                }

                seen.Add(minVertex);
                if (!graph.ContainsKey(minVertex) || graph[minVertex].Count == 0)
                {
                    i++;
                    continue;
                }

                foreach (var edge in graph[minVertex])
                {
                    weightedVertices[edge.Destination] = Math.Min(
                        weightedVertices[edge.Destination],
                        weightedVertices[minVertex] + edge.Distance);
                }

                i++;
            }

            IList<IList<int>> result = new List<IList<int>>();
            foreach (var item in weightedVertices)
            {
                result.Add(new List<int> { item.Key, item.Value });
            }

            return result;
        }

        private Dictionary<int, List<Edge>> GetGraph(int[][] adjacency)
        {
            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < adjacency.Length; i++)
            {
                int source = adjacency[i][0];
                int destination = adjacency[i][1];
                int distance = adjacency[i][2];

                if (graph.ContainsKey(source))
                {
                    graph[source].Add(new Edge(destination, distance));
                }
                else
                {
                    graph[source] = new List<Edge> { new Edge(destination, distance) };
                }
            }

            return graph;
        }

        private Dictionary<int, int> GetWeightedVertices(int[][] adjacency, int sourceVertex)
        {
            HashSet<int> seen = new HashSet<int>();
            Dictionary<int, int> vertices = new Dictionary<int, int>();

            for (int i = 0; i < adjacency.Length; i++)
            {
                int source = adjacency[i][0];
                int destination = adjacency[i][1];

                if (!seen.Contains(source))
                {
                    vertices.Add(source, source == sourceVertex ? 0 : int.MaxValue);
                    seen.Add(source);
                }

                if (!seen.Contains(destination))
                {
                    vertices.Add(destination, destination == sourceVertex ? 0 : int.MaxValue);
                    seen.Add(destination);
                }
            }

            return vertices;
        }
    }
}