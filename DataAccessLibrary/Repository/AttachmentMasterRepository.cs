using Dapper;
using DataAccessLibrary.Model.AttachmentMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class AttachmentMasterRepository
    {
        private readonly IDbConnection _db;

        public AttachmentMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }
        public async Task<AttachmentMaster> GetAttachmentById(int id)
        {
            const string storedProcedure = "GetAttachmentById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<AttachmentMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<AttachmentMaster>> GetAllAttachment()
        {
            const string storedProcedure = "GetAllAttachment";

            return (await _db.QueryAsync<AttachmentMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }
        public async Task<int> AttachmentInsert(AttachmentMaster attach)
        {
            attach.CreatedDate = DateTime.Now;
            const string storedProcedure = "AttachmentInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Type", attach.Type);
            parameters.Add("@Description", attach.Description);
            parameters.Add("@IsActive", attach.IsActive);
            /* parameters.Add("@CreatedDate", service.CreatedDate);
             parameters.Add("@CreatedBy", service.CreatedBy);
             parameters.Add("@ModifyDate", service.ModifyDate);
             parameters.Add("@ModifyBy", service.ModifyBy);*/

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateAttachment(AttachmentMaster attach)
        {

            const string storedProcedure = "UpdateAttachment";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", attach.Id);
            parameters.Add("@Type", attach.Type);
            parameters.Add("@Description", attach.Description);
            parameters.Add("@IsActive", attach.IsActive);
            /*  parameters.Add("@CreatedDate", service.CreatedDate);
              parameters.Add("@CreatedBy", service.CreatedBy);
              parameters.Add("@ModifyDate", service.ModifyDate);
              parameters.Add("@ModifyBy", service.ModifyBy);*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> AttachmentDelete(int id)
        {
            const string storedProcedure = "AttachmentDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }
    }
}
