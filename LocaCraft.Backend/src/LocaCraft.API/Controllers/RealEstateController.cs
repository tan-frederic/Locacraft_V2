using LocaCraft.API.Entities;
using LocaCraft.Application.Dtos.RealEstates;
using LocaCraft.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LocaCraft.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var realEstates = await _realEstateService.GetAllAsync();
            return Ok(realEstates);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
                return await GetAll();
            var whereExpression = (Expression<Func<RealEstate, bool>>)(re => re.Name.Contains(query) || re.Address.Contains(query));
            var realEstates = await _realEstateService.GetAllAsync(whereExpression);
            return Ok(realEstates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var realEstate = await _realEstateService.GetById(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            return Ok(realEstate);
        }

        [HttpPost]
        public async Task<ActionResult<RealEstateResponseDto>> CreateRealEstate(CreateRealEstateDto dto)
        {
            var realEstate = RealEstateDtoMapper.ToEntity(dto);
            await _realEstateService.CreateRealEstate(realEstate);
            await _realEstateService.SaveAsync();
            var response = RealEstateDtoMapper.ToResponseDto(realEstate);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RealEstateResponseDto>> UpdateRealEstate(int id, UpdateRealEstateDto dto)
        {
            var realEstate = await _realEstateService.GetById(id);
            if (realEstate == null)
                return NotFound();
            RealEstateDtoMapper.ApplyUpdate(dto, realEstate);
            await _realEstateService.SaveAsync();
            return Ok(RealEstateDtoMapper.ToResponseDto(realEstate));
        }
    }
}
