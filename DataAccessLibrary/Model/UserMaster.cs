using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    namespace UserMaster
    {
        public class UserMaster
        {
         
                [Key]
           
                public int Id { get; set; }

                [Required]
                [StringLength(64)]
                [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address.")]
                public string Email { get; set; }

                [Required]
                [StringLength(128)]
                public string Password { get; set; }

                [Required]
                [StringLength(64)]
                public string Name { get; set; }


                [Required]
                public int Type { get; set; }


                [Required]
                [StringLength(300)]
                public string Address { get; set; }


                [Required]
                [StringLength(10)]
                [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
                public string MobileNo { get; set; }


                [Required]
                public bool IsActive { get; set; }


               
                public DateTime? CreatedDate { get; set; }


                public string? CreatedBy { get; set; }


               
                public DateTime? ModifyDate { get; set; }


               
                public string? ModifyBy { get; set; }
           
        }
        }
    }
