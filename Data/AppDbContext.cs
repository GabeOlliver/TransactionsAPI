using APITransacitons.Models;
using Microsoft.EntityFrameworkCore;

namespace APITransacitons.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)  //Construtor do AppDbContext - conexão com o Db
        { 
                

        }


        public DbSet<Subject> Subjects { get; set; } // Representa a tabela Subjects no banco de dados
        public DbSet<Transaction> Transactions { get; set; } // Representa a tabela Transactions no banco de dados  
    }
}
