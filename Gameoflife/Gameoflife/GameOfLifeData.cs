namespace Gameoflife
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameOfLifeData : DbContext
    {
        public GameOfLifeData()
            : base("name=GameOfLifeData")
        {
        }

        public virtual DbSet<UserTemplate> UserTemplates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
