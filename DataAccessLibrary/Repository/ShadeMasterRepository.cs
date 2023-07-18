using Dapper;
using DataAccessLibrary.Model.ShadeMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class ShadeMasterRepository
    {

        private readonly IDbConnection _db;

        public ShadeMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }
        public async Task<ShadeMaster> GetShadeById(int id)
        {
            const string storedProcedure = "GetShadeById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<ShadeMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ShadeMaster>> GetAllShade()
        {
            const string storedProcedure = "GetAllShade";

            return (await _db.QueryAsync<ShadeMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> ShadeInsert(ShadeMaster shade)
        {
            shade.CreatedDate = DateTime.Now;
            const string storedProcedure = "ShadeInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", shade.Name);
            parameters.Add("@Description", shade.Description);

            parameters.Add("@IsActive", shade.IsActive);
            /* parameters.Add("@CreatedDate", service.CreatedDate);
             parameters.Add("@CreatedBy", service.CreatedBy);
             parameters.Add("@ModifyDate", service.ModifyDate);
             parameters.Add("@ModifyBy", service.ModifyBy);*/

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateShade(ShadeMaster shade)
        {

            const string storedProcedure = "UpdateShade";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", shade.Id);
            parameters.Add("@Name", shade.Name);
            parameters.Add("@Description", shade.Description);
            parameters.Add("@IsActive", shade.IsActive);
            /*  parameters.Add("@CreatedDate", service.CreatedDate);
              parameters.Add("@CreatedBy", service.CreatedBy);
              parameters.Add("@ModifyDate", service.ModifyDate);
              parameters.Add("@ModifyBy", service.ModifyBy);*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> ShadeDelete(int id)
        {
            const string storedProcedure = "ShadeDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }
    }
}
