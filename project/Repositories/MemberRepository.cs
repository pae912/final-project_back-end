using Dapper;
using System.Data;
using project.Dtos;
using project.Models;
using project.Contracts;
using Microsoft.Data.SqlClient;

namespace project.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task<IEnumerable<Members>> GetMembers()
        {
            string sqlQuery = "SELECT * FROM Members";
            using (var connection = new SqlConnection(_connectString))
            {
                var members = await connection.QueryAsync<Members>(sqlQuery);
                return members.ToList();
            }
        }
        public async Task<Members> GetMember(Guid M_id)
        {
            string sqlQuery = "SELECT * FROM Members WHERE M_id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                var member = await connection.QuerySingleOrDefaultAsync<Members>(sqlQuery, new { Id = M_id });
                return member;
            }
        }
        public async Task<Members> CreateMember(MemberForCreationDto member)
        {
            string sqlQuery = "INSERT INTO Members (M_id, M_name, M_phone, M_sex, M_add, M_date, M_mail) VALUES(@Id, @Name, @Phone, @Sex, @Add, @Date, @Mail)";
            var parameters = new DynamicParameters();
            Guid M_id = Guid.NewGuid();
            parameters.Add("Id", M_id, DbType.Guid);
            parameters.Add("Name", member.M_name, DbType.String);
            parameters.Add("Phone", member.M_phone, DbType.String);
            parameters.Add("Sex", member.M_sex, DbType.String);
            parameters.Add("Add", member.M_add, DbType.String);
            parameters.Add("Date", member.M_date, DbType.String);
            parameters.Add("Mail", member.M_mail, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
                var createdMember = new Members
                {
                    M_id = M_id,
                    M_name = member.M_name,
                    M_phone = member.M_phone,
                    M_sex = member.M_sex,
                    M_add = member.M_add,
                    M_date = member.M_date,
                    M_mail = member.M_mail,
                };
                return createdMember;
            }
        }
        public async Task UpdateMember(Guid M_id, MemberForUpdateDto member)
        {
            var query = "UPDATE Members SET M_name = @Name, M_phone = @Phone, M_sex = @Sex, M_add = @Add, M_date = @Date, M_mail = @Mail  WHERE M_id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", M_id, DbType.Guid);
            parameters.Add("Name", member.M_name, DbType.String);
            parameters.Add("Phone", member.M_phone, DbType.String);
            parameters.Add("Sex", member.M_sex, DbType.String);
            parameters.Add("Add", member.M_add, DbType.String);
            parameters.Add("Date", member.M_date, DbType.String);
            parameters.Add("Mail", member.M_mail, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteMember(Guid M_id)
        {
            var query = "DELETE FROM Members WHERE M_id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, new { Id = M_id });
            }
        }
        
    }
}
