using Markel.CostomerService.Common.Entities;

namespace Markel.CostomerService.Responses;

public class GetClaimHistoryResponse
{
    public IEnumerable<ClaimHistoryResponse> Claims { get; set; } = Enumerable.Empty<ClaimHistoryResponse>();
    public static GetClaimHistoryResponse CreateResponse(IEnumerable<CompanyClaim> claims)
    {
        return new GetClaimHistoryResponse
        {
            Claims= claims.Select(c=> new ClaimHistoryResponse(c))
        };
    }

    public record struct ClaimHistoryResponse(CompanyClaim Claim);
}