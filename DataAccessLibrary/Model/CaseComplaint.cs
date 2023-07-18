using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
	public class CaseComplaint
	{
		[Key]
		public int Id { get; set; }
		public int CaseId { get; set; }
		public int Cid { get; set; }

		
	}
}
