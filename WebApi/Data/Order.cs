using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30),MinLength(10)]
        public string refNo { get; set; } = string.Empty;

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        [ForeignKey("Product")]
        public string ProdId { get; set; } = string.Empty;
        public double Qty { get; set; }

        public double Amt { get; set; }


    }
}
