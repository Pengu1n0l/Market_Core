using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market_Core
{
    class AppContext:DbContext
    {
        public DbSet<Departments> Department { get; set; }
        public DbSet<Shops> Shop { get; set; }
        public DbSet<Bases> Base { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Shop_Bases> Shop_Base { get; set; }
        public AppContext()
        {   
            //Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   

            modelBuilder.Entity<Shop_Bases>()
                .HasKey(o => new { o.id_shop, o.id_bases });
        }
        //protected override void OnModelCreating(ModelBuilder mb)
        //{
        //    mb.Entity<Shop_Departments>().HasNoKey();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8MNL6GQ\SQLEXPRESS;Database=db_taa_Market; Trusted_Connection=True;");

        }
    }
}
