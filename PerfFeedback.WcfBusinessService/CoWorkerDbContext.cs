
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using PerfFeedback.BusinessService.Contract;
using PerfFeedback.WcfBusinessService.Migrations;

namespace PerfFeedback.WcfBusinessService
{
    public class CoWorkerDbContext : DbContext
    {
        public CoWorkerDbContext()
            : base("PerfFeedbackConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CoWorkerDbContext, Configuration>());
        }

        public DbSet<CoWorker> CoWorkers { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
