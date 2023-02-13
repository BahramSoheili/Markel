using System.Text.Json;
using Markel.CostomerService.Common;
using Markel.CostomerService.Common.OpenApi;
using Markel.CostomerService.Common.OpenApi.Attributes;
using Markel.CostomerService.Common.Queries;
using Markel.CostomerService.Common.QueryData;
using Markel.CostomerService.Responses;
using MarkelEndpoints.Common;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

namespace Markel.CostomerService.Functions
{
    public class ClaimFunction
    {
        private readonly IMediator mediator;


        public ClaimFunction(
            IMediator mediator
        )
        {
            this.mediator = mediator; 
        }

        [OpenApiBearerSecurity]
        [OpenApiOperation(tags: OpenApiTags.Customer)]
        [OpenApiResponseType(typeof(GetClaimInfoResponse))]
        [OpenApiQueryParameter(nameof(QueryClaim.ClaimId), typeof(int))]
        [Function("GetClaimInfo")]
        public async Task<HttpResponseData> Run(
          [HttpTrigger(AuthorizationLevel.Function, "get", Route = AppRoutes.ClaimInfo)]
        HttpRequestData request)
        {
            var requestBody = JsonSerializer.Deserialize<QueryClaim>(request.Url.Query);
            if (requestBody is not null)
            {
                var query = new GetClaimQuery()
                {
                    ClaimId = requestBody.ClaimId
                };
                var queryResponse = await mediator.Send(query);

                return await request.CreateOkResponse(queryResponse);
            }
            throw new Exception();
        }
    }
}
