namespace Practice
{
    /*
    Given an array of numbers and an array of integer pairs, [i,j], increment the array of numbers by one for each index between interval [i,j]
    e.g.
    arr = [1,2,3,4]
    intervals = [[1,3]]
    output [1,3,4,5]
    You're incrementing everything from index 1 to index 3.
    
    arr = [1,2,3,4]
    intervals = [[1,3],[2,3]]
    output [1,3,5,6]
    You're incrementing everything from index 1 to index 3 then index 2 to index 3.
    */

    public class Solution
    {
        /*
        Intervals
        [[1, 3], [2, 3]]

        Array
        [0]     [1]     [2]     [3]     [4]
        1       2       3       4       5
        
        Register
        [0]     [1]     [2]     [3]     [4]
        0       1       1       0       -2

        Desired Result
        1       3       5       6       5
        */
        public int[] IncrementIntervals(int[] arr, int[][] intervals)
        {
            int[] register = new int[arr.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];
                register[start] = register[start] + 1;

                if (end + 1 < arr.Length)
                {
                    register[end + 1] = register[end + 1] - 1;
                }
            }

            int[] result = new int[arr.Length];
            int adder = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                adder += register[i];
                result[i] = arr[i] + adder;
            }

            return result;
        }
    }
}