using Dapper;
using System.Data;
using project.Dtos;
using project.Models;
using project.Contracts;
using Microsoft.Data.SqlClient;

namespace project.Repositories
{
    public class SpacesRepository : ISpacesRepository
    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task<IEnumerable<Spaces>> GetSpaces()
        {
            string sqlQuery = "SELECT * FROM Spaces";
            using (var connection = new SqlConnection(_connectString))
            {
                var space = await connection.QueryAsync<Spaces>(sqlQuery);
                return space.ToList();
            }
        }
        public async Task<Spaces> GetSpaces(string S_id)
        {
            string sqlQuery = "SELECT * FROM Spaces WHERE S_id = @id";
            using (var connection = new SqlConnection(_connectString))
            {
                var spaces = await connection.QuerySingleOrDefaultAsync<Spaces>(sqlQuery, new { Id = S_id });
                return spaces;
            }
        }
        public async Task<Spaces> CreateSpaces(SpacesForCreationDto Spaces)
        {
            string sqlQuery = "INSERT INTO Spaces (S_id, S_name, S_type) VALUES(@Id, @Name, @Type)";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Spaces.S_id, DbType.String);
            parameters.Add("Name", Spaces.S_name, DbType.String);
            parameters.Add("Type", Spaces.S_type, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
                var createdSpaces = new Spaces
                {
                    S_id = Spaces.S_id,
                    S_name = Spaces.S_name,
                    S_type = Spaces.S_type,

                };
                return createdSpaces;

            }
        }
        public async Task UpdateSpaces(string S_id, SpacesForUpdateDto spaces)
        {
            var query = "UPDATE Spaces SET S_name = @Name, S_type = @Type WHERE S_id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", spaces.S_id, DbType.String);
            parameters.Add("Name", spaces.S_name, DbType.String);
            parameters.Add("Type", spaces.S_type, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteSpaces(string S_id)
        {
            var query = "DELETE FROM Spaces WHERE S_id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, new { Id = S_id });
            }
        }
    }
}

