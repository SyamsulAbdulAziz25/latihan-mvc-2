namespace Sport.DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialScema1 : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.Event", "State_Delete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "State_Delete");
        }
    }
}
