namespace Google
{
    public class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int tank = 0;
            int remaining = 0;
            int startIndex = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                tank += gas[i] - cost[i];
                remaining += gas[i] - cost[i];

                if (tank < 0)
                {
                    startIndex = i + 1;
                    tank = 0;
                }
            }

            return remaining >= 0 ? startIndex : -1;
        }
    }
}