using LutryShop.CartApi.Models;
using LutryShop.CartApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LutryShop.CartApi.Data.ValueObjects
{
    public class CartDetailVO: BaseEntity
    {
        public long Id { get; set; }

        public long CartHeaderId { get; set; }

        public CartHeaderVO CartHeader { get; set; }
     
        public long ProductId { get; set; }
        
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
