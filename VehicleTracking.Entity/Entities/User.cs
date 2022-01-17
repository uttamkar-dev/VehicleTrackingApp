using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Entity.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(128)]
        public string UserName { get; set; }
        [MaxLength(128)]
        public string VehicleNo { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [MaxLength(256)]
        public string City { get; set; }
        [MaxLength(256)]
        public string Country { get; set; }
        public int RoleId { get; set; }
        public IList<VehicleGeoLocation> VehicleGeoLocations { get; set; }
    }
}
