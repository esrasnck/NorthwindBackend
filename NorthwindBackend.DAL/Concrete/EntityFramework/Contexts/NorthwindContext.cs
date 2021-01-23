using Microsoft.EntityFrameworkCore;
using NorthwindBackend.ENTITIES.Concrete;
using NorthwindBackend.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DAL.Concrete.EntityFramework.Contexts
{
   public class NorthwindContext:DbContext
    {

        // connection stringi burada veriyoruz

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
       
        

    }
 
}
