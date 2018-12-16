using System.Text.RegularExpressions;

namespace Matcha
{
    public class WildcardPattern
    {
        readonly string _pattern;
        readonly Regex _regex;

        public WildcardPattern(string pattern)
        {
            var regexPattern = WildcardToRegex(pattern);
            _regex = new Regex(regexPattern);
            _pattern = pattern;
        }

        public bool IsMatch(string text)
        {
            return _regex.IsMatch(text);
        }

        static string WildcardToRegex(string pattern)
        {
            var regex = Regex.Escape(pattern)
                .Replace("\\*", ".*")
                .Replace("\\?", ".");
            
            return $"^{regex}$";
        }

        public override string ToString() => $"{{{_pattern}}}";
    }
}
