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
    public class CaseMasterRepository
    {
        private readonly IDbConnection _db;

        public CaseMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<CaseMaster> GetCaseById(int id)
        {
            const string storedProcedure = "GetCaseById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<CaseMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<CaseMaster>> GetAllCase()
        {
            const string storedProcedure = "GetAllCase";

            return (await _db.QueryAsync<CaseMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> CaseInsert(CaseMaster Case)
        {
            const string storedProcedure = "CaseInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@CNo", Case.CNo);
            parameters.Add("@PId", Case.PId);
            parameters.Add("@DId", Case.DId);
            parameters.Add("@PhonNo", Case.PhonNo);
            /*            parameters.Add("@Name", );
            */
            parameters.Add("@Date", Case.Date);
            //parameters.Add("@CId", Case.Date);
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateCase(CaseMaster Case)
        {
            const string storedProcedure = "UpdateCase";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Case.Id);
            parameters.Add("@CNo", Case.CNo);
            parameters.Add("@PId", Case.PId);
            parameters.Add("@DId", Case.DId);
            parameters.Add("@PhonNo", Case.PhonNo);
            parameters.Add("@Date", Case.Date);

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> CaseDelete(int id)
        {
            const string storedProcedure = "CaseDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }


    }
}
