namespace Google
{
    public class Solution
    {
        public string ValidIPAddress(string IP)
        {
            var ipv4Regex = new System.Text.RegularExpressions.Regex(
                @"^(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])$");

            if (ipv4Regex.IsMatch(IP))
            {
                return "IPv4";
            }

            var ipv6Regex = new System.Text.RegularExpressions.Regex(
                @"^((([0-9A-Fa-f]){1,4})\:){7}(([0-9A-Fa-f]){1,4})$");

            if (ipv6Regex.IsMatch(IP))
            {
                return "IPv6";
            }

            return "Neither";
        }
    }
}