using Newsfeed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsfeed.Data
{
    public class NewsfeedDbContext : DbContext
    {
        public NewsfeedDbContext(DbContextOptions<NewsfeedDbContext> options) : base(options)
        {

        }

        public DbSet<PCHardwareNews> PCNews { get; set; }
        public DbSet<SmartphonesNews> PhonesNews { get; set; }
    }
}
