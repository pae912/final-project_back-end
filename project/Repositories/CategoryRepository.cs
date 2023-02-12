using Dapper;
using System.Data;
using project.Dtos;
using project.Models;
using project.Contracts;
using Microsoft.Data.SqlClient;

namespace project.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task<IEnumerable<Category>> GetCategories()
        {
            string sqlQuery = "SELECT * FROM Category";
            using (var connection = new SqlConnection(_connectString))
            {
                var companies = await connection.QueryAsync<Category>(sqlQuery);
                return companies.ToList();
            }
        }
        public async Task<Category> GetCategory(int C_id)
        {
            string sqlQuery = "SELECT * FROM Category WHERE C_id = @id";
            using (var connection = new SqlConnection(_connectString))
            {
                var category = await connection.QuerySingleOrDefaultAsync<Category>(sqlQuery, new { Id = C_id });
                return category;
            }
        }
        public async Task<Category> CreateCategory(CategoryForCreationDto Category)
        {
            string sqlQuery = "INSERT INTO Category (C_id, C_name) VALUES(@Id, @Name)";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Category.C_id, DbType.String);
            parameters.Add("Name", Category.C_name, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
                var createdCategory = new Category
                {
                    C_id = Category.C_id,
                    C_name = Category.C_name,
                   
                };
                return createdCategory;

            }
        }
        public async Task UpdateCategory(int C_id, CategoryForUpdateDto category)
        {
            var query = "UPDATE Category SET C_name = @Name WHERE C_id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", category.C_id, DbType.String);
            parameters.Add("Name", category.C_name, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteCategory(int C_id)
        {
            var query = "DELETE FROM Category WHERE C_id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, new { Id = C_id });
            }
        }
    }
}
