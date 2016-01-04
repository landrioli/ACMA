namespace ACMA.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 120),
                        IdProfile = c.Int(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.IdProfile)
                .Index(t => t.IdProfile);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false, maxLength: 50),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 30),
                        Blocked = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        ContactEmail = c.String(nullable: false, maxLength: 80),
                        ContactPhone = c.String(nullable: false, maxLength: 11),
                        ContactFullName = c.String(nullable: false, maxLength: 80),
                        IdProfile = c.Int(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessProfile", t => t.IdProfile)
                .Index(t => t.IdProfile);
            
            CreateTable(
                "dbo.Warning",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 120),
                        Readed = c.Boolean(nullable: false),
                        IdWarningGroup = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.IdUser)
                .ForeignKey("dbo.WarningGroup", t => t.IdWarningGroup)
                .Index(t => t.IdWarningGroup)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.WarningGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Asset",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdItem = c.Int(nullable: false),
                        IdUnit = c.Int(nullable: false),
                        IdCostCenter = c.Int(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CostCenter", t => t.IdCostCenter)
                .ForeignKey("dbo.Item", t => t.IdItem)
                .ForeignKey("dbo.Unit", t => t.IdUnit)
                .Index(t => t.IdItem)
                .Index(t => t.IdUnit)
                .Index(t => t.IdCostCenter);
            
            CreateTable(
                "dbo.CostCenter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 120),
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 120),
                        Active = c.Boolean(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUnit = c.Int(nullable: false),
                        IdCostCenter = c.Int(nullable: false),
                        IdTag = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        Responsable = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CostCenter", t => t.IdCostCenter)
                .ForeignKey("dbo.Tag", t => t.IdTag)
                .ForeignKey("dbo.Unit", t => t.IdUnit)
                .Index(t => t.IdUnit)
                .Index(t => t.IdCostCenter)
                .Index(t => t.IdTag);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagCode = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false, maxLength: 14),
                        Name = c.String(nullable: false, maxLength: 120),
                        AddressZipCode = c.String(nullable: false, maxLength: 8),
                        AddressStreet = c.String(nullable: false, maxLength: 80),
                        AddressNumber = c.String(nullable: false, maxLength: 10),
                        AddressNeighborhood = c.String(nullable: false, maxLength: 80),
                        AddressCity = c.String(nullable: false, maxLength: 80),
                        AddressState = c.String(nullable: false, maxLength: 80),
                        Active = c.Boolean(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpAddress = c.String(nullable: false, maxLength: 15),
                        Location = c.String(nullable: false, maxLength: 50),
                        IdCostCenter = c.Int(nullable: false),
                        IdReaderStatus = c.Int(nullable: false),
                        IdUnit = c.Int(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CostCenter", t => t.IdCostCenter)
                .ForeignKey("dbo.ReaderStatus", t => t.IdReaderStatus)
                .ForeignKey("dbo.Unit", t => t.IdUnit)
                .Index(t => t.IdCostCenter)
                .Index(t => t.IdReaderStatus)
                .Index(t => t.IdUnit);
            
            CreateTable(
                "dbo.ReaderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Available = c.Boolean(nullable: false),
                        Notified = c.Boolean(nullable: false),
                        LastCheck = c.DateTime(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Configuration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 80),
                        Value = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 120),
                        DateLastUpdated = c.DateTime(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RawData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagCode = c.String(nullable: false, maxLength: 50),
                        IpAddress = c.String(nullable: false, maxLength: 15),
                        DateRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asset", "IdUnit", "dbo.Unit");
            DropForeignKey("dbo.Asset", "IdItem", "dbo.Item");
            DropForeignKey("dbo.Asset", "IdCostCenter", "dbo.CostCenter");
            DropForeignKey("dbo.Item", "IdUnit", "dbo.Unit");
            DropForeignKey("dbo.Reader", "IdUnit", "dbo.Unit");
            DropForeignKey("dbo.Reader", "IdReaderStatus", "dbo.ReaderStatus");
            DropForeignKey("dbo.Reader", "IdCostCenter", "dbo.CostCenter");
            DropForeignKey("dbo.Item", "IdTag", "dbo.Tag");
            DropForeignKey("dbo.Item", "IdCostCenter", "dbo.CostCenter");
            DropForeignKey("dbo.Warning", "IdWarningGroup", "dbo.WarningGroup");
            DropForeignKey("dbo.Warning", "IdUser", "dbo.User");
            DropForeignKey("dbo.User", "IdProfile", "dbo.AccessProfile");
            DropForeignKey("dbo.AccessProfile", "IdProfile", "dbo.Profile");
            DropIndex("dbo.Reader", new[] { "IdUnit" });
            DropIndex("dbo.Reader", new[] { "IdReaderStatus" });
            DropIndex("dbo.Reader", new[] { "IdCostCenter" });
            DropIndex("dbo.Item", new[] { "IdTag" });
            DropIndex("dbo.Item", new[] { "IdCostCenter" });
            DropIndex("dbo.Item", new[] { "IdUnit" });
            DropIndex("dbo.Asset", new[] { "IdCostCenter" });
            DropIndex("dbo.Asset", new[] { "IdUnit" });
            DropIndex("dbo.Asset", new[] { "IdItem" });
            DropIndex("dbo.Warning", new[] { "IdUser" });
            DropIndex("dbo.Warning", new[] { "IdWarningGroup" });
            DropIndex("dbo.User", new[] { "IdProfile" });
            DropIndex("dbo.AccessProfile", new[] { "IdProfile" });
            DropTable("dbo.RawData");
            DropTable("dbo.Configuration");
            DropTable("dbo.ReaderStatus");
            DropTable("dbo.Reader");
            DropTable("dbo.Unit");
            DropTable("dbo.Tag");
            DropTable("dbo.Item");
            DropTable("dbo.CostCenter");
            DropTable("dbo.Asset");
            DropTable("dbo.WarningGroup");
            DropTable("dbo.Warning");
            DropTable("dbo.User");
            DropTable("dbo.Profile");
            DropTable("dbo.AccessProfile");
        }
    }
}
