namespace Practice
{
    public class Solution
    {
        public string ZigZagConversion(string s, int numRows)
        {
            if (s.Length <= numRows || numRows == 1)
            {
                return s;
            }

            int row = 0;
            int column = 0;
            bool isDiagonal = false;

            char[,] result = new char[numRows, s.Length - numRows + 1];
            for (int i = 0; i < s.Length; i++)
            {
                if (row < numRows && !isDiagonal)
                {
                    result[row, column] = s[i];
                    row++;
                    continue;
                }

                if (row == numRows)
                {
                    isDiagonal = true;
                    row--;
                }

                row--;
                column++;
                result[row, column] = s[i];

                if (row == 0 && isDiagonal)
                {
                    isDiagonal = false;
                    row++;
                }
            }

            var output = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j <= column; j++)
                {
                    if (result[i, j] != '0')
                    {
                        output += result[i, j];
                    }
                }
            }

            return output;
        }
    }
}