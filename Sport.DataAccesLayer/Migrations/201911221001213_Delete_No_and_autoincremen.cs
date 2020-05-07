namespace Sport.DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_No_and_autoincremen : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Event");
            AlterColumn("dbo.Event", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Event", "Id");
            DropColumn("dbo.Event", "No");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "No", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Event");
            AlterColumn("dbo.Event", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Event", "Id");
        }
    }
}
