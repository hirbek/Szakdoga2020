namespace Szakdoga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MainCalendars", "Subject", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MainCalendars", "Subject", c => c.String());
        }
    }
}
