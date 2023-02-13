using Markel.CostomerService.Common.Entities;
using MediatR;

namespace Markel.CostomerService.Common.Repositories;

public interface ICompanyRepository
{
    Task<Company> GetCompany(int? id);
    Task<CompanyClaim> GetClaim(int? id);
    Task<IEnumerable<CompanyClaim>> GetCompanyClaims(int? CompanyId);
    Task<Unit> UpdateClaim(int id, CompanyClaim claim);
}