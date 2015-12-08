using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotelMonitor.Models.Entity
{
    public class Room : EntityBase
    {
        [Index(IsUnique = true)]
        public string RoomName { get; set; }
    }
}