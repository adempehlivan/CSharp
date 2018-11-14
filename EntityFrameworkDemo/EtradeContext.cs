using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class EtradeContext :DbContext
    {
        //ayrıca bir mapping yapmassan veritabanındaki Products tablosunu arar
        public DbSet<Product> Products { get; set; }

    }
}
