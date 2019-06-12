namespace SR.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculties", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Faculties", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "Comment", c => c.String(maxLength: 500));
            AlterColumn("dbo.Nationalities", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nationalities", "Name", c => c.String());
            AlterColumn("dbo.Students", "Comment", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Faculties", "Address", c => c.String());
            AlterColumn("dbo.Faculties", "City", c => c.String());
            AlterColumn("dbo.Faculties", "Name", c => c.String());
        }
    }
}
