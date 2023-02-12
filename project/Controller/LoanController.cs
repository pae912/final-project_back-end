using project.Dtos;
using project.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace project.Controller
{
    [EnableCors("AllowAny")]
    [ApiController]
    [Route("[controller]")]

    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly ILoanRepository _loanRepo;
        public LoanController(ILogger<LoanController> logger, ILoanRepository
        loanRepo)
        {
            _logger = logger;
            _loanRepo = loanRepo;
        }
        [EnableCors("AllowAny")]
        [HttpGet]
        public async Task<IActionResult> GetLoan()
        {
            try
            {
                var loan = await _loanRepo.GetLoan();
                return Ok(new
                {
                    Success = true,
                    Message = "all loan returned.",
                    loan
                });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        // [HttpGet]
        // [Route("{id}")]
        [HttpGet("{L_id}", Name = "LoanById")]
        public async Task<IActionResult> GetLoan(int L_id)
        {
            try
            {
                var loan = await _loanRepo.GetLoan(L_id);
                if (loan == null)
                    return NotFound();
                return Ok(new
                {
                    Success = true,
                    Message = "Company fetched.",
                    loan
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpPost]
        public async Task<IActionResult> CreateLoan(LoanForCreationDto loan)
        {
            try
            {
                var createdLoan = await _loanRepo.CreateLoan(loan);
                return Ok(new
                {
                    Success = true,
                    Message = "loan created.",
                    createdLoan
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpPatch]
        [Route("{L_id}")]
        public async Task<IActionResult> UpdateLoan(int L_id, LoanForUpdateDto loan)
        {
            try
            {
                var dbLoan = await _loanRepo.GetLoan(L_id);
                if (dbLoan == null)
                    return NotFound();
                await _loanRepo.UpdateLoan(L_id, loan);
                return Ok(new
                {
                    Success = true,
                    Message = "Loan updated."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpDelete]
        [Route("{L_id}")]
        public async Task<IActionResult> DeleteLoan(int L_id)
        {
            try
            {
                var dbLoan = await _loanRepo.GetLoan(L_id);
                if (dbLoan == null)
                    return NotFound();
                await _loanRepo.DeleteLoan(L_id);
                return Ok(new
                {
                    Success = true,
                    Message = "Loan deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
