﻿using MyWebServer.Demo.Comtrollers;
using MyWebServer.Server;
using MyWebServer.Server.Routing;

namespace MyWebServer.Demo
{
    public class Startup
    {
        public static async Task Main(string[] args)
        {
            await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                .MapGet<HomeController>("/HTML", c => c.Html())
                .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                .MapGet<HomeController>("/Content", c => c.Content())
                .MapPost<HomeController>("/Content", c => c.DownloadContent())
                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                .MapGet<HomeController>("/Session", c => c.Session())
                .MapGet<UsersController>("/Login", c => c.Login())
                .MapPost<UsersController>("/Login", c => c.LoginUser())
                .MapGet<UsersController>("/Logout", c => c.Logout())
                .MapGet<UsersController>("/UserProfile", c => c.GetUserData()))
                .Start();
        }
    }
}
