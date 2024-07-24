using System.Text.Json.Serialization;

namespace MAGICVILLA_API.Models.DTOs
{

    public class VillaDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int occupancy { get; set; }
        public int sqft { get; set; }
    }

}