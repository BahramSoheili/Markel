using Markel.CostomerService.Common.Repositories;
using Markel.CostomerService.Responses;
using MediatR;

namespace Markel.CostomerService.Common.Queries;

public class GetCompanyAcitiveQuery : IRequest<GetCompanyAcitiveQueryResponse>
{
    public GetCompanyAcitiveQuery()
    {
        this.CompanyId = 0;
    }
    public GetCompanyAcitiveQuery(int companyId)
    {
        this.CompanyId = companyId;

    }
    public int CompanyId { get; set; }    
}

public class GetCompanyHandler : IRequestHandler<GetCompanyAcitiveQuery, GetCompanyAcitiveQueryResponse>
{
    private readonly ICompanyRepository repository;
    public GetCompanyHandler(ICompanyRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetCompanyAcitiveQueryResponse> Handle(GetCompanyAcitiveQuery query,
        CancellationToken cancellationToken)
    {
        var company = await repository.GetCompany(query.CompanyId);
        return GetCompanyAcitiveQueryResponse.CreateResponse(company);
    }
}