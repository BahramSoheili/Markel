using System.Security.Claims;

namespace Markel.CostomerService.Common.Entities;
public class ClaimType
{
        public int Id { get; set; }
        public string Name { get; set; }
      
        public ClaimType()
        {
            this.Id = 0;
            this.Name = string.Empty;
        }     
}
