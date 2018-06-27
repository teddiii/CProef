using CproefLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib
{
    /// <summary>
    /// This is the application database context
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets/sets the db set for the users
        /// </summary>
        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// The Id of the current logged in user
        /// '?' indicated that it can be nullable
        /// </summary>
        public Guid? CurrentUserId { get; internal set; }
        /// <summary>
        /// Gets/sets the DB Set for the products
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Gets/sets the DB set for the brands
        /// </summary>
        public DbSet<Brands> Brands { get; set; }
        /// <summary>
        /// Gets/sets the DB set for the categories
        /// </summary>
        public DbSet<Categories> Categories { get; set; }
        /// <summary>
        /// Gets/sets the DB set for the clients
        /// </summary>
        public DbSet<Clients> Clients { get; set; }
        /// <summary>
        /// Gets/sets the DB set for the languages
        /// </summary>
        public DbSet<Languages> Languages { get; set; }
        /// <summary>
        /// Gets/sets the DB set for the orders
        /// </summary>
        public DbSet<Orders> Orders { get; set; }
        /// <summary>
        /// gets/sets the DB set for the couriers
        /// </summary>
        public DbSet<Couriers> Couriers { get; set; }
        /// <summary>
        /// gets/sets the DB set for the Defaultspecs
        /// </summary>
        public DbSet<DefaultSpecs> DefaultSpecs { get; set; }
        /// <summary>
        /// gets/sets the DB set for the Ordered Products
        /// </summary>
        public DbSet<Orderline> OrderedProducts { get; set; }
        /// <summary>
        /// gets/sets the DB set for the Status
        /// </summary>
        public DbSet<Status> Status { get; set; }
        /// <summary>
        /// gets/sets the DB set for the Suppliers
        /// </summary>
        public DbSet<Suppliers> Suppliers { get; set; }
        /// <summary>
        /// gets/sets the DB set for the Orderline
        /// </summary>
        public DbSet<Orderline> Orderlines { get; set; }
        /// <summary>
        /// gets/sets the DB set for the orderline specifications
        /// </summary>
        public DbSet<OrderlineSpecification> OrderlineSpecifications { get; set; }



        public AppDbContext() : base(@"Data Source=LAPTOP-FAC37MEN\SQLEXPRESS;Initial Catalog=CProef;Persist Security Info=True;User ID=cproef;Password=bryan")
        {

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        private AppDbContext(string connectionString) : base(connectionString)
        {

        }

        private static AppDbContext _instance;


        /// <summary>
        /// Implementation of the singleton pattern
        /// </summary>
        /// <param name="connectionString"></param>
        public static AppDbContext Instance(string connectionString = null)
        {
            if (_instance == null)
            {
                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    _instance = new AppDbContext(connectionString);
                }
            }

            return _instance;
        }
    }
}
