using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class ItemAssignMaster
    {

        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int CatId { get; set; }

        [Required]
        public int OpeningQty { get; set; }

        [Required]
        public decimal OpeningRate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }





    }
}
