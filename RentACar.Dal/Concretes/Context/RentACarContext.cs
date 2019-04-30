namespace RentACar.Dal.Concretes.Context
{
    using System.Data.Entity;
    using RentACar.Model.EntityModels;

    public partial class RentACarContext : DbContext
    {
        public RentACarContext()
            : base("name=RentACarContext")
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>()
                .Property(e => e.RentPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transactions>()
                .Property(e => e.RentPrice)
                .HasPrecision(19, 4);
        }
    }
}
