namespace RentACar.Model.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RentACarContext : DbContext
    {
        public RentACarContext()
            : base("name=RentACarContext")
        {
        }

        public virtual DbSet<CarDetail> CarDetail { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>()
                .Property(e => e.RentPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Reports>()
                .Property(e => e.TotalMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transactions>()
                .Property(e => e.RentPrice)
                .HasPrecision(19, 4);
        }
    }
}
