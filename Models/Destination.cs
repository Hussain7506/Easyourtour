using System.ComponentModel.DataAnnotations;

namespace Easyourtour.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Destination_Type { get; set; }
    }
}
