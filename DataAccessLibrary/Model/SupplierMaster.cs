using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
   
        public class SupplierMaster
        {

            [Key]

            public int Id { get; set; }

            [Required]
            [StringLength(64)]
            public string CompanyName { get; set; }

            [Required]
            [StringLength(128)]
            public string Address{ get; set; }

            [Required]
            [StringLength(64)]
            public string state { get; set; }

            [Required]
            [StringLength(10)]
            public string Pincode { get; set; }


            [Required]
            [StringLength(10)]

            [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
            public string MobNo { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string? CreatedBy { get; set; }
            public DateTime? ModifyDate { get; set; }
            public string? ModifyBy { get; set; }



    }

}
