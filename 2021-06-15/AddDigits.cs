namespace Practice
{
    public class Solution
    {
        public int AddDigits(int num)
        {
            while (num / 10 > 0)
            {
                int digitSum = 0;
                for (int i = num; i > 0; i = i / 10)
                {
                    digitSum = digitSum + (i % 10);
                }

                num = digitSum;
            }

            return num;
        }
    }
}