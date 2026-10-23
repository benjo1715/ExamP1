using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExamP1.Models
{
    public class VisionQuestContext : DbContext
    {
        public VisionQuestContext() : base("name=VisionQuestContext"){ }
        public DbSet<Sintezoide> sintezoides { get; set; }
        public DbSet<Recuerdo> recuerdos { get; set; }
    }
}