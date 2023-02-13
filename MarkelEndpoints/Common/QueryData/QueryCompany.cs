namespace Markel.CostomerService.Common.QueryData;

public class QueryCompany
{
    public int CompanyId { get; set; }
    public QueryCompany()
    {
        CompanyId = 0;
    }
    public QueryCompany(int CompanyId)
    {
        this.CompanyId = CompanyId;
    }
    public static QueryCompany Create(int CompanyId)
    {

        return new QueryCompany(CompanyId);
    }

}
