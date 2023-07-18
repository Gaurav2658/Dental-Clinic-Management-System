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
    public class ItemAssignMasterRepository
    {
        private readonly IDbConnection _db;

        public ItemAssignMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<ItemAssignMaster> GetItemAssignById(int id)
        {
            const string storedProcedure = "GetItemAssignById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<ItemAssignMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ItemAssignMaster>> GetAllItemAssign()
        {
            const string storedProcedure = "GetAllItemAssign";

            return (await _db.QueryAsync<ItemAssignMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> ItemAssignInsert(ItemAssignMaster assign)
        {

            const string storedProcedure = "ItemAssignInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@ItemId", assign.ItemId);
            parameters.Add("@CatId", assign.CatId);
            parameters.Add("@OpeningQty", assign.OpeningQty);
            parameters.Add("@OpeningRate", assign.OpeningRate);
            parameters.Add("@TotalAmount", assign.TotalAmount);
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateItemAssign(ItemAssignMaster assign)
        {
            const string storedProcedure = "UpdateItemAssign";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", assign.Id);
            parameters.Add("@ItemId", assign.ItemId);
            parameters.Add("@CatId", assign.CatId);
            parameters.Add("@OpeningQty", assign.OpeningQty);
            parameters.Add("@OpeningRate", assign.OpeningRate);
            parameters.Add("@TotalAmount", assign.TotalAmount);
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> ItemAssignDelete(int id)
        {
            const string storedProcedure = "ItemAssignDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }




    }
}
