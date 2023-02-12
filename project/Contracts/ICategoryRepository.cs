using project.Dtos;
using project.Models;

namespace project.Contracts
{
    public interface ICategoryRepository
    {
        // 查詢所有 Categories 資料
        public Task<IEnumerable<Category>> GetCategories();
        // 查詢指定 id 的單一 Category 資料
        public Task<Category> GetCategory(int id);
        // 新增 Category 資料
        public Task<Category> CreateCategory(CategoryForCreationDto category);
        // 修改指定 id 的 Category 資料
        public Task UpdateCategory(int id, CategoryForUpdateDto category);
        // 刪除指定 id 的 Category 資料
        public Task DeleteCategory(int id);
    }
}
