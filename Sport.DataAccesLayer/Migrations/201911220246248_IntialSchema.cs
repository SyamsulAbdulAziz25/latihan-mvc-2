namespace Sport.DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        No = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        EventStatus = c.String(nullable: false),
                        Price = c.String(nullable: false),

                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Event");
        }
    }
}
