using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    public class TransactionDetails
    {
        [Key]
        public int Id { get; set; }
        public string TransactionType { get; set; } = string.Empty;

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string IsPaid { get; set; } = string.Empty;

        public DateTime TransactionDateTime { get; set; }




    }
}
