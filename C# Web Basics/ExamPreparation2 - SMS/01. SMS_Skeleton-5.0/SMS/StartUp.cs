﻿namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Data;
    using SMS.Services;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<IPasswordHasher,PasswordHasher>()
                .Add<IValidationService, ValidationService>()
                .Add<SMSDbContext>()
                .Add<IViewEngine, CompilationViewEngine>())
                .Start();
    }
}