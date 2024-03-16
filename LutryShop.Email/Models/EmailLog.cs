using LutryShop.Email.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LutryShop.Email.Models
{
    [Table("email_logs")]
    public class EmailLog: BaseEntity
    {
        public string Email { get; set; }

        public string Log { get; set; }

        public DateTime SentDate { get; set; }
    }
}
