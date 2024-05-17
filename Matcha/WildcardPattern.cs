using System;
using System.Text.RegularExpressions;

namespace Matcha;

public class WildcardPattern
{
    readonly string _pattern;
    readonly Regex _regex;

    public WildcardPattern(string pattern, WildcardOptions options = WildcardOptions.None)
    {
        if (pattern == null) throw new ArgumentNullException(nameof(pattern));
        var regexPattern = WildcardToRegex(pattern);
        _regex = new Regex(regexPattern, GetFlags(options));
        _pattern = pattern;
    }

    public bool IsMatch(string text) => _regex.IsMatch(text);

    public override string ToString() => $"{{{_pattern}}}";

    static string WildcardToRegex(string pattern)
    {
        var regex = Regex.Escape(pattern)
            .Replace("\\*", ".*")
            .Replace("\\?", ".");

        return $"^{regex}$";
    }

    static RegexOptions GetFlags(WildcardOptions options)
    {
        var regexOptions = RegexOptions.None;

        bool HasFlag(WildcardOptions flag) => (options & flag) == flag;

        if (HasFlag(WildcardOptions.IgnoreCase))
        {
            regexOptions |= RegexOptions.IgnoreCase;
        }

        if (HasFlag(WildcardOptions.CultureInvariant))
        {
            regexOptions |= RegexOptions.CultureInvariant;
        }

        return regexOptions;
    }
}