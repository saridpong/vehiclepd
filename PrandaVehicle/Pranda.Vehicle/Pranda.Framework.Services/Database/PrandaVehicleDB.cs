namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PrandaVehicleDB : DbContext
    {
        public PrandaVehicleDB()
            : base("name=PrandaVehicleDB")
        {
        }

        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<ForUse> ForUses { get; set; }
        public virtual DbSet<InformationLogin> InformationLogins { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<RequestHeader> RequestHeaders { get; set; }
        public virtual DbSet<RequestLine> RequestLines { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }
        public virtual DbSet<Vihicle> Vihicles { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarType>()
                .Property(e => e.CarTypeID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<CarType>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Department>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Driver>()
                .Property(e => e.DriverID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ForUse>()
                .Property(e => e.ForUseID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<ForUse>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<InformationLogin>()
                .Property(e => e.InformationLoginID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<InformationLogin>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Location>()
                .Property(e => e.LocationID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Location>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Place>()
                .Property(e => e.PlaceID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Place>()
                .Property(e => e.PlaceStatus)
                .HasPrecision(2, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.RequestHeaderID)
                .HasPrecision(20, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.DepartmentID)
                .HasPrecision(20, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.ApproveBy)
                .HasPrecision(20, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.Piority)
                .HasPrecision(5, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.TotalPasenger)
                .HasPrecision(2, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.EstimateDistance)
                .HasPrecision(20, 2);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.EstimateCost)
                .HasPrecision(20, 2);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.RequestBy)
                .HasPrecision(20, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.UpdateBy)
                .HasPrecision(20, 0);

            modelBuilder.Entity<RequestHeader>()
                .Property(e => e.RequestHeaderStatus)
                .HasPrecision(5, 0);

            modelBuilder.Entity<RequestLine>()
                .Property(e => e.RequestHeaderID)
                .HasPrecision(20, 0);

            modelBuilder.Entity<RequestLine>()
                .Property(e => e.RequestLineID)
                .HasPrecision(20, 0);

            modelBuilder.Entity<RequestLine>()
                .Property(e => e.quantity)
                .HasPrecision(5, 0);

            modelBuilder.Entity<RequestLine>()
                .Property(e => e.placeID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<RequestLine>()
                .Property(e => e.Amount)
                .HasPrecision(5, 0);

            modelBuilder.Entity<RequestLine>()
                .Property(e => e.RequestLineStatus)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Section>()
                .Property(e => e.SectionID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Section>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<UserData>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Vihicle>()
                .Property(e => e.VihicleID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Vihicle>()
                .Property(e => e.VihicleCost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Vihicle>()
                .Property(e => e.Status)
                .HasPrecision(2, 0);
        }
    }
}
