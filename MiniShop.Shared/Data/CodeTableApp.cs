using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class CodeTableApp
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string desc { get; set; } = string.Empty;
        public string longdesc { get; set; } = string.Empty;
    }
}
