using project.Dtos;
using project.Models;

namespace project.Contracts
{
    public interface IDVDRepository
    {
        // 查詢所有 DVDs 資料
        public Task<IEnumerable<DVD>> GetDVDs();
        // 查詢指定 id 的單一 DVD 資料
        public Task<DVD> GetDVD(int id);
        //新增 DVD 資料
        public Task<DVD> CreateDVD(DVDForCreationDto DVD);
        // 修改指定 id 的 DVD 資料
        public Task UpdateDVD(int id, DVDForUpdateDto DVD);
        // 刪除指定 id 的 DVD 資料
        public Task DeleteDVD(int id);
    }
}
