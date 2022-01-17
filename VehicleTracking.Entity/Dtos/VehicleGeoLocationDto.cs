using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Entity.Dtos
{
    public class VehicleGeoLocationDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime TrackingDate { get; set; }
        public int? UserId { get; set; }
        [Required]
        public string VehicleNo { get; set; }
    }
}
