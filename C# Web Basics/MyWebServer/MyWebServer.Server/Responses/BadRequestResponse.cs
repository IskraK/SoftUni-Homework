using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}
