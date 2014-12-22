using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skylight;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // simple tests
            Assert.AreEqual("P8NZA-_09d8", Tools.ParseUrl("P8NZA-_09d8"));

            // regular tests
            Assert.AreEqual("P8HBlHZmahdz", Tools.ParseUrl("http://everybodyedits.com/games/P8HBlHZmahdz"));
            Assert.AreEqual("PWmSN5eRsWbkI", Tools.ParseUrl("http://everybodyedits.com/games/PWmSN5eRsWbkI"));
            Assert.AreEqual("PWUQP6-FgpbkI", Tools.ParseUrl("http://everybodyedits.com/games/PWUQP6-FgpbkI"));

            // too much whitespace
            Assert.AreEqual("PWEYhVZmR3bUI", Tools.ParseUrl("   http://everybodyedits.com/games /PWEYhVZmR3bUI     "));
            Assert.AreEqual("PW5HSvgjKybUI",
                Tools.ParseUrl("http://everybodyedits.com/games/PW5HSvgjKybUI                          "));

            // malformed url
            Assert.AreEqual("PWUQP6-FgpbkI", Tools.ParseUrl("http://everybodyeditz4.com/games/PWUQP6-FgpbkI"));
            Assert.AreEqual("PWUQP6FgpbkI", Tools.ParseUrl("https://everybodyedits.com/games/PWUQP6FgpbkI"));
            Assert.AreEqual("PWUQP6-FgpbkI", Tools.ParseUrl("https://example.com/gazdsadasmes/PWUQP6-FgpbkI"));
            Assert.AreEqual("PWUQP6-FgpbkI", Tools.ParseUrl("http://nothinghellocool.ca/PWUQP6-FgpbkI"));
        }
    }
}