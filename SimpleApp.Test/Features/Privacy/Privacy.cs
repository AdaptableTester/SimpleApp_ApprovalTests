using NUnit.Framework;
using System.Net.Http;
using Shouldly;

namespace Tests
{
    public class PrivacyPageTests : With_Setup
    {
        [Test]
        public void Test1_GETPrivacyPage_UsingNunit()
        {
            HttpResponseMessage response = GetHttpClient().GetAsync("/Home/Privacy").Result;
            string rawhtml = response.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(rawhtml.Contains("Privacy"));
        }
        [Test]
        public void Test2_GETPrivacyPage_UsingShouldly()
        {
            HttpResponseMessage response = GetHttpClient().GetAsync("/Home/Privacy").Result;
            string rawhtml = response.Content.ReadAsStringAsync().Result;
            rawhtml.ShouldMatchApproved(c =>
            {
                c.SubFolder("Approvals");
            });
        }
    }
}
