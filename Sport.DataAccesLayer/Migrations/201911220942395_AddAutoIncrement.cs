namespace Sport.DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAutoIncrement : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Event");
            AlterColumn("dbo.Event", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Event", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Event");
            AlterColumn("dbo.Event", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Event", "Id");
        }
    }
}
