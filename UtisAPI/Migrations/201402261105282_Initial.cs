namespace UtisAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dug",
                c => new
                    {
                        DugID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        UserID = c.Int(nullable: false),
                        YearID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DugID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Year", t => t.YearID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.YearID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        DateJoined = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.YearlyMembership",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        DatumUplate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        VrstaUplateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.VrstaUplate", t => t.VrstaUplateID, cascadeDelete: true)
                .ForeignKey("dbo.Year", t => t.YearId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.VrstaUplateID)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.VrstaUplate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Year",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YearlyMembership", "YearId", "dbo.Year");
            DropForeignKey("dbo.Dug", "YearID", "dbo.Year");
            DropForeignKey("dbo.YearlyMembership", "VrstaUplateID", "dbo.VrstaUplate");
            DropForeignKey("dbo.YearlyMembership", "UserId", "dbo.User");
            DropForeignKey("dbo.Dug", "UserID", "dbo.User");
            DropIndex("dbo.YearlyMembership", new[] { "YearId" });
            DropIndex("dbo.Dug", new[] { "YearID" });
            DropIndex("dbo.YearlyMembership", new[] { "VrstaUplateID" });
            DropIndex("dbo.YearlyMembership", new[] { "UserId" });
            DropIndex("dbo.Dug", new[] { "UserID" });
            DropTable("dbo.Year");
            DropTable("dbo.VrstaUplate");
            DropTable("dbo.YearlyMembership");
            DropTable("dbo.User");
            DropTable("dbo.Dug");
        }
    }
}
