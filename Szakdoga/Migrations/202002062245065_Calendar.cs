namespace Szakdoga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calendar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainCalendars",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MainCalendars");
        }
    }
}
