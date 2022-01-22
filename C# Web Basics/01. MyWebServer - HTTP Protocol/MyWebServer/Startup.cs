// See https://aka.ms/new-console-template for more information
using MyWebServer.Server;
using MyWebServer.Server.HTTP;
using MyWebServer.Server.Responses;
using System;

namespace MyWebServer.Demo
{
    public class Startup
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
                                        Name: <input type='text' name='Name'/>
                                        Age: <input type='number' name ='Age'/>
                                        <input type='submit' value ='Save' />
                                        </form>";

        static void Main(string[] args)
        => new HttpServer(routes => routes
        .MapGet("/", new TextResponse("Hello from the server!"))
        .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
        .MapGet("/HTML", new HtmlResponse(Startup.HtmlForm))
        .MapPost("/HTML", new TextResponse("", Startup.AddFormDataAction)))
            .Start();

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}
