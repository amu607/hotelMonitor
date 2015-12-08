using System.ComponentModel.DataAnnotations;

namespace hotelMonitor.Models.Entity
{
    public class HotelTask : EntityBase
    {
        [StringLength(50)]
        public string TaskName { get; set; }

        public HotelTaskStatus HotelTaskStatus { get; set; }

        [StringLength(10)]
        public string WorkerName { get; set; }

        [StringLength(10)]
        public string RoomName { get; set; }
    }
}