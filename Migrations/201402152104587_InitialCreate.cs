namespace ConferenceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        Company = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        SessionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Session", t => t.SessionID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SessionID);
            
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enrollment", new[] { "SessionID" });
            DropIndex("dbo.Enrollment", new[] { "UserID" });
            DropForeignKey("dbo.Enrollment", "SessionID", "dbo.Session");
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.User");
            DropTable("dbo.Session");
            DropTable("dbo.Enrollment");
            DropTable("dbo.User");
        }
    }
}
