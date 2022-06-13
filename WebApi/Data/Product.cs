using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string prodImg { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ProdName { get; set; } = string.Empty;

        [MaxLength(250)]
        public string ProductDesc { get; set; } = string.Empty;
        public int Quantity { get; set; }   
        public double Price { get; set; }
    }
}
