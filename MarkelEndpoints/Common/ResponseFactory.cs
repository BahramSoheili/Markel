using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace Markel.CostomerService.Common;

public static class ResponseFactory
{
    public async static Task<HttpResponseData> CreateOkResponse(this HttpRequestData req, object res)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(res);
        return response;
    }
}
