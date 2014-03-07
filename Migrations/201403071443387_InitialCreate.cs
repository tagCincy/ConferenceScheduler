namespace ConferenceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Company = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Time = c.DateTime(nullable: false),
                        Occupancy = c.Int(nullable: false),
                        IsFull = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SessionID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Role_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Role_RoleID })
                .ForeignKey("dbo.User", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_RoleID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Role_RoleID);
            
            CreateTable(
                "dbo.SessionUser",
                c => new
                    {
                        Session_SessionID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Session_SessionID, t.User_UserID })
                .ForeignKey("dbo.Session", t => t.Session_SessionID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Session_SessionID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionUser", "User_UserID", "dbo.User");
            DropForeignKey("dbo.SessionUser", "Session_SessionID", "dbo.Session");
            DropForeignKey("dbo.UserRole", "Role_RoleID", "dbo.Role");
            DropForeignKey("dbo.UserRole", "User_UserID", "dbo.User");
            DropIndex("dbo.SessionUser", new[] { "User_UserID" });
            DropIndex("dbo.SessionUser", new[] { "Session_SessionID" });
            DropIndex("dbo.UserRole", new[] { "Role_RoleID" });
            DropIndex("dbo.UserRole", new[] { "User_UserID" });
            DropTable("dbo.SessionUser");
            DropTable("dbo.UserRole");
            DropTable("dbo.Session");
            DropTable("dbo.User");
            DropTable("dbo.Role");
        }
    }
}
