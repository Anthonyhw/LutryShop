using System.ComponentModel.DataAnnotations;

namespace LutryShop.CouponApi.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
