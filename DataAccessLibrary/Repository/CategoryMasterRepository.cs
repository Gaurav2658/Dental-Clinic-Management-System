using Dapper;
using DataAccessLibrary.Model.CategoryMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class CategoryMasterRepository
    {
        private readonly IDbConnection _db;

        public CategoryMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<CategoryMaster> GetCatById(int id)
        {
            const string storedProcedure = "GetCatById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<CategoryMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<CategoryMaster>> GetAllCat()
        {
            const string storedProcedure = "GetAllCat";

            return (await _db.QueryAsync<CategoryMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> CategoryInsert(CategoryMaster cat)
        {


            const string storedProcedure = "CategoryInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", cat.Name);
            parameters.Add("@OrderBy", cat.OrderBy);
            parameters.Add("@IsActive", cat.IsActive);

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateCategory(CategoryMaster cat)
        {
            const string storedProcedure = "UpdateCategory";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", cat.Id);
            parameters.Add("@Name", cat.Name);
            parameters.Add("@OrderBy", cat.OrderBy);
            parameters.Add("@IsActive", cat.IsActive);

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> CategoryDelete(int id)
        {
            const string storedProcedure = "CategoryDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

    }
}
