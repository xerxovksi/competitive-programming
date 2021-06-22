namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
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

            // 0 -> Not processed
            // 1 -> Processing
            // 2 -> Processed
            Dictionary<int, int> color = new Dictionary<int, int>();
            foreach (KeyValuePair<int, List<int>> item in map)
            {
                if (IsCyclic(item.Key, map, color))
                {
                    return false;
                }
            }

            return true;
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
    }
}