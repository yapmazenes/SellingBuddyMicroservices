using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Web.ApiGateway.Infrastructure
{
    public class HttpClientDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpClientDelegatingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                if (request.Headers.Contains("Authorization"))
                    request.Headers.Remove("Authorization");

                request.Headers.Add("Authorization", new List<string>(authorizationHeader));
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
