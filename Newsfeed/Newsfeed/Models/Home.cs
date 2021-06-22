using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsfeed.Models
{
    public class Home
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }
    }
}
