using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace Concessionaria.Api.Infra.Configuration
{
    public class AuthApiController : ApiController
    {
        protected IHttpActionResult Content(HttpStatusCode statusCode, IEnumerable<string> messages)
        {
            return base.Content(statusCode, new Response(statusCode, messages));
        }

        protected IHttpActionResult Content<T>(HttpStatusCode statusCode, T content, int totalLength)
        {
            return base.Content(statusCode, new Response<T>(statusCode, content, totalLength));
        }

        protected IHttpActionResult Content<T>(HttpStatusCode statusCode, T content, IEnumerable<string> messages)
        {
            return base.Content(statusCode, new Response<T>(statusCode, content, messages));
        }

        protected new IHttpActionResult Ok() => base.Ok(new Response(HttpStatusCode.OK));

        protected new IHttpActionResult Ok<T>(T content) => Content(HttpStatusCode.OK, content, null);

        protected IHttpActionResult Ok<T>(T content, int totalLength) => Content(HttpStatusCode.OK, content, totalLength);

        protected new IHttpActionResult BadRequest(string message) => Content(HttpStatusCode.BadRequest, new[] { message });

        protected new IHttpActionResult StatusCode(HttpStatusCode status) => base.Content(status, new Response(status));
    }
}