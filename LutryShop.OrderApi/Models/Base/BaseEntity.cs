using System.ComponentModel.DataAnnotations;

namespace LutryShop.OrderApi.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
