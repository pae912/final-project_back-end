using Dapper;
using System.Data;
using project.Dtos;
using project.Models;
using project.Contracts;
using Microsoft.Data.SqlClient;



namespace project.Repositories
{
    public class DVDRepository : IDVDRepository
    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task<IEnumerable<DVD>> GetDVDs()
        {
            string sqlQuery = "SELECT * FROM DVD";
            using (var connection = new SqlConnection(_connectString))
            {
                var DVDs = await connection.QueryAsync<DVD>(sqlQuery);
                return DVDs.ToList();
            }
        }
        public async Task<DVD> GetDVD(int D_id)
        {
            string sqlQuery = "SELECT * FROM DVD WHERE D_id = @id";
            using (var connection = new SqlConnection(_connectString))
            {
                var dvd = await connection.QuerySingleOrDefaultAsync<DVD>(sqlQuery, new { Id = D_id });
                return dvd;
            }
        }
        public async Task<DVD> CreateDVD(DVDForCreationDto DVD)
        {
            string sqlQuery = "INSERT INTO DVD (D_id, D_no, D_name, C_id, D_introduction, ) VALUES(@Id, @No, @Name, @C_id)";
            var parameters = new DynamicParameters();
            parameters.Add("Id", DVD.D_id, DbType.Int32);
            parameters.Add("No", DVD.D_no, DbType.String);
            parameters.Add("Name", DVD.D_name, DbType.String);
            parameters.Add("C_id", DVD.C_id, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
                var createdDVD = new DVD
                {
                    D_id = DVD.D_id,
                    D_no = DVD.D_no,
                    D_name = DVD.D_name,
                    C_id = DVD.C_id,
                    D_introduction = DVD.D_introduction
                };
                return createdDVD;

            }
        }
        public async Task UpdateDVD(int D_id, DVDForUpdateDto DVD)
        {
            var query = "UPDATE DVD SET D_no = @No, D_name = @Name, C_id = @C_id WHERE D_id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", DVD.D_id, DbType.Int32);
            parameters.Add("No", DVD.D_no, DbType.String);
            parameters.Add("Name", DVD.D_name, DbType.String);
            parameters.Add("C_id", DVD.C_id, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteDVD(int D_id)
        {
            var query = "DELETE FROM DVD WHERE D_id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, new { Id = D_id });
            }
        }

    }
}

