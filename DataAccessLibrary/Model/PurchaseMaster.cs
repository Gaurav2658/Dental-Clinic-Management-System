using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class PurchaseMaster
    {
       
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(10)]
            public string BillNo { get; set; }

            [Required]
            public int ItemId { get; set; }

            [Required]
           public int SId { get; set; }

            [Required]
            
             public decimal Qty { get; set; }

            [Required]
            
            public decimal Rate { get; set; }


            [Required]
           
            public decimal TotalAmount { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string? CreatedBy { get; set; }
            public DateTime? ModifyDate { get; set; }
            public string? ModifyBy { get; set; }


        }
    }
