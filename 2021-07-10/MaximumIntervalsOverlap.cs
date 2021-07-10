namespace Google
{
    using System;
    using System.Linq;

    public class Solution
    {
        public int MaximumOverlaps(int[][] intervals)
        {
            int[] arrivals = intervals.Select(item => item[0]).ToArray();
            int[] departures = intervals.Select(item => item[1]).ToArray();

            Array.Sort(arrivals);
            Array.Sort(departures);

            int low = arrivals[0];
            int high = departures[departures.Length - 1];

            int i = 0;
            int j = 0;

            int attendance = 0;
            int maxAttendance = 0;
            int maxTime = 0;

            while (i < arrivals.Length)
            {
                if (arrivals[i] <= departures[j])
                {
                    attendance++;
                    if (attendance > maxAttendance)
                    {
                        maxAttendance = attendance;
                        maxTime = arrivals[i];
                    }

                    i++;
                }
                else
                {
                    attendance--;
                    j++;
                }
            }

            return maxAttendance;
        }

        public int MaximumOverlapsFast(int[][] intervals)
        {
            int[] arrivals = intervals.Select(item => item[0]).ToArray();
            int[] departures = intervals.Select(item => item[1]).ToArray();

            int high = departures[0];
            for (int i = 1; i < departures.Length; i++)
            {
                high = Math.Max(high, departures[i]);
            }

            int[] register = new int[high + 2];
            for (int i = 0; i < arrivals.Length; i++)
            {
                register[arrivals[i]] = register[arrivals[i]] + 1;
                register[departures[i] + 1] = register[departures[i] + 1] - 1;
            }

            int attendance = 0;
            int maxAttendance = 0;
            int maxTime = 0;

            for (int i = 0; i < register.Length; i++)
            {
                attendance = attendance + register[i];
                if (attendance > maxAttendance)
                {
                    maxAttendance = attendance;
                    maxTime = i;
                }
            }

            return maxAttendance;
        }
    }
}