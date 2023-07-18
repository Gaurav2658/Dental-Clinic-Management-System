using Dapper;
using DataAccessLibrary.Model.AdviceMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class AdviceMasterRepository
    {


        private readonly IDbConnection _db;

        public AdviceMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }
        public async Task<AdviceMaster> GetAdviceById(int id)
        {
            const string storedProcedure = "GetAdviceById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<AdviceMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<AdviceMaster>> GetAllAdvice()
        {
            const string storedProcedure = "GetAllAdvice";

            return (await _db.QueryAsync<AdviceMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> AdviceInsert(AdviceMaster Advice)
        {
            Advice.CreatedDate = DateTime.Now;
            const string storedProcedure = "AdviceInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", Advice.Name);
            parameters.Add("@Description", Advice.Description);
          
            parameters.Add("@OrderBy", Advice.OrderBy);
            parameters.Add("@IsActive", Advice.IsActive);
           /* parameters.Add("@CreatedDate", Advice.CreatedDate);
            parameters.Add("@CreatedBy", Advice.CreatedBy);
            parameters.Add("@ModifyDate", Advice.ModifyDate);
            parameters.Add("@ModifyBy", Advice.ModifyBy);*/

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateAdvice(AdviceMaster Advice)
        {

            const string storedProcedure = "UpdateAdvice";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Advice.Id);
            parameters.Add("@Name", Advice.Name);
            parameters.Add("@Description", Advice.Description);
         
            parameters.Add("@OrderBy", Advice.OrderBy);
            parameters.Add("@IsActive", Advice.IsActive);
           /* parameters.Add("@CreatedDate", Advice.CreatedDate);
            parameters.Add("@CreatedBy", Advice.CreatedBy);
            parameters.Add("@ModifyDate", Advice.ModifyDate);
            parameters.Add("@ModifyBy", Advice.ModifyBy);*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> AdviceDelete(int id)
        {
            const string storedProcedure = "AdviceDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

    }
}
