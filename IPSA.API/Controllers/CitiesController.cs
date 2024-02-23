using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class CitiesController(ICityRepository cityRepository) : ControllerBase
    {
        private readonly ICityRepository _cityRepository = cityRepository;

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCitiesList()
        {
            try
            {
                var cities = await _cityRepository.GetCitiesList();
                if (cities is null)
                {
                    return NotFound("Список городов пуст");
                }
                else
                {
                    return Ok(cities);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }
    }
}
