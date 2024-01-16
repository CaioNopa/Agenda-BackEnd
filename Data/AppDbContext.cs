using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data 
{
	// O DbContext é a representação do banco de dados
    public class AppDbContext : DbContext
    {
		// O DbSet é a representação da tabela.
        public DbSet<Contato> Contatos { get; set; }
				
		// String de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}