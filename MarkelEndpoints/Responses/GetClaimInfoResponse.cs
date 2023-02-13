using Markel.CostomerService.Common.Entities;

namespace Markel.CostomerService.Responses;

public class GetClaimInfoResponse
{
    public ClaimInfoResponse ClaimInfo { get; set; }
    public static GetClaimInfoResponse CreateResponse(CompanyClaim claim)
    {
        var ClaimOld = (DateTime.Now - claim.ClaimDate).Days;
        return new GetClaimInfoResponse
        {
            ClaimInfo = new ClaimInfoResponse(claim, ClaimOld),
        };
    }

    public record struct ClaimInfoResponse(CompanyClaim Claim, int ClaimOld);
}
