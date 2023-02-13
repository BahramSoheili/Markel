namespace Markel.CostomerService.Common.Entities;
public class CompanyClaim
{
    public int ClaimId { get; set; }
    public string UCR { get; set; }
    public int CompanyId { get; set; }
    public DateTime ClaimDate { get; set; }
    public DateTime LossDate { get; set; }
    public string AssuredName { get; set; }
    public decimal IncurredLoss { get; set; }
    public bool Closed { get; set; }     
    public CompanyClaim()
    {
        this.UCR = string.Empty;
        this.CompanyId = 0;
        this.ClaimDate = DateTime.MinValue;
        this.LossDate = DateTime.MinValue;
        this.AssuredName = string.Empty;
        this.IncurredLoss = decimal.MinValue;
        this.Closed = false;
    }

    private CompanyClaim(string uCR, int companyId,
        DateTime claimDate, DateTime lossDate,         
        string assuredName, decimal incurredLoss,
        bool closed)
    {
        this.UCR = uCR;
        this.CompanyId = companyId;
        this.ClaimDate = claimDate;
        this.LossDate = lossDate;
        this.AssuredName = assuredName;
        this.IncurredLoss = incurredLoss;
        this.Closed = closed;
    }

    public static CompanyClaim Create(string uCR, int companyId,
        DateTime claimDate, DateTime lossDate,
        string assuredName, decimal incurredLoss,
        bool closed) =>  new(uCR, companyId, claimDate,
        lossDate, assuredName, incurredLoss, closed); 
}
