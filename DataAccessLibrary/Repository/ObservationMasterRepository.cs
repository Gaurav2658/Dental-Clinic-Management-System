using Dapper;
using DataAccessLibrary.Model.ObservationMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class ObservationMasterRepository
    {


        private readonly IDbConnection _db;

        public ObservationMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }
        public async Task<ObservationMaster> GetObservationById(int id)
        {
            const string storedProcedure = "GetObservationById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<ObservationMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ObservationMaster>> GetAllObservation()
        {
            const string storedProcedure = "GetAllObservation";

            return (await _db.QueryAsync<ObservationMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> ObservationInsert(ObservationMaster Obser)
        {
            Obser.CreatedDate = DateTime.Now;
            const string storedProcedure = "ObservationInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", Obser.Name);
            parameters.Add("@Description", Obser.Description);
            parameters.Add("@OrderBy", Obser.OrderBy);
            parameters.Add("@IsActive", Obser.IsActive);
           /* parameters.Add("@CreatedDate", Obser.CreatedDate);
            parameters.Add("@CreatedBy", Obser.CreatedBy);
            parameters.Add("@ModifyDate", Obser.ModifyDate);
            parameters.Add("@ModifyBy", Obser.ModifyBy);
*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateObservation(ObservationMaster Obser)
        {

            const string storedProcedure = "UpdateObservation";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Obser.Id);
            parameters.Add("@Name", Obser.Name);
            parameters.Add("@Description", Obser.Description);
            parameters.Add("@OrderBy", Obser.OrderBy);
            parameters.Add("@IsActive", Obser.IsActive);
           /* parameters.Add("@CreatedDate", Obser.CreatedDate);
            parameters.Add("@CreatedBy", Obser.CreatedBy);
            parameters.Add("@ModifyDate", Obser.ModifyDate);
            parameters.Add("@ModifyBy", Obser.ModifyBy);*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> ObservationDelete(int id)
        {
            const string storedProcedure = "ObservationDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

    }
}
