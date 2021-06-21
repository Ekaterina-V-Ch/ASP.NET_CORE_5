using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newsfeed.Models
{
    public class SmartphonesNews
    {
        [Key]
        public int Id { get; set; }
        public string News { get; set; }
        public int Data { get; set; }
    }
}
