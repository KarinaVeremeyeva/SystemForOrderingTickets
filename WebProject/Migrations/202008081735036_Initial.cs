namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayId = c.Int(nullable: false),
                        PlayDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plays", t => t.PlayId, cascadeDelete: true)
                .Index(t => t.PlayId);
            
            CreateTable(
                "dbo.Plays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateId = c.Int(nullable: false),
                        LoginId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.DateId, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.DateId)
                .Index(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Orders", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Plays", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Dates", "PlayId", "dbo.Plays");
            DropForeignKey("dbo.Plays", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Orders", new[] { "LoginId" });
            DropIndex("dbo.Orders", new[] { "DateId" });
            DropIndex("dbo.Plays", new[] { "GenreId" });
            DropIndex("dbo.Plays", new[] { "AuthorId" });
            DropIndex("dbo.Dates", new[] { "PlayId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Logins");
            DropTable("dbo.Genres");
            DropTable("dbo.Plays");
            DropTable("dbo.Dates");
            DropTable("dbo.Authors");
        }
    }
}
