using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack.Web.CQRS.DTO
{
    public class AddNewVehicleOnTrack
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Identification { get; set; }
        
        [DisplayName("Are There Two Straps On Vehicle ?")]
        public bool AreThereTwoStrapsOnVehicle { get; set; }
        
        [DisplayName("Is Not Lifted More Than 5 Inches ?")]
        public bool IsNotLiftedMoreThan5Inches { get; set; }
                
        [DisplayName("Have Less Than 85% Tire Wear ?")]
        public bool HaveLessThan85PerTireWear { get; set; }
    }
}
