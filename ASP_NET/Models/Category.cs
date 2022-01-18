using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET.Models
{
    public class Category
    {
        [Key] // inisialisasi PK
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")] //buat ganti in nama di alert
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


    }
}
