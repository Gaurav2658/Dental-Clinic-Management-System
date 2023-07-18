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
	public class CaseMasRepository
	{
		private readonly IDbConnection _db;

		public CaseMasRepository(IDbConnection dbContext)
		{
			_db = dbContext;
		}

		public async Task<CaseMas> GetCaseMasById(int id)
		{
			const string storedProcedure = "GetCaseMasById";
			var parameters = new { Id = id };

			return await _db.QuerySingleOrDefaultAsync<CaseMas>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
		}

		public async Task<List<CaseMas>> GetAllCaseMas()
		{
			const string storedProcedure = "GetAllCaseMas";

			return (await _db.QueryAsync<CaseMas>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
		}

		public async Task<int> CaseMasInsert(CaseMas Case)
		{
			const string storedProcedure = "CaseMasInsert";
			var parameters = new DynamicParameters();
			parameters.Add("@CNo", Case.CNo);
			parameters.Add("@PId", Case.PId);
			parameters.Add("@DId", Case.DId);
			parameters.Add("@PhonNo", Case.PhonNo);
			parameters.Add("@Date", Case.Date);
			parameters.Add("@CmpId", Case.CmpId);
			parameters.Add("@teethObser", Case.TeethObser);
			parameters.Add("@ObserId", Case.ObserId);
			parameters.Add("@Adviceteeth", Case.Adviceteeth);
			parameters.Add("@AdviceId", Case.AdviceId);
			parameters.Add("@TeethService", Case.TeethService);
			parameters.Add("@ServiceId", Case.ServiceId);
			parameters.Add("@Rate", Case.Rate);
			parameters.Add("@MedicineId", Case.MedicineId);
			parameters.Add("@Qty", Case.Qty);
			parameters.Add("@Dosage", Case.Dosage);
			parameters.Add("@Instruction", Case.Instruction);
		


			await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			return 0;
		}
		public async Task UpdateCaseMas(CaseMas Case)
		{
			const string storedProcedure = "UpdateCaseMas";
			var parameters = new DynamicParameters();
			parameters.Add("@Id", Case.Id);
			parameters.Add("@CNo", Case.CNo);
			parameters.Add("@PId", Case.PId);
			parameters.Add("@DId", Case.DId);
			parameters.Add("@PhonNo", Case.PhonNo);
			parameters.Add("@Date", Case.Date);
			parameters.Add("@CmpId", Case.CmpId);
			parameters.Add("@teethObser", Case.TeethObser);
			parameters.Add("@ObserId", Case.ObserId);
			parameters.Add("@Adviceteeth", Case.Adviceteeth);
			parameters.Add("@AdviceId", Case.AdviceId);
			parameters.Add("@TeethService", Case.TeethService);
			parameters.Add("@ServiceId", Case.ServiceId);
			parameters.Add("@Rate", Case.Rate);
			parameters.Add("@MedicineId", Case.MedicineId);
			parameters.Add("@Qty", Case.Qty);
			parameters.Add("@Dosage", Case.Dosage);
			parameters.Add("@Instruction", Case.Instruction);

			await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
		}
		public async Task<bool> CaseMasDelete(int id)
		{
			const string storedProcedure = "CaseMasDelete";
			var parameters = new { Id = id };

			var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			return rowsAffected > 0;
		}


	}
}
