using Dapper;
using DataAccessLibrary.Model;
using DataAccessLibrary.Model.UserMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class PurchaseMasterRepository
    {
        private readonly IDbConnection _db;

        public PurchaseMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<PurchaseMaster> GetPurchaseById(int id)
        {
            const string storedProcedure = "GetPurchaseById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<PurchaseMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<PurchaseMaster>> GetAllPurchase()
        {
            const string storedProcedure = "GetAllPurchase";

            return (await _db.QueryAsync<PurchaseMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> PurchaseInsert(PurchaseMaster purchase)
        {
            purchase.CreatedDate = DateTime.UtcNow;

            const string storedProcedure = "PurchaseInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@BillNo", purchase.BillNo);
            parameters.Add("@ItemId", purchase.ItemId);
            parameters.Add("@SId", purchase.SId);
            parameters.Add("@Qty", purchase.Qty);
            parameters.Add("@Rate", purchase.Rate);
            parameters.Add("@TotalAmount", purchase.TotalAmount);
           
            /*parameters.Add("@CreatedDate", user.CreatedDate);
            parameters.Add("@CreatedBy", user.CreatedBy);
            parameters.Add("@ModifyDate", user.ModifyDate);
            parameters.Add("@ModifyBy", user.ModifyBy);
            */
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdatePurchase(PurchaseMaster purchase)
        {
            const string storedProcedure = "UpdatePurchase";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", purchase.Id);
            parameters.Add("@BillNo", purchase.BillNo);
            parameters.Add("@ItemId", purchase.ItemId);

            parameters.Add("@SId", purchase.SId);
            parameters.Add("@Qty", purchase.Qty);
            parameters.Add("@Rate", purchase.Rate);
            parameters.Add("@TotalAmount", purchase.TotalAmount);

            /*parameters.Add("@CreatedDate", user.CreatedDate);
            parameters.Add("@CreatedBy", user.CreatedBy);
            parameters.Add("@ModifyDate", user.ModifyDate);
            parameters.Add("@ModifyBy", user.ModifyBy);
            */
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> PurchaseDelete(int id)
        {
            const string storedProcedure = "PurchaseDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }




    }
}
