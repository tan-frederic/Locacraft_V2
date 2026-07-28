using LocaCraft.API.Entities;
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
            var whereExpression = string.IsNullOrEmpty(query) ? null : (Expression<Func<RealEstate, bool>>)(re => re.Name.Contains(query) || re.Address.Contains(query));
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
    }
}
