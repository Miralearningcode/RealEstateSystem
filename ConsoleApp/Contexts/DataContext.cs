using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Contexts
{
    //Denna klass har hand om kommunikationen mellan databasen och mina modeller
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @""; 
        public DataContext()
        { 
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Konfigurationen av databaskopplingen
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }


    }
}
