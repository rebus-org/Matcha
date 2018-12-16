using System;
using NUnit.Framework;
using Testy;

namespace Matcha.Tests
{
    [TestFixture]
    public class TestWildcardPattern : FixtureBase
    {
        [Test]
        public void StarMatchesAnything()
        {
            var wildcardPattern = new WildcardPattern("*");

            for (var counter = 0; counter < 1000; counter++)
            {
                var randomText = Guid.NewGuid().ToString();

                Assert.That(wildcardPattern.IsMatch(randomText), Is.True, 
                    $"Expected that '{randomText}' would match the pattern {wildcardPattern}");
            }
        }

        [Test]
        public void AllPatternsMatchThemselves()
        {
            for (var counter = 0; counter < 1000; counter++)
            {
                var randomText = Guid.NewGuid().ToString();

                var wildcardPattern = new WildcardPattern(randomText);

                Assert.That(wildcardPattern.IsMatch(randomText), Is.True,
                    $"Expected that '{randomText}' would match the pattern {wildcardPattern}");

            }
        }
    }
}
