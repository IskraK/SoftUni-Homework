﻿using MyWebServer.Server.Controllers;
using MyWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace MyWebServer.Demo.Comtrollers
{
    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        private const string HtmlForm = @"<form action='/HTML' method='POST'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
        </form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
            <input type='submit' value ='Download Sites Content' /> 
        </form>";

        //private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        //{
        //    var downloads = new List<Task<string>>();

        //    foreach (var url in urls)
        //    {
        //        downloads.Add(DownloadWebSiteContent(url));
        //    }

        //    var responses = await Task.WhenAll(downloads);
        //    var responsesString = string.Join(Environment.NewLine + new String('-', 100), responses);
        //    await System.IO.File.WriteAllTextAsync(fileName, responsesString);
        //}

        //private static async Task<string> DownloadWebSiteContent(string url)
        //{
        //    var httpClient = new HttpClient();
        //    using (httpClient)
        //    {
        //        var response = await httpClient.GetAsync(url);
        //        var html = await response.Content.ReadAsStringAsync();

        //        return html.Substring(0, 2000);
        //    }
        //}

        public HomeController(Request request)
        : base(request)
        {

        }

        public Response Index() => Text("Hello from the server!");

        public Response Redirect() => Redirect("https://softuni.org/");

        public Response Html() => Html(HtmlForm);

        public Response HtmlFormPost()
        {
            string formData = String.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content() => Html(DownloadForm);

        //public Response DowmloadContent()
        //{
        //    DownloadSitesAsTextFile(HomeController.FileName,
        //        new string[] { "https://judge.softuni.org/", "https://softuni.org/" })
        //        .Wait();

        //    return File(HomeController.FileName);
        //}

        public Response DownloadContent() => File(FileName);

        public Response Cookies()
        {

            var requestHasCookies = Request.Cookies.Any(c => c.Name != Server.HTTP.Session.SessionCookieName);
            var bodyText = "";

            if (requestHasCookies)
            {
                StringBuilder cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText
                    .Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");

                bodyText = cookieText.ToString();

                return Html(bodyText);
            }
            else
            {
                bodyText = "<h1>Cookies set!</h1>";
            }

            var cookies = new CookieCollection();

            if (!requestHasCookies)
            {
                cookies.Add("My-Cookie", "My-Value");
                cookies.Add("My-Second-Cookie", "My-Second-Value");
            }

            return Html(bodyText, cookies);
        }

        public Response Session()
        {
            var sessionExists = Request.Session.ContainsKey(Server.HTTP.Session.SessionCurrentDateKey);
            var bodyText = "";

            if (sessionExists)
            {
                var currentDate = Request.Session[Server.HTTP.Session.SessionCurrentDateKey];

                bodyText = $"Stored date: {currentDate}";
            }
            else
            {
                bodyText = $"Current date stored!";
            }

            return Text(bodyText);
        }
    }
}
