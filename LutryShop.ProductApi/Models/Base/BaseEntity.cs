using System.ComponentModel.DataAnnotations;

namespace LutryShop.ProductApi.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
