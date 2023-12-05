using IPSA.API.Repositories;
using IPSA.Models;
using Microsoft.AspNetCore.Mvc;


namespace IPSA.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class AbonentsController : ControllerBase
    {
        private readonly AbonentRepository _abonentRepository;

        public AbonentsController(AbonentRepository abonentRepository)
        {
            _abonentRepository = abonentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonent>>> GetAllAbonents()
        {
            try
            {
                var abonents = await _abonentRepository.GetAllAbonents();

                if (abonents is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(abonents);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Abonent>> GetItem(int id)
        {
            try
            {
                var abonent = await _abonentRepository.GetAbonent(id);

                if (abonent == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(abonent);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }
    }
}
