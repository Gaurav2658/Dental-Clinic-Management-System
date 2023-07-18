using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLibrary.Model
{
    public class PatientMaster
    {
        public int Id { get; set; }

		
		public string RegNo { get; set; }

		
		public string PatientName { get; set; }
		
		public DateTime? DateOfBirth { get; set; }
       
        public int Age { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        public string PhoneNo { get; set; }
		public string? Email { get; set; }

		
		public string Gender { get; set; }

		
		public string Address { get; set; }
        public string? PersonName { get; set; }
        public string? PersonPhoneNo { get; set; }
        public string?Relation { get; set; }
        public string ?PersonAddress { get; set; }
        public bool HBadBreathing { get; set; }
        public bool HToothDecay { get; set; }
        public bool HMouthSores { get; set; }
        public bool HGum { get; set; }
        public bool HToothErosion { get; set; }
        public bool HToothSensitivity { get; set; }
        public bool HToothAndDentalEmergency { get; set; }
        public string? RemarkHistory { get; set; }
        public bool PBadBreathing { get; set; }
        public bool PToothDecay { get; set; }
        public bool PMouthSores { get; set; }
        public bool PGum { get; set; }
        public bool PToothErosion { get; set; }
        public bool PToothSensitivity { get; set; }
        public bool PToothAndDentalEmergency { get; set; }
        public string? RemarkProblem { get; set; }
    }
}
