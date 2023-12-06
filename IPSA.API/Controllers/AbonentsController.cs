using AutoMapper;
using IPSA.API.Dtos;
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
        private readonly IMapper _mapper;

        public AbonentsController(AbonentRepository abonentRepository, IMapper mapper)
        {
            _abonentRepository = abonentRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<Abonent>> GetAbonent(int id)
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

        [HttpPost("NewAbonent")]
        public async Task<IActionResult> AddNewAbonent(AbonentCreateDto abonentCreateDto)
        {
            try
            {
                if (abonentCreateDto is null)
                {
                    return BadRequest();
                }

                var newAbonent = _mapper.Map<Abonent>(abonentCreateDto);
                _abonentRepository.AddNewAbonent(newAbonent);
                //return CreatedAtAction("AddNewAbonent", abonentCreateDto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении нового абонента в базу");
            }
        }

        [HttpPut("UpdateAbonent")]
        public async Task<ActionResult> UpdateAbonent(JsonContent content)
        {
            try
            {
                if (content == null)
                {
                    return BadRequest();
                }
                else
                {
                    var updAbonent = await content.ReadFromJsonAsync<Abonent>();
                    var currAbonent = await _abonentRepository.GetAbonent(updAbonent.Id);
                    if (currAbonent is not null)
                    {
                        currAbonent.FirstName = updAbonent.FirstName;
                        currAbonent.LastName = updAbonent.LastName;
                        currAbonent.Surname = updAbonent.Surname;
                        currAbonent.DateOfBirth = updAbonent.DateOfBirth;
                        currAbonent.BirthPlace = updAbonent.BirthPlace;
                        currAbonent.PhoneNumber = updAbonent.PhoneNumber;
                        currAbonent.PhoneNumberForSending = updAbonent.PhoneNumberForSending;
                        currAbonent.Email = updAbonent.Email;
                        currAbonent.PassportSeries = updAbonent.PassportSeries;
                        currAbonent.PassportNumber = updAbonent.PassportNumber;
                        currAbonent.PassportRegistration = updAbonent.PassportRegistration;
                        currAbonent.PassportRegDate = updAbonent.PassportRegDate;
                        currAbonent.RegistrationAddress = updAbonent.RegistrationAddress;
                        currAbonent.RegistrationZipCode = updAbonent.RegistrationZipCode;
                        currAbonent.City = updAbonent.City;
                        currAbonent.Street = updAbonent.Street;
                        currAbonent.House = updAbonent.House;
                        currAbonent.Apartment = updAbonent.Apartment;
                        currAbonent.HouseEntranceNumber = updAbonent.HouseEntranceNumber;
                        currAbonent.HouseFloorNumber = updAbonent.HouseFloorNumber;
                        currAbonent.AddressZipCode = updAbonent.AddressZipCode;
                        currAbonent.SecretPhrase = updAbonent.SecretPhrase;
                        currAbonent.SMSSending = updAbonent.SMSSending;

                        await _abonentRepository.UpdateAbonent(currAbonent);
                        return Ok();
                    }
                    else return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при обновлении абонента в базе");
            }
        }
    }
}
