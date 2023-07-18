using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
	public class CaseMas
	{
		[Key]
		public int Id { get; set; }
		public string CNo { get; set; }
		public int PId { get; set; }
		public int DId { get; set; }
		public int PhonNo { get; set; }
		[Required]
		public DateTime? Date { get; set; }
		public int CmpId { get; set; }
		public int TeethObser { get; set; }
		public int ObserId { get; set; }
		public int Adviceteeth { get; set; }
		public int AdviceId { get; set; }

		public int TeethService { get; set; }
		public int ServiceId { get; set; }
		[Required]
		[StringLength(64)]
		public string Rate { get; set; }
		public int MedicineId { get; set; }
		public int Qty { get; set; }
		public int Dosage { get; set; }
		[Required]
		[StringLength(64)]
		public string Instruction { get; set; }
	}
}
