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
    public class SupplierMasterRepository
    {
        private readonly IDbConnection _db;

        public SupplierMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<SupplierMaster> GetSupplierById(int id)
        {
            const string storedProcedure = "GetSupplierById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<SupplierMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<SupplierMaster>> GetAllSupplier()
        {
            const string storedProcedure = "GetAllSupplier";

            return (await _db.QueryAsync<SupplierMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> SupplierInsert(SupplierMaster supplier)
        {
            supplier.CreatedDate = DateTime.UtcNow;
            const string storedProcedure = "SupplierInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@CompanyName", supplier.CompanyName);
            parameters.Add("@Address", supplier.Address);
            parameters.Add("@state", supplier.state);
            parameters.Add("@Pincode", supplier.Pincode);
            parameters.Add("@MobNo", supplier.MobNo);
          
            /*parameters.Add("@CreatedDate", user.CreatedDate);
            parameters.Add("@CreatedBy", user.CreatedBy);
            parameters.Add("@ModifyDate", user.ModifyDate);
            parameters.Add("@ModifyBy", user.ModifyBy);
            */
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateSupplier(SupplierMaster supplier)
        {
            const string storedProcedure = "UpdateSupplier";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", supplier.Id);
            parameters.Add("@CompanyName", supplier.CompanyName);
            parameters.Add("@Address", supplier.Address);
            parameters.Add("@state", supplier.state);
            parameters.Add("@Pincode", supplier.Pincode);
            parameters.Add("@MobNo", supplier.MobNo);

            /*parameters.Add("@CreatedDate", user.CreatedDate);
            parameters.Add("@CreatedBy", user.CreatedBy);
            parameters.Add("@ModifyDate", user.ModifyDate);
            parameters.Add("@ModifyBy", user.ModifyBy);
            */
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> DeleteSupplier(int id)
        {
            const string storedProcedure = "SupplierDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }




    }
}
