using System.ComponentModel.DataAnnotations;

namespace CountriesWeb.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
