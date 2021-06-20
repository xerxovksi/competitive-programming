namespace Google
{
    public class Solution
    {
        private bool[][] visited;

        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            visited = new bool[rows][];
            for (int i = 0; i < rows; i++)
            {
                visited[i] = new bool[cols];
                for (int j = 0; j < cols; j++)
                {
                    visited[i][j] = false;
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0] && Exist(i, j, 0, board, word))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Exist(int i, int j, int index, char[][] board, string word)
        {
            if (index == word.Length)
            {
                return true;
            }

            if (i < 0
                || i >= board.Length
                || j < 0
                || j >= board[0].Length
                || visited[i][j]
                || board[i][j] != word[i])
            {
                return false;
            }

            visited[i][j] = true;
            if (Exist(i + 1, j, index + 1, board, word)
                || Exist(i - 1, j, index + 1, board, word)
                || Exist(i, j + 1, index + 1, board, word)
                || Exist(i, j - 1, index + 1, board, word))
            {
                return true;
            }

            visited[i][j] = false;
            return false;
        }
    }
}