using Dapper;
using DataAccessLibrary.Model.MedicineMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class MedicineMasterRepository
    {


        private readonly IDbConnection _db;

        public MedicineMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }
        public async Task<MedicineMaster> GetMedicineById(int id)
        {
            const string storedProcedure = "GetMedicineById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<MedicineMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<MedicineMaster>> GetAllMedicine()
        {
            const string storedProcedure = "GetAllMedicine";

            return (await _db.QueryAsync<MedicineMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> MedicineInsert(MedicineMaster medicine)
        {
            medicine.CreatedDate = DateTime.Now;
            const string storedProcedure = "MedicineInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", medicine.Name);
            parameters.Add("@Dosage", medicine.Dosage);
            parameters.Add("@Instruction", medicine.Instruction);
           
            parameters.Add("@IsActive", medicine.IsActive);
          /*  parameters.Add("@CreatedDate", medicine.CreatedDate);
            parameters.Add("@CreatedBy", medicine.CreatedBy);
            parameters.Add("@ModifyDate", medicine.ModifyDate);
            parameters.Add("@ModifyBy", medicine.ModifyBy);*/

            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateMedicine(MedicineMaster medicine)
        {

            const string storedProcedure = "UpdateMedicine";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", medicine.Id);
            parameters.Add("@Name", medicine.Name);
            parameters.Add("@Dosage", medicine.Dosage);
            parameters.Add("@Instruction", medicine.Instruction);
          
            parameters.Add("@IsActive", medicine.IsActive);
           /* parameters.Add("@CreatedDate", medicine.CreatedDate);
            parameters.Add("@CreatedBy", medicine.CreatedBy);
            parameters.Add("@ModifyDate", medicine.ModifyDate);
            parameters.Add("@ModifyBy", medicine.ModifyBy);*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> MedicineDelete(int id)
        {
            const string storedProcedure = "MedicineDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

    }
}

