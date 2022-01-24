namespace Practice
{
    public class Solution
    {
        public string IntToRoman(int num)
        {
            int m = 0;
            int c = 0;
            int x = 0;
            int i = 0;

            int mQuo = num / 1000;
            int mRem = num % 1000;
            if (mQuo > 0)
            {
                m = mQuo;
                num = mRem;
            }

            int cQuo = num / 100;
            int cRem = num % 100;
            if (cQuo > 0)
            {
                c = cQuo;
                num = cRem;
            }

            int xQuo = num / 10;
            int xRem = num % 10;
            if (xQuo > 0)
            {
                x = xQuo;
                num = xRem;
            }

            i = num;

            System.Text.StringBuilder result = new System.Text.StringBuilder();

            // Compute M
            for (int j = 1; j <= m; j++)
            {
                result.Append("M");
            }

            // Compute C
            if (c == 9)
            {
                result.Append("CM");
                c = 0;
            }
            else if (c >= 5)
            {
                result.Append("D");
                c = c - 5;
            }
            else if (c == 4)
            {
                result.Append("CD");
                c = 0;
            }

            for (int j = 1; j <= c; j++)
            {
                result.Append("C");
            }

            // Compute X
            if (x == 9)
            {
                result.Append("XC");
                x = 0;
            }
            else if (x >= 5)
            {
                result.Append("L");
                x = x - 5;
            }
            else if (x == 4)
            {
                result.Append("XL");
                x = 0;
            }

            for (int j = 1; j <= x; j++)
            {
                result.Append("X");
            }

            // Compute I
            if (i == 9)
            {
                result.Append("IX");
                i = 0;
            }
            else if (i >= 5)
            {
                result.Append("V");
                i = i - 5;
            }
            else if (i == 4)
            {
                result.Append("IV");
                i = 0;
            }

            for (int j = 1; j <= i; j++)
            {
                result.Append("I");
            }

            return result.ToString();
        }
    }
}