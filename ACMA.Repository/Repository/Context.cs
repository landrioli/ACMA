using ACMA.Domain.Entities.ActiveAsset;
using ACMA.Domain.Entities.Access;
using ACMA.Domain.Entities.Place;
using ACMA.Domain.Entities.RFID;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using ACMA.Domain.Entities.Commom;

namespace ACMA.Repository.Repository
{
    public class Context : DbContext
    {
        #region Access
        public DbSet<AccessProfile> AccessProfile { get; set; }
        public DbSet<Profile> ProfileMap { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WarningGroup> WarningGroup { get; set; }
        public DbSet<Warning> Warning { get; set; }
        #endregion

        #region Asset
        public DbSet<Asset> Asset { get; set; }
        public DbSet<Item> Item { get; set; }
        #endregion

        #region Place
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<Unit> Unit { get; set; }
        #endregion

        #region RFID
        public DbSet<RawData> RawData { get; set; }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<ReaderStatus> ReaderStatus { get; set; }
        public DbSet<Tag> Tag { get; set; }
        #endregion

        #region Commmon
        public DbSet<Configuration> Configurations { get; set; }
        #endregion

        public Context()
            : base("ACMAContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                             .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                             .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                                             && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);  
        }

        public void Commit()
        {
            SaveChanges();
        }

    }
}
