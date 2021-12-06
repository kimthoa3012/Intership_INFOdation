using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CF.Model
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) { }

        #region
        public DbSet<Product> Products { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        #endregion
    }
}
