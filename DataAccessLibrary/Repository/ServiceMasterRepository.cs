using Dapper;
using DataAccessLibrary.Model.ServiceMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class ServiceMasterRepository
    {


        private readonly IDbConnection _db;

        public ServiceMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }
        public async Task<ServiceMaster> GetServiceById(int id)
        {
            const string storedProcedure = "GetServiceById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<ServiceMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ServiceMaster>> GetAllService()
        {
            const string storedProcedure = "GetAllService";

            return (await _db.QueryAsync<ServiceMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> ServiceInsert(ServiceMaster service)
        {
            service.CreatedDate = DateTime.Now;
            const string storedProcedure = "ServiceInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", service.Name);
            parameters.Add("@Description", service.Description);
            parameters.Add("@Amount", service.Amount);
			parameters.Add("@OrderBy", service.OrderBy);
			parameters.Add("@IsActive", service.IsActive);
           /* parameters.Add("@CreatedDate", service.CreatedDate);
            parameters.Add("@CreatedBy", service.CreatedBy);
            parameters.Add("@ModifyDate", service.ModifyDate);
            parameters.Add("@ModifyBy", service.ModifyBy);*/

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateService(ServiceMaster service)
        {

            const string storedProcedure = "UpdateService";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", service.Id);
            parameters.Add("@Name", service.Name);
            parameters.Add("@Description", service.Description);
            parameters.Add("@Amount", service.Amount);
			parameters.Add("@OrderBy", service.OrderBy);
			parameters.Add("@IsActive", service.IsActive);
          /*  parameters.Add("@CreatedDate", service.CreatedDate);
            parameters.Add("@CreatedBy", service.CreatedBy);
            parameters.Add("@ModifyDate", service.ModifyDate);
            parameters.Add("@ModifyBy", service.ModifyBy);*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> ServiceDelete(int id)
        {
            const string storedProcedure = "ServiceDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

    }
}
