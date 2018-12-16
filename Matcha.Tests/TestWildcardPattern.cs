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

        [TestCase("hej med * min ven", "hej med dig min ven", true)]
        [TestCase("hej med * min ven", "hej med JIGFJ#FGUF#)=F#=F)#=JF#=F#F=#=FJ)#=FJ)=# min ven", true)]
        [TestCase("hej med * min ven", "hej med JIGFJ#FGUF#)=F#=F)#=JF#=F#F=#=FJ)#=FJ)=# min homie", false)]
        [TestCase("d?ng d?ng har du set min bong", "ding dong har du set min bong", true)]
        [TestCase("d?ng d?ng har du set min bong", "ding ding har du set min bong", true)]
        [TestCase("d?ng d?ng har du set min bong", "dong dong har du set min bong", true)]
        [TestCase("d?ng d?ng har du set min bong", "ding dong har du set min øl", false)]
        public void CheckThis(string pattern, string input, bool expectedResult)
        {
            var wildcardPattern = new WildcardPattern(pattern);

            var isMatch = wildcardPattern.IsMatch(input);

            Console.WriteLine($@"

Pattern: {pattern}
  Input: {input}

  Match: {isMatch}

");

            Assert.That(isMatch, Is.EqualTo(expectedResult));
        }
    }
}
