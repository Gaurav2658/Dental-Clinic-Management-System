using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class ItemMaster
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(64)]
        public string BaseName { get; set; }

        [Required]

        public int UId { get; set; }

        [Required]
        [StringLength(16)]
        public string ReOrderLevel{ get; set; }
    }
}
