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
    public class CompanyClaimsFunction
    {
        private readonly IMediator mediator;
        public CompanyClaimsFunction(
            IMediator mediator
        )
        {
            this.mediator = mediator; 
        }       

        [OpenApiBearerSecurity]
        [OpenApiOperation(tags: OpenApiTags.Customer)]
        [OpenApiResponseType(typeof(GetClaimHistoryResponse))]
        [OpenApiQueryParameter(nameof(QueryCompany.CompanyId), typeof(int))]
        [Function("GetCompanyClaims")]
        public async Task<HttpResponseData> Run(
          [HttpTrigger(AuthorizationLevel.Function, "get", Route = AppRoutes.CompanyClaimsHistory)]
        HttpRequestData request)
        {
            var requestBody = JsonSerializer.Deserialize<QueryCompany>(request.Url.Query);
            if (requestBody is not null)
            {
                var query = new GetCompanyClaimsQuery()
                {
                    CompanyId = requestBody.CompanyId
                };
                var queryResponse = await mediator.Send(query);

                return await request.CreateOkResponse(queryResponse);
            }
            throw new Exception();
        }
    }
}
