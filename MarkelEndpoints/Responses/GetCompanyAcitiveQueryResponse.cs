using Markel.CostomerService.Common.Entities;

namespace Markel.CostomerService.Responses;

public class GetCompanyAcitiveQueryResponse
{
    public CompanyAcitiveQueryResponse IsActiveInsurancePolicy { get; set; } = 
        
        new CompanyAcitiveQueryResponse(false);

    public static GetCompanyAcitiveQueryResponse CreateResponse(Company compnay)
    {
        return new GetCompanyAcitiveQueryResponse
        {
            IsActiveInsurancePolicy = new CompanyAcitiveQueryResponse(compnay.Active)
        };
    }

    public record struct CompanyAcitiveQueryResponse(bool Active);
}
