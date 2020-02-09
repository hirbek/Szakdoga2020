namespace Szakdoga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lattamMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Lattamozott", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Lattamozott");
        }
    }
}
