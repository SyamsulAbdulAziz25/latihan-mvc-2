namespace Sport.DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_StateDeleted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "State_Delete", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "State_Delete", c => c.Boolean(nullable: false));
        }
    }
}
