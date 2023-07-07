using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.web.Models;

namespace Shop.web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdminModel> admins { get; set; }
        public DbSet<CategoryModel> categories{ get; set; }
        public DbSet<CustomerModel> customers { get; set; } 
        public DbSet<ProductModel> products { get; set; }
        public DbSet<SalesDetailsModel> salesDetails { get; set; }
        public DbSet<SalesSummaryModel> salesSummaries { get; set; }
        public DbSet<StockModel> stocks { get; set; }

    }
} 