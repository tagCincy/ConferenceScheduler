namespace ConferenceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        SessionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Session", t => t.SessionID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.SessionID)
                .Index(t => t.UserID);
            
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
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.User_UserID })
                .ForeignKey("dbo.Role", t => t.Role_RoleID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Role_RoleID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleUser", "User_UserID", "dbo.User");
            DropForeignKey("dbo.RoleUser", "Role_RoleID", "dbo.Role");
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.User");
            DropForeignKey("dbo.Enrollment", "SessionID", "dbo.Session");
            DropIndex("dbo.RoleUser", new[] { "User_UserID" });
            DropIndex("dbo.RoleUser", new[] { "Role_RoleID" });
            DropIndex("dbo.Enrollment", new[] { "UserID" });
            DropIndex("dbo.Enrollment", new[] { "SessionID" });
            DropTable("dbo.RoleUser");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Session");
            DropTable("dbo.Enrollment");
        }
    }
}
