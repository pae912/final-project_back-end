using project.Dtos;
using project.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace project.Controller
{
    [EnableCors("AllowAny")]
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly IMemberRepository _memberRepo;
        public MembersController(ILogger<MembersController> logger, IMemberRepository
        memberRepo)
        {
            _logger = logger;
            _memberRepo = memberRepo;
        }
        [EnableCors("AllowAny")]
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                var members = await _memberRepo.GetMembers();
                return Ok(new
                {
                    Success = true,
                    Message = "all members returned.",
                    members
                });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpGet]
        [Route("{M_id}")]
        //[HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetMember(Guid M_id)
        {
            try
            {
                var member = await _memberRepo.GetMember(M_id);
                if (member == null)
                    return NotFound();
                return Ok(new
                {
                    Success = true,
                    Message = "Employee fetched.",
                    member
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberForCreationDto member)
        {
            try
            {
                var createdMember = await _memberRepo.CreateMember(member);
                return Ok(new
                {
                    Success = true,
                    Message = "Member created.",
                    createdMember
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpPatch]
        [Route("{M_id}")]
        public async Task<IActionResult> UpdateMember(Guid M_id, MemberForUpdateDto member)
        {
            try
            {
                var dbMember = await _memberRepo.GetMember(M_id);
                if (dbMember == null)
                    return NotFound();
                await _memberRepo.UpdateMember(M_id, member);
                return Ok(new
                {
                    Success = true,
                    Message = "Member updated."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpDelete]
        [Route("{M_id}")]
        public async Task<IActionResult> DeleteMember(Guid M_id)
        {
            try
            {
                var dbCompany = await _memberRepo.GetMember(M_id);
                if (dbCompany == null)
                    return NotFound();
                await _memberRepo.DeleteMember(M_id);
                return Ok(new
                {
                    Success = true,
                    Message = "Member deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
