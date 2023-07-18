using Dapper;
using DataAccessLibrary.Model.UnitMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class UnitMasterRepository
    {
        private readonly IDbConnection _db;

        public UnitMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<UnitMaster> GetUnitById(int id)
        {
            const string storedProcedure = "GetUnitById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<UnitMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<UnitMaster>> GetAllUnit()
        {
            const string storedProcedure = "GetAllUnit";

            return (await _db.QueryAsync<UnitMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> UnitInsert(UnitMaster unit)
        {
          

            const string storedProcedure = "UnitInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", unit.Name);
            parameters.Add("@IsActive", unit.IsActive);
           
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateUnit(UnitMaster unit)
        {
            const string storedProcedure = "UpdateUnit";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", unit.Id);
            parameters.Add("@Name", unit.Name);
            parameters.Add("@IsActive", unit.IsActive);
          
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> UnitDelete(int id)
        {
            const string storedProcedure = "UnitDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

    }
}
