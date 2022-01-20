using System.ComponentModel;
using System.ComponentModel.DataAnnotations; 

namespace ASP.Models
{
    public class Category
    {
        [Key] // inisialisasi PK
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")] //buat ganti in nama di alert
        [Range(1,3, ErrorMessage="min 1 max 3")] ///data anotasi bisa dilihat di dukumentasi .net5 (range atribut, dll)
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


    }
}
