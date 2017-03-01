namespace FingerPrintAccess.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsrooms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ROOMS",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomUsers",
                c => new
                    {
                        Room_Id = c.Long(nullable: false),
                        User_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.User_Id })
                .ForeignKey("dbo.ROOMS", t => t.Room_Id, cascadeDelete: true)
                .ForeignKey("dbo.USERS", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomUsers", "User_Id", "dbo.USERS");
            DropForeignKey("dbo.RoomUsers", "Room_Id", "dbo.ROOMS");
            DropIndex("dbo.RoomUsers", new[] { "User_Id" });
            DropIndex("dbo.RoomUsers", new[] { "Room_Id" });
            DropTable("dbo.RoomUsers");
            DropTable("dbo.ROOMS");
        }
    }
}
