using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class CaseMaster
    {
        [Key]
        public int Id { get; set; }
        public int CNo { get; set; }
        public int PId { get; set; }
        public int DId { get; set; }
        public int PhonNo { get; set; }
        [Required]
        public DateTime? Date { get; set; }
    }
}
