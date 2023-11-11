namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdminLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.LoginID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminLogins");
        }
    }
}
