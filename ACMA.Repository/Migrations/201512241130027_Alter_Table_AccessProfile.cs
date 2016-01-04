namespace ACMA.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_AccessProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccessProfile", "Key", c => c.String(nullable: false, maxLength: 80));
            DropColumn("dbo.AccessProfile", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccessProfile", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AccessProfile", "Key");
        }
    }
}
