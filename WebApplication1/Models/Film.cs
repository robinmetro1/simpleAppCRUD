using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Film Title")]
        public string Title { get; set; }

        [DisplayName("Film Category")]
        public string Category { get; set; }
    }
}
