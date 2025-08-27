using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Data.EF.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingSystem.Data.EF;

public class StockTrackingSystemDbContext : DbContext
{
    public StockTrackingSystemDbContext(DbContextOptions<StockTrackingSystemDbContext> options) : base(options)
    {
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<LoginAttempts> LoginAttempts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductInventory> ProductInventory { get; set; }
    public DbSet<ProductTransfer> ProductTransfers { get; set; }
    public DbSet<ProductTransferDetail> ProductTransferDetails { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<TransferLog> TransferLogs { get; set; }
    public DbSet<Store> Stores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
                                                                       
    {
        base.OnModelCreating(modelBuilder);

    }
}




