using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotelMonitor.Models.Entity
{
    public class EntityBase
    {
        [Key]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Create Data DateTime
        /// </summary>
        public DateTime CreateDatetime { get; set; }

        /// <summary>
        /// Update Data DateTime
        /// </summary>
        public DateTime UpdateDatetime { get; set; }
    }
}