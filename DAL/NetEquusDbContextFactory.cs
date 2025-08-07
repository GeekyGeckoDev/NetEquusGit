
using Domain.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class NetEquusDbContextFactory : IDesignTimeDbContextFactory<NetEquusDbContext>
    {
        public NetEquusDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NetEquusDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NetEquusDbV2;Trusted_Connection=True;");
            return new NetEquusDbContext(optionsBuilder.Options);
        }
    }
}

