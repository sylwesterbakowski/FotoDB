using FotoDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Contexts
{
    public class FotoContext :DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=LAPTOP-D8UU7JTS\MSSQLSERVER_2020;Initial Catalog=FotoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<FotoModel> Fotos { get; set; }
        public DbSet<AutorModel> Autors { get; set; }
        public DbSet<KrajModel> Krajs { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<AutorModel>().Property<int>("KrajForeignKey");

        //    modelBuilder.Entity<AutorModel>()
        //        .HasOne(k=>k.)
        //        .
        //}
        
    }
}
