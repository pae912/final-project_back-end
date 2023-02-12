using project.Dtos;
using project.Models;

namespace project.Contracts
{
    public interface ILoanRepository
    {
        // 查詢所有 Loan 資料
        public Task<IEnumerable<Loan>> GetLoan();
        // 查詢指定 id 的單一 Loan 資料
        public Task<Loan> GetLoan(int id);
        // 新增 Loan 資料
        public Task<Loan> CreateLoan(LoanForCreationDto loan);
        //修改指定 id 的 Loan 資料
        public Task UpdateLoan(int id, LoanForUpdateDto loan);
        // 刪除指定 id 的 Loan 資料
        public Task DeleteLoan(int id);

    }
}
