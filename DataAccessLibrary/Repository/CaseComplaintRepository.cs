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
    public class CaseComplaintRepository
    {
        private readonly IDbConnection _db;

        public CaseComplaintRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<CaseComplaint> GetCaseComplaintById(int id)
        {
            const string storedProcedure = "GetCaseComplaintById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<CaseComplaint>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<CaseComplaint>> GetAllCaseComplaint()
        {
            const string storedProcedure = "GetAllCaseComplaint";

            return (await _db.QueryAsync<CaseComplaint>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> CaseComplaintInsert(CaseComplaint Case)
        {
            const string storedProcedure = "CaseComplaintInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@CaseId", Case.CaseId);
            parameters.Add("@Cid", Case.Cid);

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task CaseComplaintUpdate(CaseComplaint Case)
        {
            const string storedProcedure = "CaseComplaintUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Case.Id);
            parameters.Add("@CaseId", Case.CaseId);
            parameters.Add("@Cid", Case.Cid);


            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}


