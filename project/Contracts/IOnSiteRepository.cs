using project.Dtos;
using project.Models;

namespace project.Contracts
{
    public interface IOnSiteRepository
    {
        // 查詢所有 OnSite 資料
        public Task<IEnumerable<OnSite>> GetOnSite();
        // 查詢指定 no 的單一 OnSite 資料
        public Task<OnSite> GetOnSite(int On_no);
        //新增 OnSite 資料
        public Task<OnSite> CreateOnSite(OnSiteForCreationDto OnSite);
        // 修改指定 no 的 OnSite 資料
        public Task UpdateOnSite(int On_no, OnSiteForUpdateDto OnSite);
        // 刪除指定 no 的 OnSite 資料
        public Task DeleteOnSite(int On_no);
    }
}
