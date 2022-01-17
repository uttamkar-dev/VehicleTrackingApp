using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Entity.Entities
{
    public class VehicleGeoLocation : BaseEntity
    {
        [MaxLength(128)]
        public string City { get; set; }
        [MaxLength(128)]
        public string State { get; set; }
        [MaxLength(128)]
        public string Country { get; set; }
        [Column(TypeName = "decimal(11,8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }
        [MaxLength(512)]
        public string Address { get; set; }
        public DateTime TrackingDate { get; set; }
        public int UserId { get; set; }
        [MaxLength(128)]
        public string VehicleNo { get; set; }
        public User User { get; set; }
    }
}
