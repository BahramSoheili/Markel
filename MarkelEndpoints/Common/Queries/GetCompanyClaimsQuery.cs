using Markel.CostomerService.Common.Entities;
using Markel.CostomerService.Common.Repositories;
using Markel.CostomerService.Responses;
using MediatR;

namespace Markel.CostomerService.Common.Queries;

public class GetCompanyClaimsQuery : IRequest<GetClaimHistoryResponse>
{
    public GetCompanyClaimsQuery()
    {
        this.CompanyId = 0;
    }   
    public GetCompanyClaimsQuery(int companyId)
    {
        this.CompanyId = companyId;

    }
    public int CompanyId { get; set; }    
}

public class GetCompanyClaimsHandler : IRequestHandler<GetCompanyClaimsQuery, GetClaimHistoryResponse>
{
    private readonly ICompanyRepository repository;
    public GetCompanyClaimsHandler(ICompanyRepository repository)
    {
        this.repository = repository;
    }
    public async Task<GetClaimHistoryResponse> Handle(GetCompanyClaimsQuery query,
        CancellationToken cancellationToken)
    {
        IEnumerable<CompanyClaim> claims = await repository.GetCompanyClaims(query.CompanyId);
        return GetClaimHistoryResponse.CreateResponse(claims);

    }
}