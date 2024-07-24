using System.ComponentModel.DataAnnotations;

namespace MAGICVILLA_API.Models.Domain
{

    public class Villa
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}