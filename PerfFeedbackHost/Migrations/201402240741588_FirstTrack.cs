namespace PerfFeedbackHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoWorkers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WorkItemName = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        AreaForImprovement_ID = c.String(maxLength: 128),
                        Strength_ID = c.String(maxLength: 128),
                        CoWorker_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feedbacks", t => t.AreaForImprovement_ID)
                .ForeignKey("dbo.Feedbacks", t => t.Strength_ID)
                .ForeignKey("dbo.CoWorkers", t => t.CoWorker_Id)
                .Index(t => t.AreaForImprovement_ID)
                .Index(t => t.Strength_ID)
                .Index(t => t.CoWorker_Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItems", "CoWorker_Id", "dbo.CoWorkers");
            DropForeignKey("dbo.WorkItems", "Strength_ID", "dbo.Feedbacks");
            DropForeignKey("dbo.WorkItems", "AreaForImprovement_ID", "dbo.Feedbacks");
            DropIndex("dbo.WorkItems", new[] { "CoWorker_Id" });
            DropIndex("dbo.WorkItems", new[] { "Strength_ID" });
            DropIndex("dbo.WorkItems", new[] { "AreaForImprovement_ID" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.WorkItems");
            DropTable("dbo.CoWorkers");
        }
    }
}
