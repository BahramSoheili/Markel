namespace Markel.CostomerService.Common.Entities;
public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string Postcode { get; set; }
    public bool Active { get; set; }
    public string Country { get; set; }
    public DateTime InsuranceEndDate { get; set; }  

    public Company()
    {
        this.Name = string.Empty;
        this.Address1 = string.Empty;
        this.Address2 = string.Empty;
        this.Address3 = string.Empty;
        this.Postcode = string.Empty;
        this.Active = false;
        this.Country = string.Empty;
        this.InsuranceEndDate = DateTime.MinValue;
    }
}