﻿using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Contexts
{
    //Denna klass har hand om kommunikationen mellan databasen och mina modeller
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\miraw\Desktop\Datalagring\RealEstateSystem\ConsoleApp\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors
        public DataContext()
        { 
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #endregion

        #region overrides
        //Konfigurationen av databaskopplingen
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        #endregion

        #region entities




        #endregion
    }
}
