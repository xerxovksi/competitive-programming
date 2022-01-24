namespace Practice
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (map.ContainsKey(prerequisites[i][0]))
                {
                    map[prerequisites[i][0]].Add(prerequisites[i][1]);
                }
                else
                {
                    map[prerequisites[i][0]] = new List<int> { prerequisites[i][1] };
                }
            }

            Dictionary<int, int> color = new Dictionary<int, int>();
            foreach (KeyValuePair<int, List<int>> item in map)
            {
                if (IsCyclic(item.Key, map, color))
                {
                    return new int[] { };
                }
            }

            HashSet<int> visited = new HashSet<int>();
            HashSet<int> sorted = new HashSet<int>();
            for (int i = 0; i < numCourses; i++)
            {
                TopologicalSort(i, map, visited, sorted);
            }

            return sorted.ToArray();
        }

        private bool IsCyclic(
            int key,
            Dictionary<int, List<int>> map,
            Dictionary<int, int> color)
        {
            if (color.ContainsKey(key))
            {
                if (color[key] == 2)
                {
                    return false;
                }

                if (color[key] == 1)
                {
                    return true;
                }
            }

            color[key] = 1;
            List<int> values = map.ContainsKey(key) ? map[key] : new List<int>();

            for (int i = 0; i < values.Count; i++)
            {
                if (IsCyclic(values[i], map, color))
                {
                    return true;
                }
            }

            color[key] = 2;
            return false;
        }

        private void TopologicalSort(
            int key,
            Dictionary<int, List<int>> map,
            HashSet<int> visited,
            HashSet<int> sorted)
        {
            if (!map.ContainsKey(key) || map[key].Count == 0)
            {
                visited.Add(key);
                sorted.Add(key);

                return;
            }

            visited.Add(key);
            List<int> values = map.ContainsKey(key) ? map[key] : new List<int>();
            for (int i = 0; i < values.Count; i++)
            {
                if (visited.Contains(values[i]))
                {
                    continue;
                }

                TopologicalSort(values[i], map, visited, sorted);
            }

            if (!sorted.Contains(key))
            {
                sorted.Add(key);
            }
        }
    }
}