using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newsfeed.Models
{
    public class PCHardwareNews : Home
    {
        [Key]
        public int Id { get; set; }
        //public new string Topic { get; set; }
        //public new string Content { get; set; }
        //public new DateTime DateTimeCreated { get; set; }
        //public new DateTime DateTimeUpdated { get; set; }
    }
}
