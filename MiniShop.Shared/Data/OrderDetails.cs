using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public string ProdId { get; set; } = string.Empty;
        public double Qty { get; set; }
    }
}
