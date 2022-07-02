using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("login")]
        public int CustLoginID {get; set; }

        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(8)]
        public int ContactNo { get; set; }
    }
}
