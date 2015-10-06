using NUnit.Framework;

namespace WebCrawler.Test
{
    [TestFixture]
    public class WebCrawlerTests
    {
        [Test]
        public void CreateWebCrawler()
        {
            var webCrawler = new Engine.WebCrawler();
            Assert.IsNotNull(webCrawler);
        }

        [Test]
        public void GetTheUrlInformationTest()
        {
            var webCrawler = new Engine.WebCrawler();
            var urlDetails = webCrawler.GetUrlDetails("http://www.rte.ie");
            Assert.IsNotNull(urlDetails);
        }
    }
}