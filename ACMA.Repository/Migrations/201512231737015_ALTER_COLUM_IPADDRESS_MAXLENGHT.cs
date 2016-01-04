namespace ACMA.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALTER_COLUM_IPADDRESS_MAXLENGHT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reader", "IpAddress", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reader", "IpAddress", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
