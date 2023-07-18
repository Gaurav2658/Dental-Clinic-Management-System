using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    namespace UnitMaster
    {
        public class UnitMaster
        {
            [Key]

            public int Id { get; set; }


            [Required]
            [StringLength(64)]
            public string Name { get; set; }

            [Required]
            public bool IsActive { get; set; }

        }
    }
   
}
