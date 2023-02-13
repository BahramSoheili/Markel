using System.Text.Json;
using Markel.CostomerService.Common.Entities;
using Markel.CostomerService.Common.OpenApi;
using Markel.CostomerService.Common.OpenApi.Attributes;
using Markel.CostomerService.Common.Queries;
using Markel.CostomerService.Responses;
using MarkelEndpoints.Common;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

namespace Markel.CostomerService.Functions
{
    public class ClaimUpdateFunction
    {
        private readonly IMediator mediator;
        public ClaimUpdateFunction(IMediator mediator)
        {
            this.mediator = mediator; 
        }  

        [OpenApiBearerSecurity]
        [OpenApiOperation(tags: OpenApiTags.Customer)]
        [OpenApiResponseType(typeof(GetClaimInfoResponse))]
        [OpenApiQueryParameter(nameof(CompanyClaim), typeof(CompanyClaim))]
        [Function("UpdateClaim")]
        public async Task Run(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = AppRoutes.ClaimInfo)]
        HttpRequestData request)
        {
            var requestBody = JsonSerializer.Deserialize<CompanyClaim>(request.Url.Query);
            if (requestBody is not null)
            {
                var command = new UpdateClaimCommand(requestBody);

                await mediator.Send(command);
            }
            throw new Exception();
        }

    }
}
