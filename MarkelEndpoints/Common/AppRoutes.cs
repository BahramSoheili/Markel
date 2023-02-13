namespace MarkelEndpoints.Common;
public static class AppRoutes
{
    private const string BaseRoute = "apps";
    public const string CompanyAcitiveQuery = BaseRoute + "/get-compnay-active-state-policy";
    public const string CompanyClaimsHistory = BaseRoute + "/get-company-claims-history";
    public const string ClaimInfo = BaseRoute + "/get-claim-info";

}