using System.Web;

namespace MyWebServer.Server.HTTP
{
    public class Request
    {
        private static Dictionary<string, Session> Sessions = new();

        public Method Method { get; private set; }
        public string Url { get; private set; }
        public HeaderCollection Headers { get; private set; }
        public CookieCollection Cookies { get; private set; }
        public string Body { get; private set; }

        public Session Session { get; private set; }

        public IReadOnlyDictionary<string,string> Form { get; private set; }

        public static Request Parse(string strRequest)
        {
            var lines = strRequest.Split("\r\n");

            var firstLine = lines.First().Split(" ");

            Method method = ParseMethod(firstLine[0]);
            var url = firstLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));

            CookieCollection cookies = ParseCookies(headers);

            var session = GetSession(cookies);

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            string body = string.Join("\r\n", bodyLines);

            var form = ParseForm(headers, body);
            
            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Cookies= cookies,
                Body = body,
                Session = session,
                Form = form
            };
        }

        private static Session GetSession(CookieCollection cookies)
        {
            var sessionId=cookies.Comtains(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new Session(sessionId);
            }
            
            return Sessions[sessionId];
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookieCollection=new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                var cookoieHeader = headers[Header.Cookie];

                var allCookies=cookoieHeader.Split(';');

                foreach (var cookieText in allCookies)
                {
                    var cookieParts=cookieText.Split('=');

                    var cookieName = cookieParts[0].Trim();
                    var cookieValue = cookieParts[1].Trim();

                    cookieCollection.Add(cookieName, cookieValue);
                }
            }
            return cookieCollection;
        }

        private static Dictionary<string,string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType) && headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
            => HttpUtility.UrlDecode(bodyLines)
            .Split('&')
            .Select(part => part.Split('='))
            .Where(part => part.Length == 2)
            .ToDictionary(part => part[0], part => part[1], StringComparer.InvariantCultureIgnoreCase);
        

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == String.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request headers is not valid");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
                //return Enum.Parse<Method>(method);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported");
            }
        }
    }
}
