# Matcha

It's just a wildcard matcher.

Can sometimes be used as a drop-in replacement for System.Management.Automation's `WildcardPattern`.

You can use it like this:
```csharp
var fileNames = new[]
{
    "erika-eleniak.gif",
    "cindy-crawford.jpg",
    "ghita-nørby.GIF"
};

var wildcardPattern = new WildcardPattern("*.gif", WildcardOptions.IgnoreCase);

var matches = fileNames.Where(wildcardPattern.IsMatch);

Console.WriteLine(string.Join(Environment.NewLine, matches));
```
and that's basically it.