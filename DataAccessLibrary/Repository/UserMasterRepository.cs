using Dapper;
using DataAccessLibrary.Model.UserMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class UserMasterRepository
    {
        private readonly IDbConnection _db;

        public UserMasterRepository(IDbConnection dbContext)
        {
            _db = dbContext;
        }

        public async Task<UserMaster> GetUserById(int id)
        {
            const string storedProcedure = "GetUserById";
            var parameters = new { Id = id };

            return await _db.QuerySingleOrDefaultAsync<UserMaster>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<UserMaster>> GetAllUser()
        {
            const string storedProcedure = "GetAllUser";

            return (await _db.QueryAsync<UserMaster>(storedProcedure, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<int> InsertUser(UserMaster user)
        {
            user.CreatedDate = DateTime.UtcNow;

            const string storedProcedure = "InsertUser";
            var parameters = new DynamicParameters();
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Name", user.Name);
            parameters.Add("@Type", user.Type);
            parameters.Add("@Address", user.Address);
            parameters.Add("@MobileNo", user.MobileNo);
            parameters.Add("@IsActive", user.IsActive);
            /*parameters.Add("@CreatedDate", user.CreatedDate);
            parameters.Add("@CreatedBy", user.CreatedBy);
            parameters.Add("@ModifyDate", user.ModifyDate);
            parameters.Add("@ModifyBy", user.ModifyBy);
            */await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        public async Task UpdateUser(UserMaster user)
        {
            const string storedProcedure = "UpdateUser";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", user.Id);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Name", user.Name);
            parameters.Add("@Type", user.Type);
            parameters.Add("@Address", user.Address);
            parameters.Add("@MobileNo", user.MobileNo);
            parameters.Add("@IsActive", user.IsActive);
           /* parameters.Add("@CreatedDate", user.CreatedDate);
            parameters.Add("@CreatedBy", user.CreatedBy);
            parameters.Add("@ModifyDate", user.ModifyDate);
            parameters.Add("@ModifyBy", user.ModifyBy);
*/
            await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> DeleteUser(int id)
        {
            const string storedProcedure = "DeleteUser";
            var parameters = new { Id = id };

            var rowsAffected =await _db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }


  

    }
}
