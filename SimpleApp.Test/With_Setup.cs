using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using NUnit.Framework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Shouldly;

namespace Tests
{
    public class With_Setup
    {

        public HttpClient GetHttpClient()
        {
            //config/creation of website
            var builder = new WebHostBuilder()
                .UseContentRoot(@"C:\Users\shail\source\repos\SimpleAPP\SimpleAPP")
                .UseEnvironment("Development")
                .UseStartup<SimpleAPP.Startup>();

            // Hosting a testserver on the website (in memory) 
            TestServer testserver = new TestServer(builder);
            // Create client (in memory) - like a browser
            HttpClient client = testserver.CreateClient();

            return client;

        }

        public static Func<string, string> DateScrubber = s => Regex.Replace(s, @"\d{1,2}/\d{1,2}/\d{2,4}", "<date>");

        public static Func<string, string> TimeScrubber = s => Regex.Replace(s, @"([01]?[0-9]|2[0-3]):[0-5][0-9]", "<time>");

        public static Func<string, string> TimeWithSecondsScrubber = s => Regex.Replace(s, @"([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]", "<longtime>");

        public static Func<string, string> MyDateScrubber = s => Regex.Replace(s, @"\d{1,2}(\s|-)+(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(\s|-)+\d{2,4}", "<date>");

        public static Func<string, string> GuidScrubber = s => Regex.Replace(s, @"(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})", "<guid>");
    }
}

