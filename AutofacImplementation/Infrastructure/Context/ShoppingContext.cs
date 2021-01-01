
using Infrastructure.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    public interface IOfferContext
    {
        public IList<Products> Products { get; set; } //Just a structural sample code to understand real code. Note:- instead of IList<T> use DbSet<T> for EFCore
    }

    public class ShoppingContext : IOfferContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public ShoppingContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        //Note: From Here, Implement OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder), 
        //OnModelCreating(ModelBuilder builder) and register DbSet<T> for each entity according to EFCore

        public IList<Products> Products { get; set; } //Just a structural sample code to understand real code. Note:- instead of IList<T> use DbSet<T> for EFCore
    }
}
