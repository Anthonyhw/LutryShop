using LutryShop.OrderApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LutryShop.OrderApi.Models
{
    public class OrderDetail: BaseEntity
    {
        public long OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeader { get; set; }
        public long ProductId { get; set; }

        public int Count { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
