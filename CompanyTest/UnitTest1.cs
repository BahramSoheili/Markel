using Markel.CostomerService.Common.Entities;
using Markel.CostomerService.Responses;

namespace CompanyTest
{
    public class UnitTest1
    {
        [Fact]
        public void AcitiveQueryResponse_Shoule_equal_CompanyActive_Test()
        {
            bool expected = true;
            var company = new Company()
            {
                Active= true,
            };
            var companyResult = GetCompanyAcitiveQueryResponse.CreateResponse(company);
            Assert.Equal(expected, companyResult.IsActiveInsurancePolicy.Active);
        }
    }
}