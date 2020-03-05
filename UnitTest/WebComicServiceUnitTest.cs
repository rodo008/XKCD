using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace UnitTestProject
{
    [TestClass]
    public class WebComicServiceUnitTest
    {

        public  const string TODAY_COMIC_URL = "https://xkcd.com/info.0.json";
        public const string COMIC_URL_TPL = "https://xkcd.com/{0}/info.0.json";

        [TestMethod]
        public void GetComicByCodeTest()
        {

            WebComicService svc = new WebComicService();
            var response = svc.GetComicByCode(1,COMIC_URL_TPL).Result;

            Assert.IsTrue(response.Success);
        }


        [TestMethod]
        public void GetTodayComicTest() {

            WebComicService svc = new WebComicService();
            var response = svc.GetTodayComic(TODAY_COMIC_URL).Result;

            Assert.IsTrue(response.Success);
        }



        [TestMethod]
        public void GetComicFromURLTest()
        {

            WebComicService svc = new WebComicService();
            var response = svc.GetComicFromUrl(TODAY_COMIC_URL).Result;

            Assert.IsTrue(response.Success);
        }
    }
}
