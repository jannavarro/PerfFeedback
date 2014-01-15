using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfFeedback.BusinessService.Contract
{
    public class FeedbackContext : DbContext
    {
        public DbSet CoWorker { get; set; }
        public DbSet<Strength> Strengths { get; set; }
        public DbSet<AreaForImprovement> AreasForImprovement { get; set; }
    }
}
