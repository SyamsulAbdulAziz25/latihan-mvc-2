namespace Sport.DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "State_Delete", c => c.String(nullable: false));
            DropColumn("dbo.Event", "No");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "No", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "State_Delete");
        }
    }
}
