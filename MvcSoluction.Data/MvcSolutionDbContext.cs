using MvcSoluction.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSoluction.Data
{
    public class MvcSolutionDbContext:DbContext
    {
        public DbSet<Image> Images { get; set; }
        public MvcSolutionDbContext()
        {
            Database.SetInitializer<MvcSolutionDbContext>(null);
        }
        
    }
}
