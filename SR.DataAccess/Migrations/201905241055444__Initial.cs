namespace SR.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Comment = c.String(),
                        DateOfBirth = c.DateTime(),
                        FacultyId = c.Int(nullable: false),
                        NationalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Students", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.Students", new[] { "NationalityId" });
            DropIndex("dbo.Students", new[] { "FacultyId" });
            DropTable("dbo.Nationalities");
            DropTable("dbo.Students");
            DropTable("dbo.Faculties");
        }
    }
}
