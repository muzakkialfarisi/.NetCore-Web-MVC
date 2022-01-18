using System.ComponentModel.DataAnnotations;

namespace ASP_NET.Models
{
    public class Category
    {
        [Key] // inisialisasi PK
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


    }
}
