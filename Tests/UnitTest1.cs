using System;
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
            // regular tests
            Assert.AreEqual("P8HBlHZmahdz",Skylight.Tools.ParseUrl("http://everybodyedits.com/games/P8HBlHZmahdz"));
            Assert.AreEqual("PWmSN5eRsWbkI", Skylight.Tools.ParseUrl("http://everybodyedits.com/games/PWmSN5eRsWbkI"));
            Assert.AreEqual("PWUQP6-FgpbkI", Skylight.Tools.ParseUrl("http://everybodyedits.com/games/PWUQP6-FgpbkI"));
        
            // too much whitespace

            Assert.AreEqual("PWEYhVZmR3bUI", Skylight.Tools.ParseUrl("   http://everybodyedits.com/games / PWEYhVZmR3bUI     "));
            Assert.AreEqual("PW5HSvgjKybUI", Skylight.Tools.ParseUrl("http:// everybodyedits.com/games/PW5HSvgjKybUI                          "));
            
            // malformed url
            Assert.AreEqual("PWUQP6-FgpbkI", Skylight.Tools.ParseUrl("http://everybodyeditz4.com/games/PWUQP6-FgpbkI"));
            Assert.AreEqual("PWUQP6FgpbkI", Skylight.Tools.ParseUrl("https://everybodyedits.com/games/PWUQP6FgpbkI"));
            Assert.AreEqual("PWUQP6-FgpbkI", Skylight.Tools.ParseUrl("hello://example.com/gazdsadasmes/PWUQP6-FgpbkI"));
            Assert.AreEqual("PWUQP6-FgpbkI", Skylight.Tools.ParseUrl("http://nothinghellocool.ca/PWUQP6-FgpbkI"));

            // missing urls but valid room names
            Assert.AreEqual("PWUQP6-FgpbkI", Skylight.Tools.ParseUrl("PWUQP6-FgpbkI"));
            Assert.AreEqual("PWUQP6-FgpbkI", Skylight.Tools.ParseUrl("  PWUQP6      -FgpbkI       "));
        }
    }
}
