using Dapper;
using System.Data;
using project.Dtos;
using project.Models;
using project.Contracts;
using Microsoft.Data.SqlClient;

namespace project.Repositories
{
    public class OnSiteRepository : IOnSiteRepository
    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task<IEnumerable<OnSite>> GetOnSite()
        {
            string sqlQuery = "SELECT * FROM OnSite";
            using (var connection = new SqlConnection(_connectString))
            {
                var OnSite = await connection.QueryAsync<OnSite>(sqlQuery);
                return OnSite.ToList();
            }
        }
        public async Task<OnSite> GetOnSite(int On_no)
        {
            string sqlQuery = "SELECT * FROM OnSite WHERE On_no = @No";
            using (var connection = new SqlConnection(_connectString))
            {
                var onsite = await connection.QuerySingleOrDefaultAsync<OnSite>(sqlQuery, new { No = On_no });
                return onsite;
            }
        }
        public async Task<OnSite> CreateOnSite(OnSiteForCreationDto OnSite)
        {
            string sqlQuery = "INSERT INTO OnSite (On_no, D_id, BrrowM_id, S_id, Brrow_date, Return_date) VALUES(@No, @Id, @Brrow, @Space, @Bdate, @Rdate)";
            var parameters = new DynamicParameters();
            parameters.Add("No", OnSite.On_no, DbType.Int32);
            parameters.Add("Id", OnSite.D_id, DbType.String);
            parameters.Add("Brrow", OnSite.BrrowM_id, DbType.Guid);
            parameters.Add("Space", OnSite.S_id, DbType.String);
            parameters.Add("Bdate", OnSite.Brrow_date, DbType.Date);
            parameters.Add("Rdate", OnSite.Return_date, DbType.Date);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
                var createdOnSite = new OnSite
                {
                    On_no = OnSite.On_no,
                    D_id = OnSite.D_id,
                    BrrowM_id = OnSite.BrrowM_id,
                    S_id = OnSite.S_id,
                    Brrow_date = OnSite.Brrow_date,
                    Return_date = OnSite.Return_date,
                };
                return createdOnSite;

            }
        }

        public async Task UpdateOnSite(int On_no, OnSiteForUpdateDto onsite)
        {
            var query = "UPDATE OnSite SET D_id = @Id, BrrowM_id = @Brrow, S_id = @Space, Brrow_date = @Bdate, Return_date = @Rdate WHERE On_no = @No";
            var parameters = new DynamicParameters();
            parameters.Add("No", onsite.On_no, DbType.Int32);
            parameters.Add("Id", onsite.D_id, DbType.String);
            parameters.Add("Brrow", onsite.BrrowM_id, DbType.Guid);
            parameters.Add("Space", onsite.S_id, DbType.String);
            parameters.Add("Bdate", onsite.Brrow_date, DbType.Date);
            parameters.Add("Rdate", onsite.Return_date, DbType.Date);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteOnSite(int On_no)
        {
            var query = "DELETE FROM OnSite WHERE On_no = @No";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, new { No = On_no });
            }
        }
       

    }
}
