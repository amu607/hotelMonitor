namespace hotelMonitor.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDB : DbContext
    {
        public HotelDB()
            : base("name=HotelDB")
        {
        }

        public IDbSet<HotelTask> HotelTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
