using System.ComponentModel.DataAnnotations;

namespace LutryShop.CartApi.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
