using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hotelMonitor.Models.Entity;

namespace hotelMonitor.Models
{
    public class HotelTaskListViewModel
    {
        public IList<HotelTaskViewModel> Tasks { get; set; }
    }

    public class HotelTaskViewModel
    {
        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public string WorkerName { get; set; }

        public string RoomName { get; set; }

        public HotelTaskStatus HotelTaskStatus { get; set; }

        public string CreateDateTime { get; set; }
        
    }
}