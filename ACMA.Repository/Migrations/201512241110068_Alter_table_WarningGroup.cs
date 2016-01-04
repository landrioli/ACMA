namespace ACMA.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_table_WarningGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarningGroup", "Description", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.WarningGroup", "Value", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WarningGroup", "Value", c => c.String());
            DropColumn("dbo.WarningGroup", "Description");
        }
    }
}
