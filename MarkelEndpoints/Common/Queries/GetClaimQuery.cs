using Markel.CostomerService.Common.Repositories;
using Markel.CostomerService.Responses;
using MediatR;
namespace Markel.CostomerService.Common.Queries;

public class GetClaimQuery : IRequest<GetClaimInfoResponse>
{
    public GetClaimQuery()
    {
        this.ClaimId = 0;
    }
    public GetClaimQuery(int claimId)
    {
        this.ClaimId = claimId;

    }
    public int ClaimId { get; set; }    
}

public class GetClaimHandler : IRequestHandler<GetClaimQuery, GetClaimInfoResponse>
{
    private readonly ICompanyRepository repository;

    public GetClaimHandler(ICompanyRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetClaimInfoResponse> Handle(GetClaimQuery query,
        CancellationToken cancellationToken)
    {
        var claim = await repository.GetClaim(query.ClaimId);
        return GetClaimInfoResponse.CreateResponse(claim);

    }
}