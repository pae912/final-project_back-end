using project.Dtos;
using project.Models;

namespace project.Contracts
{
    public interface IMemberRepository
    {
        // 查詢所有 Employee 資料
        public Task<IEnumerable<Members>> GetMembers();
        // 查詢指定 id 的單一 Employee 資料
        public Task<Members> GetMember(Guid id);
        // 新增 Employee 資料
        public Task<Members> CreateMember(MemberForCreationDto member);
        // 修改指定 id 的 Employee 資料
        public Task UpdateMember(Guid id, MemberForUpdateDto member);
        // 刪除指定 id 的 Employee 資料
        public Task DeleteMember(Guid id);
    }
}
