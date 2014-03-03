namespace PerfFeedback.WcfBusinessService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkItems", "Strength_FeedbackId", "dbo.Feedbacks");
            DropIndex("dbo.WorkItems", new[] { "Strength_FeedbackId" });
            AddColumn("dbo.WorkItems", "Strength_FeedbackId1", c => c.Long());
            AlterColumn("dbo.WorkItems", "Strength_FeedbackId", c => c.Long(nullable: false));
            CreateIndex("dbo.WorkItems", "Strength_FeedbackId1");
            AddForeignKey("dbo.WorkItems", "Strength_FeedbackId1", "dbo.Feedbacks", "FeedbackId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItems", "Strength_FeedbackId1", "dbo.Feedbacks");
            DropIndex("dbo.WorkItems", new[] { "Strength_FeedbackId1" });
            AlterColumn("dbo.WorkItems", "Strength_FeedbackId", c => c.Long());
            DropColumn("dbo.WorkItems", "Strength_FeedbackId1");
            CreateIndex("dbo.WorkItems", "Strength_FeedbackId");
            AddForeignKey("dbo.WorkItems", "Strength_FeedbackId", "dbo.Feedbacks", "FeedbackId");
        }
    }
}
