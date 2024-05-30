using Microsoft.EntityFrameworkCore;

namespace internship.Database
{
    public class FoodDBContext : DbContext
    {
        public FoodDBContext(DbContextOptions<FoodDBContext> options) : base(options)
        { }

        #region DBset
        public DbSet<User>? User { get; set; }
        public DbSet<Order>? Order { get; set; }
        public DbSet<Order_detail>? Order_Details { get; set; }
        public DbSet<Item>? Item { get; set; }
        public DbSet<Catagory>? Catagory { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order_detail>()
                .HasKey(od => new { od.Order_Id, od.Item_Id });
        }
    }
}
