using LocaCraft.Application.Dtos.Leases;
using LocaCraft.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocaCraft.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaseController : ControllerBase
    {
        private readonly ILeaseService _leaseService;

        public LeaseController(ILeaseService leaseService)
        {
            _leaseService = leaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            var leases = await _leaseService.GetAllAsync();
            return Ok(leases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lease = await _leaseService.GetById(id);
            if (lease == null)
                return NotFound();
            return Ok(lease);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
                return await GetAll();
            var leases = await _leaseService.GetAllAsync(l => l.Name.Contains(query));
            return Ok(leases);
        }

        [HttpGet("realestate/{realEstateId}")]
        public async Task<IActionResult> GetByRealEstateId(int realEstateId)
        {
            var leases = await _leaseService.GetAllAsync(l => l.RealEstateId == realEstateId);
            return Ok(leases);
        }

        [HttpPost]
        public async Task<ActionResult<LeaseResponseDto>> CreateLease(CreateLeaseDto dto)
        {
            var lease = LeaseMapper.ToEntity(dto);
            await _leaseService.CreateLease(lease);
            await _leaseService.SaveAsync();
            var response = LeaseMapper.ToResponseDto(lease);
            return (response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeaseResponseDto>> UpdateLease(int id, UpdateLeaseDto dto)
        {
            var lease = await _leaseService.GetById(id);
            if (lease == null)
                return NotFound();
            LeaseMapper.ApplyUpdate(dto, lease);
            await _leaseService.SaveAsync();
            return Ok(LeaseMapper.ToResponseDto(lease));
        }
    }
}
