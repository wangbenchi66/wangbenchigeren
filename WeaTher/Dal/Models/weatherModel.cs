namespace Dal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class weatherModel : DbContext
    {
        public weatherModel()
            : base("name=weather")
        {
        }

        public virtual DbSet<cityInfo> cityInfo { get; set; }
        public virtual DbSet<cityweather> cityweather { get; set; }
        public virtual DbSet<forecast> forecast { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
