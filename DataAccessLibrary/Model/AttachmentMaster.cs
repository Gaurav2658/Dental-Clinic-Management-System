using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    namespace AttachmentMaster
    {
        public class AttachmentMaster
        {

            [Key]

            public int Id { get; set; }


            [Required]
            [StringLength(64)]
            public string Type { get; set; }

            [Required]
            [StringLength(128)]
            public string Description { get; set; }


            [Required]
            public bool IsActive { get; set; }



            public DateTime? CreatedDate { get; set; }



            public string? CreatedBy { get; set; }



            public DateTime? ModifyDate { get; set; }



            public string? ModifyBy { get; set; }
        }

    }
}