
namespace Infrastructure.Context
{
    public interface IOfferContext
    {

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

        /*
         * Note: Implement OnConfiguring, OnModelCreating and register DbSet<T> for each entity according to EFCore
         * **/
    }
}
