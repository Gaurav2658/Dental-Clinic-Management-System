using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
	public class AppointmentMaster
	{
		public int Id { get; set; }
		public int PId { get; set; }
		public int DId { get; set; }
		public DateTime Date { get; set; }
		public DateTime TimeSlot { get; set; }
		public string Status { get; set; }
		public string? Remark { get; set; }
	}
}
