using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class StreetsController(IStreetRepository streetRepository, IMapper mapper) : ControllerBase
    {
        private readonly IStreetRepository _streetRepository = streetRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<StreetReadDto>>> GetAllStreetsList()
        {
            try
            {
                var streets = _streetRepository.GetAllStreetsList();

                if (streets is null)
                {
                    return NotFound("Список улиц пуст");
                }
                else
                {
                    var result = _mapper.Map<List<StreetReadDto>>(streets);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpGet("ByCity/{id:int}")]
        public async Task<ActionResult<List<StreetReadDto>>> GetStreetsListByCity(int id)
        {
            try
            {
                var streets = _streetRepository.GetStreetsListByCity(id);

                if (streets is null)
                {
                    return BadRequest();
                }
                else
                {
                    var result = _mapper.Map<List<StreetReadDto>>(streets);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }
    }
}
