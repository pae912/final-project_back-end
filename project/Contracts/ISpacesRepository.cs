using project.Dtos;
using project.Models;

namespace project.Contracts
{
    public interface ISpacesRepository
    {
        // 查詢所有 Spaces 資料
        public Task<IEnumerable<Spaces>> GetSpaces();
        // 查詢指定 id 的單一 Spaces 資料
        public Task<Spaces> GetSpaces(string id);
        // 新增 Spaces 資料
        public Task<Spaces> CreateSpaces(SpacesForCreationDto spaces);
        // 修改指定 id 的 Spaces 資料
        public Task UpdateSpaces(string id, SpacesForUpdateDto spaces);
        // 刪除指定 id 的 Spaces 資料
        public Task DeleteSpaces(string id);
    }
}
