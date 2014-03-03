namespace PerfFeedback.WcfBusinessService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoWorkers",
                c => new
                    {
                        CoWorkerId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CoWorkerId);
            
            CreateTable(
                "dbo.WorkItems",
                c => new
                    {
                        WorkItemId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        AreaForImprovement_FeedbackId = c.Long(),
                        Strength_FeedbackId = c.Long(),
                        CoWorker_CoWorkerId = c.Long(),
                    })
                .PrimaryKey(t => new { t.WorkItemId, t.Title })
                .ForeignKey("dbo.Feedbacks", t => t.AreaForImprovement_FeedbackId)
                .ForeignKey("dbo.Feedbacks", t => t.Strength_FeedbackId)
                .ForeignKey("dbo.CoWorkers", t => t.CoWorker_CoWorkerId)
                .Index(t => t.AreaForImprovement_FeedbackId)
                .Index(t => t.Strength_FeedbackId)
                .Index(t => t.CoWorker_CoWorkerId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Long(nullable: false, identity: true),
                        Comment = c.String(),
                        WorkItemId = c.Long(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FeedbackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItems", "CoWorker_CoWorkerId", "dbo.CoWorkers");
            DropForeignKey("dbo.WorkItems", "Strength_FeedbackId", "dbo.Feedbacks");
            DropForeignKey("dbo.WorkItems", "AreaForImprovement_FeedbackId", "dbo.Feedbacks");
            DropIndex("dbo.WorkItems", new[] { "CoWorker_CoWorkerId" });
            DropIndex("dbo.WorkItems", new[] { "Strength_FeedbackId" });
            DropIndex("dbo.WorkItems", new[] { "AreaForImprovement_FeedbackId" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.WorkItems");
            DropTable("dbo.CoWorkers");
        }
    }
}
