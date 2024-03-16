using System.ComponentModel.DataAnnotations;

namespace LutryShop.Email.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
