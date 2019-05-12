using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ShortCircuitMiddleware {
    private RequestDelegate nextDelegate;
    public ShortCircuitMiddleware(RequestDelegate next) {
        nextDelegate = next;
    }

    public async Task Invoke(HttpContext httpContext) {
        if (httpContext.Request.Headers["User-Agent"].Any(h=>h.ToLower().Contains("edge"))) {
            httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        }
        else {
            await nextDelegate.Invoke(httpContext);
        }
    }
}