using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SkiWorld.Data.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class skiworldContext : IdentityDbContext<user>
    {
        //added
      public  static skiworldContext Create()
        {
            return new skiworldContext();
        }

        public skiworldContext()
            : base("name=skiworldContext")
        {
        }

        public DbSet<category> category { get; set; }
        public DbSet<claim> claim { get; set; }
        public DbSet<evenement> evenement { get; set; }
        public DbSet<gallery> gallery { get; set; }
        public DbSet<hotel> hotel { get; set; }
        public DbSet<menu> menu { get; set; }
        public DbSet<parking> parking { get; set; }
        public DbSet<parkingreservation> parkingreservation { get; set; }
        public DbSet<planing> planing { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<purchasedetail> purchasedetail { get; set; }
        public DbSet<restaurant> restaurant { get; set; }
        public DbSet<restotable> restotable { get; set; }
        public DbSet<restotablereservation> restotablereservation { get; set; }
        public DbSet<room> room { get; set; }
        public DbSet<roomreservation> roomreservation { get; set; }
        public DbSet<shop> shop { get; set; }
        public DbSet<skiarea> skiarea { get; set; }
        public DbSet<skiareareservation> skiareareservation { get; set; }
        public DbSet<skiareatype> skiareatype { get; set; }
        public DbSet<opportunity> opportunity { get; set; }
        public DbSet<match> match { get; set; }
        public DbSet<competition> competition { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<user>()
                .Property(x => x.Email)
                .HasMaxLength(255);
            modelBuilder.Entity<user>()
                .Property(x => x.UserName)
                .HasMaxLength(255);
            modelBuilder.Entity<IdentityRole>()
                .Property(x => x.Name)
                .HasMaxLength(255);
        }
    }
}
