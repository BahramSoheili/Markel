using System.Data;
using Dapper;
using Markel.CostomerService.Common.DBContext;
using Markel.CostomerService.Common.Entities;
using MediatR;

namespace Markel.CostomerService.Common.Repositories;

public class CompanyRepository : ICompanyRepository
{
private readonly DapperContext context;

public CompanyRepository(DapperContext context)
{
    this.context = context;
}

public async Task<Company> GetCompany(int? id)
{
    var query = "SELECT * FROM Companies WHERE Id = @Id";

    using (var connection = context.CreateConnection())
    {
        var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
        return company;
    }
}

public async Task<CompanyClaim> GetClaim(int? id)
{
    var query = "SELECT * FROM Claims WHERE Id = @Id";

    using (var connection = context.CreateConnection())
    {
        var claim = await connection.QuerySingleOrDefaultAsync<CompanyClaim>(query, new { id });
        return claim;
    }
}

public async Task<IEnumerable<CompanyClaim>> GetCompanyClaims(int? CompanyId)
{
    var query = "SELECT * FROM Claims WHERE CompanyId = @Id";

    using (var connection = context.CreateConnection())
    {
        var claims = await connection.QueryAsync<CompanyClaim>(query , new { CompanyId });
        return claims.ToList();
    }
}

public async Task<Unit> UpdateClaim(int id, CompanyClaim claim)
{
    var query = "UPDATE Claims SET UCR=@UCR, CompanyId=@CompanyId, ClaimDate=@ClaimDate, LossDate=@LossDate, AssuredName=@AssuredName, IncurredLoss=@IncurredLoss, Closed=@Closed WHERE Id = @Id";

    var parameters = new DynamicParameters();
    parameters.Add("ClaimId", claim.ClaimId, DbType.Int32);
    parameters.Add("UCR", claim.UCR, DbType.String);
    parameters.Add("CompanyId", claim.CompanyId, DbType.String);
    parameters.Add("ClaimDate", claim.ClaimDate, DbType.DateTime);
    parameters.Add("LossDate", claim.LossDate, DbType.DateTime);
    parameters.Add("AssuredName", claim.AssuredName, DbType.String);
    parameters.Add("IncurredLoss", claim.IncurredLoss, DbType.Decimal);
    parameters.Add("Closed", claim.Closed, DbType.Boolean);

    using (var connection = context.CreateConnection())
    {
        await connection.ExecuteAsync(query, parameters);
    }
        return Unit.Value;

    }
}

