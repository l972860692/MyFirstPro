using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.Domain.Concrete
{
  public  class EFDbContext:DbContext
    {

      public DbSet<Category> Categorys { get; set; }
      public DbSet<Product> Products { get; set; }
                                                                                                                                      
    }
}
