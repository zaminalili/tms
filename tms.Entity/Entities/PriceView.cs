using Microsoft.EntityFrameworkCore;

namespace tms.Entity.Entities
{
    
    public class PriceView: EntityBase
    {
        public bool IsPriceViewActive { get; set; }
    }
}
