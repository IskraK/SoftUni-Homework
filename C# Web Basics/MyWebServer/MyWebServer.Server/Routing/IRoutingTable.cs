﻿using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map( Method method, string path, Func<Request,Response> responseFunction);
    }
}
