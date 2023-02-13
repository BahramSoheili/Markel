namespace Markel.CostomerService.Common.QueryData;

public class QueryClaim
{
    public int ClaimId { get; set; }

    public QueryClaim()
    {
        ClaimId = 0;
    }

    public QueryClaim(int ClaimId)
    {
        this.ClaimId = ClaimId;
    }

    public static QueryClaim Create(int ClaimId)
    {
        return new QueryClaim(ClaimId);
    }
}
