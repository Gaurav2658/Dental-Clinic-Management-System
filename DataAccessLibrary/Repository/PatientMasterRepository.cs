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
    public class PatientMasterRepository
    {


        private readonly IDbConnection _db;

        public PatientMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<int> PatientInsert(PatientMaster patient)
        {
            const string storedProcedure = "PatientInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@RegNo", patient.RegNo);
            parameters.Add("@PatientName", patient.PatientName);
            parameters.Add("@DateOfBirth", patient.DateOfBirth);
            parameters.Add("@Age", patient.Age);
            parameters.Add("@PhoneNo", patient.PhoneNo);
            parameters.Add("@Email", patient.Email);
            parameters.Add("@Gender", patient.Gender);
            parameters.Add("@Address", patient.Address);
            parameters.Add("@PersonName", patient.PersonName);
            parameters.Add("@PersonPhoneNo", patient.PersonPhoneNo);
            parameters.Add("@Relation", patient.Relation);
            parameters.Add("@PersonAddress", patient.PersonAddress);
            parameters.Add("@HBadBreathing", patient.HBadBreathing);
            parameters.Add("@HToothDecay", patient.HToothDecay);
            parameters.Add("@HMouthSores", patient.HMouthSores);
            parameters.Add("@HGum", patient.HGum);
            parameters.Add("@HToothErosion", patient.HToothErosion);
            parameters.Add("@HToothSensitivity", patient.HToothSensitivity);
            parameters.Add("@HToothAndDentalEmergency", patient.HToothAndDentalEmergency);
            parameters.Add("@RemarkHistory", patient.RemarkHistory);
            parameters.Add("@PBadBreathing", patient.PBadBreathing);
            parameters.Add("@PToothDecay", patient.PToothDecay);
            parameters.Add("@PMouthSores", patient.PMouthSores);
            parameters.Add("@PGum", patient.PGum);
            parameters.Add("@PToothErosion", patient.PToothErosion);
            parameters.Add("@PToothSensitivity", patient.PToothSensitivity);
            parameters.Add("@PToothAndDentalEmergency", patient.PToothAndDentalEmergency);
            parameters.Add("@RemarkProblem", patient.RemarkProblem);

            return await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdatePatient(PatientMaster patient)
        {
            const string storedProcedure = "UpdatePatient";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", patient.Id);
            parameters.Add("@RegNo", patient.RegNo);
            parameters.Add("@PatientName", patient.PatientName);
            parameters.Add("@DateOfBirth", patient.DateOfBirth);
            parameters.Add("@Age", patient.Age);
            parameters.Add("@PhoneNo", patient.PhoneNo);
            parameters.Add("@Email", patient.Email);
            parameters.Add("@Gender", patient.Gender);
            parameters.Add("@Address", patient.Address);
            parameters.Add("@PersonName", patient.PersonName);
            parameters.Add("@PersonPhoneNo", patient.PersonPhoneNo);
            parameters.Add("@Relation", patient.Relation);
            parameters.Add("@PersonAddress", patient.PersonAddress);
            parameters.Add("@HBadBreathing", patient.HBadBreathing);
            parameters.Add("@HToothDecay", patient.HToothDecay);
            parameters.Add("@HMouthSores", patient.HMouthSores);
            parameters.Add("@HGum", patient.HGum);
            parameters.Add("@HToothErosion", patient.HToothErosion);
            parameters.Add("@HToothSensitivity", patient.HToothSensitivity);
            parameters.Add("@HToothAndDentalEmergency", patient.HToothAndDentalEmergency);
            parameters.Add("@RemarkHistory", patient.RemarkHistory);
            parameters.Add("@PBadBreathing", patient.PBadBreathing);
            parameters.Add("@PToothDecay", patient.PToothDecay);
            parameters.Add("@PMouthSores", patient.PMouthSores);
            parameters.Add("@PGum", patient.PGum);
            parameters.Add("@PToothErosion", patient.PToothErosion);
            parameters.Add("@PToothSensitivity", patient.PToothSensitivity);
            parameters.Add("@PToothAndDentalEmergency", patient.PToothAndDentalEmergency);
            parameters.Add("@RemarkProblem", patient.RemarkProblem);

            return await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> PatientDelete(int id)
        {
            const string storedProcedure = "PatientDelete";
            var parameters = new { Id = id };

            var rowsAffected = await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

        public async Task<PatientMaster> GetPatientById(int id)
        {
            const string storedProcedure = "GetPatientById";
            var parameters = new { Id = id };

            return await _db.QueryFirstOrDefaultAsync<PatientMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PatientMaster>> GetAllPatient()
        {
            const string storedProcedure = "GetAllPatient";

            return (await _db.QueryAsync<PatientMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }
      

    }
}
