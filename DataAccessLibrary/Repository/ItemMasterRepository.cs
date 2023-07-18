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
    public class ItemMasterRepository
    {
        private readonly IDbConnection _db;

        public ItemMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<ItemMaster> GetItemById(int id)
        {
            const string storedProcedure = "GetItemById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<ItemMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ItemMaster>> GetAllItem()
        {
            const string storedProcedure = "GetAllItem";

            return (await _db.QueryAsync<ItemMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> ItemInsert(ItemMaster item)
        {

            const string storedProcedure = "ItemInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@ItemName", item.ItemName);
            parameters.Add("@BaseName", item.BaseName);
            parameters.Add("@UId", item.UId);
            parameters.Add("@ReOrderLevel", item.ReOrderLevel);
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateItem(ItemMaster item)
        {
            const string storedProcedure = "UpdateItem";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", item.Id);
            parameters.Add("@ItemName", item.ItemName);
            parameters.Add("@BaseName", item.BaseName);
            parameters.Add("@UId", item.UId);
            parameters.Add("@ReOrderLevel", item.ReOrderLevel);
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> ItemDelete(int id)
        {
            const string storedProcedure = "ItemDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }




    }
}
