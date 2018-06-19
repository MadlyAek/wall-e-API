namespace wall_e_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcreatemigrationuserinfoandaccountinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.walle_AccountInfo",
                c => new
                    {
                        No = c.String(nullable: false, maxLength: 128),
                        Balance = c.Double(nullable: false),
                        walle_UserInfo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.No)
                .ForeignKey("dbo.walle_UserInfo", t => t.walle_UserInfo)
                .Index(t => t.walle_UserInfo);
            
            CreateTable(
                "dbo.walle_UserInfo",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.walle_AccountInfo", "walle_UserInfo", "dbo.walle_UserInfo");
            DropIndex("dbo.walle_AccountInfo", new[] { "walle_UserInfo" });
            DropTable("dbo.walle_UserInfo");
            DropTable("dbo.walle_AccountInfo");
        }
    }
}
