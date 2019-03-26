using NUnit.Framework;
using System.Net.Http;
using Shouldly;

namespace Tests
{
    public class Tests : With_Setup
    {

        [Test]
        public void Test1_GETHomepage_AsserUsingNUnit()
        {
            HttpResponseMessage response = GetHttpClient().GetAsync("/Home").Result;
            string rawhtml = response.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(rawhtml.Contains("Welcome"));
        }

        [Test]
        public void Test2_GETHomepage_AssertUsingShouldy()
        {
            HttpResponseMessage response = GetHttpClient().GetAsync("/Home").Result;
            string rawhtml = response.Content.ReadAsStringAsync().Result;
            rawhtml.ShouldMatchApproved();
                //(c =>
            //{
            //    c.SubFolder("Approvals");
            //    //c.WithScrubber(TimeScrubber);
            //});



        }
    }
}