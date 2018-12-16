using System;
using System.Linq;
using NUnit.Framework;

namespace Matcha.Tests
{
    [TestFixture]
    public class CodeForReadme
    {
        [Test]
        public void ItWorks()
        {
            var fileNames = new[]
            {
                "erika-eleniak.gif",
                "cindy-crawford.jpg",
                "ghita-nørby.GIF"
            };

            var wildcardPattern = new WildcardPattern("*.gif");

            var matches = fileNames.Where(wildcardPattern.IsMatch);

            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}