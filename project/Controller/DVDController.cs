using project.Dtos;
using project.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace project.Controller
{
    [EnableCors("AllowAny")]
    [ApiController]
    [Route("[controller]")]

    public class DVDController : ControllerBase
    {
        private readonly ILogger<DVDController> _logger;
        private readonly IDVDRepository _DVDRepo;
        public DVDController(ILogger<DVDController> logger, IDVDRepository
        DVDRepo)
        {
            _logger = logger;
            _DVDRepo = DVDRepo;
        }
        [EnableCors("AllowAny")]
        [HttpGet]
        public async Task<IActionResult> GetDVDs()
        {
            try
            {
                var dvds = await _DVDRepo.GetDVDs();
                return Ok(new
                {
                    Success = true,
                    Message = "all DVDs returned.",
                    dvds
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
        [HttpGet("{D_id}", Name = "DVDById")]
        public async Task<IActionResult> GetDVD(int D_id)
        {
            try
            {
                var dvd = await _DVDRepo.GetDVD(D_id);
                if (dvd == null)
                    return NotFound();
                return Ok(new
                {
                    Success = true,
                    Message = "DVD fetched.",
                    dvd
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]

        [HttpPost]
        public async Task<IActionResult> CreateDVD(DVDForCreationDto DVD)
        {
            try
            {
                var createdDVD = await _DVDRepo.CreateDVD(DVD);
                return Ok(new
                {
                    Success = true,
                    Message = "DVD created.",
                    createdDVD
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]

        [HttpPatch]
        [Route("{D_id}")]
        public async Task<IActionResult> UpdateDVD(int D_id, DVDForUpdateDto DVD)
        {
            try
            {
                var dbDVD = await _DVDRepo.GetDVD(D_id);
                if (dbDVD == null)
                    return NotFound();
                await _DVDRepo.UpdateDVD(D_id, DVD);
                return Ok(new
                {
                    Success = true,
                    Message = "DVD updated."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]

        [HttpDelete]
        [Route("{D_id}")]
        public async Task<IActionResult> DeleteDVD(int D_id)
        {
            try
            {
                var dbDVD = await _DVDRepo.GetDVD(D_id);
                if (dbDVD == null)
                    return NotFound();
                await _DVDRepo.DeleteDVD(D_id);
                return Ok(new
                {
                    Success = true,
                    Message = "DVD deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

