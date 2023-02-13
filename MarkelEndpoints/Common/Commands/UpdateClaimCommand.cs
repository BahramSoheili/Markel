using Markel.CostomerService.Common.Entities;
using Markel.CostomerService.Common.Repositories;
using MediatR;

namespace Markel.CostomerService.Common.Queries;

public class UpdateClaimCommand : IRequest
{
    public UpdateClaimCommand(CompanyClaim Claim)
    {
        this.Claim = Claim;
    }
    public CompanyClaim Claim { get; set; }    
}

public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand>
{
    private readonly ICompanyRepository repository;

    public UpdateClaimCommandHandler(ICompanyRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(UpdateClaimCommand command,
        CancellationToken cancellationToken)
    { 
        await this.repository.UpdateClaim(command.Claim.ClaimId, command.Claim);
        return Unit.Value;
    }
}