using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class CitiesController(ICityRepository cityRepository, IMapper mapper) : ControllerBase
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<CityReadDto>>> GetAllCitiesList()
        {
            try
            {
                var cities = _cityRepository.GetCitiesList();

                if (cities is null)
                {
                    return NotFound("Список городов пуст");
                }
                else
                {
                    var result = _mapper.Map<List<CityReadDto>>(cities);
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
