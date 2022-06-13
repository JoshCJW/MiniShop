global using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Creation of Register/Login
        public DbSet<User> Users => Set<User>();

    
        //Creation of table call Customers
        public DbSet<Customer> Customers => Set<Customer>();

        //Creation of table call Products
        public DbSet<Product> Products => Set<Product>();

        //Creation of table call Orders
        public DbSet<Order> Orders => Set<Order>();

        //Creation of table call CodeTable
        public DbSet<CodeTable> CodetTables => Set<CodeTable>();

    }
}
