using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OrderDetails")]
        public int OrderDetailID{ get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        public double Amt { get; set; }


    }
}
