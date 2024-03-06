using LutryShop.CartApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LutryShop.CartApi.Models
{
    public class CartDetail: BaseEntity
    {
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
     
        public long ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Count { get; set; }
    }
}
