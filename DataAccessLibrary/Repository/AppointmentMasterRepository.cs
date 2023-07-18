using Dapper;
using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
	public class AppointmentMasterRepository
    {


		private readonly IDbConnection _db;

		public AppointmentMasterRepository(IDbConnection dbContext)
		{
			_db = dbContext;
		}
		public async Task<AppointmentMaster> GetAppointmentById(int id)
		{
			const string storedProcedure = "GetAppointmentById";
			var parameters = new { Id = id };

			return await _db.QuerySingleOrDefaultAsync<AppointmentMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
		}

		public async Task<List<AppointmentMaster>> GetAllAppointment()
		{
			const string storedProcedure = "GetAllAppointment";

			return (await _db.QueryAsync<AppointmentMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
		}

		public async Task<int> AppointmentInsert(AppointmentMaster Appointment)
		{
			const string storedProcedure = "AppointmentInsert";
			var parameters = new DynamicParameters();
			parameters.Add("@PId", Appointment.PId);
			parameters.Add("@DId", Appointment.DId);
			parameters.Add("@Date", Appointment.Date);
			parameters.Add("@TimeSlot", Appointment.TimeSlot);
			parameters.Add("@Status", Appointment.Status);
			parameters.Add("@Remark", Appointment.Remark);

			await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			return 0;
		}
		public async Task AppointmentUpdate(AppointmentMaster Appointment)
		{

			const string storedProcedure = "UpdateAppointment";
			var parameters = new DynamicParameters();
			parameters.Add("@Id", Appointment.Id);
			parameters.Add("@PId", Appointment.PId);
			parameters.Add("@DId", Appointment.DId);
			parameters.Add("@Date", Appointment.Date);
			parameters.Add("@TimeSlot", Appointment.TimeSlot);
			parameters.Add("@Status", Appointment.Status);
			parameters.Add("@Remark", Appointment.Remark);

			await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

		}
		public async Task<bool> AppointmentDelete(int id)
		{
			const string storedProcedure = "AppointmentDelete";
			var parameters = new { Id = id };

			var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			return rowsAffected > 0;
		}

	}
}
