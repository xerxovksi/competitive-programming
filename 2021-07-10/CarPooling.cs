namespace Google
{
    public class Solution
    {
        public bool CarPooling(int[][] trips, int capacity)
        {
            int[] passengers = trips.Select(item => item[0]).ToArray();
            int[] arrivals = trips.Select(item => item[1]).ToArray();
            int[] departures = trips.Select(item => item[2]).ToArray();

            int high = departures[0];
            for (int i = 1; i < departures.Length; i++)
            {
                high = Math.Max(high, departures[i]);
            }

            int[] register = new int[high + 1];
            for (int i = 0; i < arrivals.Length; i++)
            {
                register[arrivals[i]] = register[arrivals[i]] + passengers[i];
                register[departures[i]] = register[departures[i]] - passengers[i];
            }

            int attendance = 0;
            int maxAttendance = 0;

            for (int i = 0; i < register.Length; i++)
            {
                attendance = attendance + register[i];
                maxAttendance = Math.Max(maxAttendance, attendance);
            }

            return maxAttendance <= capacity;
        }
    }
}