using MvcSoluction.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MvcSoluction.Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new MvcSolutionDbContext())
            {
                var images = dbContext.Images.ToList();
                var newimage = new Image { Height = 1, Width = 1 };
                dbContext.Images.Add(newimage);
                dbContext.SaveChanges();
            }
        }
    }
}
