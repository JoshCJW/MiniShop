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

        //Creation of table call OrdersDetails
        public DbSet<OrderDetails> OrderDetails => Set<OrderDetails>();


        //Creation of table call TransactionTable
        public DbSet<TransactionDetails> TransactionDetails => Set<TransactionDetails>();

        //Creation of table call CodeTable
        public DbSet<CodeTable> CodeTables => Set<CodeTable>();

        //Creation of table call CodeTable
        public DbSet<CodeTableApp> CodeTableApps => Set<CodeTableApp>();

    }
}
