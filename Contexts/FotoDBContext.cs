using FotoDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Contexts
{
    public class FotoDBContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connection = @"Data Source=LAPTOP-D8UU7JTS\MSSQLSERVER_2020;Initial Catalog=FotoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //optionsBuilder.UseSqlServer(connection);
        }
        public FotoDBContext(DbContextOptions<FotoDBContext> options) : base(options)
        {
                
        }
        public DbSet<FotoModel> Fotos { get; set; }
        public DbSet<AutorModel> Autors { get; set; }
        public DbSet<KrajModel> Krajs { get; set; }
        
    }
}
