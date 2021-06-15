namespace Google
{
  public class Solution
  {
    public string RomanToInt(string s)
    {
      s = s.Replace("CM", "m")
        .Replace("CD", "d")
        .Replace("XC", "c")
        .Replace("XL", "l")
        .Replace("IX", "x")
        .Replace("IV", "v");

      int result = 0;
      string running = s[0].ToString();
      char last = s[0];
      for (int i = 1; i < s.Length; i++)
      {
        if (s[i] == last)
        {
          running = running + s[i];
        }
        else
        {
          result = result + GetInt(running);
          running = s[i].ToString();
          last = s[i];
        }
      }

      result = result + GetInt(running);
      return result;
    }

    private int GetInt(string s)
    {
      int mul = s.Length;
      char ch = s[0];
      switch (ch)
      {
        case 'M': return 1000 * mul;
        case 'm': return 900;
        case 'D': return 500;
        case 'd': return 400;
        case 'C': return 100 * mul;
        case 'c': return 90;
        case 'L': return 50;
        case 'l': return 40;
        case 'X': return 10 * mul;
        case 'x': return 9;
        case 'V': return 5;
        case 'v': return 4;
        case 'I': return 1 * mul;
        default: throw new InvalidOperationException("Unidentified character.");
      }
    }
  }
}