using Dapper;
using DataAccessLibrary.Model.ComplaintMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository.ComplaintMasterRepository
{
    public class ComplaintMasterRepository
    {

        private readonly IDbConnection _db;

        public ComplaintMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<ComplaintMaster> GetComplaintById(int id)
        {
            const string storedProcedure = "GetComplaintById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<ComplaintMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ComplaintMaster>> GetAllComplaint()
        {
            const string storedProcedure = "GetAllComplaint";

            return (await _db.QueryAsync<ComplaintMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> ComplaintInsert(ComplaintMaster complaint)
        {
            complaint.CreatedDate = DateTime.Now;
            const string storedProcedure = "ComplaintInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", complaint.Name);
            parameters.Add("@Description", complaint.Description);
           
            parameters.Add("@OrderBy", complaint.OrderBy);
            parameters.Add("@IsActive", complaint.IsActive);
            /*parameters.Add("@CreatedDate", complaint.CreatedDate);
            parameters.Add("@CreatedBy", complaint.CreatedBy);
            parameters.Add("@ModifyDate", complaint.ModifyDate);
            parameters.Add("@ModifyBy", complaint.ModifyBy);
*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateComplaint(ComplaintMaster complaint)
        {

            const string storedProcedure = "UpdateComplaint";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", complaint.Id);
            parameters.Add("@Name", complaint.Name);
            parameters.Add("@Description", complaint.Description);
         
            parameters.Add("@OrderBy", complaint.OrderBy);
            parameters.Add("@IsActive", complaint.IsActive);
          /*  parameters.Add("@CreatedDate", complaint.CreatedDate);
            parameters.Add("@CreatedBy", complaint.CreatedBy);
            parameters.Add("@ModifyDate", complaint.ModifyDate);
            parameters.Add("@ModifyBy", complaint.ModifyBy);*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> ComplaintDelete(int id)
        {
            const string storedProcedure = "ComplaintDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }


    }
}
