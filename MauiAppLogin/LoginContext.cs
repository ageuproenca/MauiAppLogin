using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLogin
{
    internal class LoginContext : DbContext
    {
        public DbSet<DadosUsuario> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlite("Data Source=login.db");
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "login.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DadosUsuario>().HasData(
                new DadosUsuario { Id = 1, Usuario = "admin", Senha = "password" },
                new DadosUsuario { Id = 2, Usuario = "user", Senha = "123456" });
        }
    }
}
