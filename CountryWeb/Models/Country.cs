using System.ComponentModel.DataAnnotations;

namespace CountriesWeb.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Capital { get; set; }
        public float Area { get; set; }
        public int Population { get; set; }
        public int Region { get; set; }
    }
}
