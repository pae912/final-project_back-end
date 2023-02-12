using Dapper;
using System.Data;
using project.Dtos;
using project.Models;
using project.Contracts;
using Microsoft.Data.SqlClient;

namespace project.Repositories
{
    public class LoanRepository : ILoanRepository

    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task<IEnumerable<Loan>> GetLoan()
        {
            string sqlQuery = "SELECT * FROM Loan";
            using (var connection = new SqlConnection(_connectString))
            {
                var loan = await connection.QueryAsync<Loan>(sqlQuery);
                return loan.ToList();
            }
        }
        public async Task<Loan> GetLoan(int L_id)
        {
            string sqlQuery = "SELECT * FROM Loan WHERE Loan_no = @id";
            using (var connection = new SqlConnection(_connectString))
            {
                var loan = await connection.QuerySingleOrDefaultAsync<Loan>(sqlQuery, new { Id = L_id });
                return loan;
            }
        }
        public async Task<Loan> CreateLoan(LoanForCreationDto loan)
        {
            string sqlQuery = "INSERT INTO Loan (Loan_no, D_id, Brrow_date, BrrowM_id, Return_limit) VALUES(@Id, @D_id, @Date, @M_id, @R_limit)";
            var parameters = new DynamicParameters();
            parameters.Add("Id", loan.Loan_no, DbType.Int32);
            parameters.Add("D_id", loan.D_id, DbType.String);
            parameters.Add("Date", loan.Brrow_date, DbType.String);
            parameters.Add("M_id", loan.BrrowM_id, DbType.Guid);
            parameters.Add("R_limit", loan.Return_limit, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
                var createdLoan = new Loan
                {
                    Loan_no = loan.Loan_no,
                    D_id = loan.D_id,
                    Brrow_date = loan.Brrow_date,
                    BrrowM_id = loan.BrrowM_id,
                    Return_limit = loan.Return_limit
                };
                return createdLoan;

            }
        }
        public async Task UpdateLoan(int L_id, LoanForUpdateDto loan)
        {
            var query = "UPDATE Loan SET D_id = @D_id, Brrow_date = @date, BrrowM_id = @M_id ,Return_limit = @return WHERE Loan_no = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", loan.Loan_no, DbType.Int32);
            parameters.Add("D_id", loan.D_id, DbType.Int32);
            parameters.Add("date", loan.Brrow_date, DbType.String);
            parameters.Add("M_id", loan.BrrowM_id, DbType.Guid);
            parameters.Add("return", loan.Return_limit, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteLoan(int L_id)
        {
            var query = "DELETE FROM Loan WHERE Loan_no = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, new { Id = L_id });
            }
        }


    }
}
