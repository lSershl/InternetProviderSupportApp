using AutoMapper;
using IPSA.Shared.Dtos;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class AbonentsController(IAbonentRepository abonentRepository, IMapper mapper) : ControllerBase
    {
        private readonly IAbonentRepository _abonentRepository = abonentRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbonentReadDto>>> GetAllAbonents()
        {
            try
            {
                var abonents = _abonentRepository.GetAllAbonents();

                if (abonents is null)
                {
                    return NotFound();
                }
                else
                {
                    var result = _mapper.Map<AbonentReadDto>(abonents);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AbonentReadDto>> GetAbonent(int id)
        {
            try
            {
                var abonent = _abonentRepository.GetAbonent(id);

                if (abonent == null)
                {
                    return BadRequest();
                }
                else
                {
                    var result = _mapper.Map<AbonentReadDto>(abonent);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPut("Search")]
        public async Task<ActionResult<IEnumerable<AbonentReadDto>>> SearchAbonentsByFilter(SearchAbonentFilter filter)
        {
            try
            {
                var abonents = _abonentRepository.GetAbonentsByFilter(filter);

                if (abonents is null)
                {
                    return NoContent();
                }
                else
                {
                    var result = _mapper.Map<IEnumerable<AbonentReadDto>>(abonents);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPost("NewAbonent")]
        public async Task<ActionResult<ServiceResponse>> AddNewAbonent(AbonentCreateDto abonentCreateDto)
        {
            try
            {
                if (abonentCreateDto is null)
                {
                    return BadRequest("Ошибка. Бланк абонента не содержит данных.");
                }

                var newAbonent = _mapper.Map<Abonent>(abonentCreateDto);
                await _abonentRepository.AddNewAbonent(newAbonent);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении нового абонента в базу");
            }
        }

        [HttpPatch("UpdateAbonent/{abonId}")]
        public async Task<ActionResult> UpdateAbonent(int abonId, AbonentCreateDto updatedAbonent)
        {
            try
            {
                if (updatedAbonent == null)
                {
                    return BadRequest();
                }
                else
                {
                    var currAbonent = _abonentRepository.GetAbonent(abonId);
                    if (currAbonent is not null)
                    {
                        currAbonent.FirstName = updatedAbonent.FirstName!;
                        currAbonent.LastName = updatedAbonent.LastName!;
                        currAbonent.Surname = updatedAbonent.Surname!;
                        currAbonent.DateOfBirth = updatedAbonent.DateOfBirth;
                        currAbonent.BirthPlace = updatedAbonent.BirthPlace!;
                        currAbonent.PhoneNumber = updatedAbonent.PhoneNumber!;
                        currAbonent.PhoneNumberForSending = updatedAbonent.PhoneNumberForSending!;
                        currAbonent.Email = updatedAbonent.Email;
                        currAbonent.PassportSeries = updatedAbonent.PassportSeries!;
                        currAbonent.PassportNumber = updatedAbonent.PassportNumber!;
                        currAbonent.PassportRegistration = updatedAbonent.PassportRegistration!;
                        currAbonent.PassportRegDate = updatedAbonent.PassportRegDate;
                        currAbonent.RegistrationAddress = updatedAbonent.RegistrationAddress!;
                        currAbonent.RegistrationZipCode = updatedAbonent.RegistrationZipCode!;
                        currAbonent.City = updatedAbonent.City!;
                        currAbonent.Street = updatedAbonent.Street!;
                        currAbonent.House = updatedAbonent.House!;
                        currAbonent.Apartment = updatedAbonent.Apartment!;
                        currAbonent.HouseEntranceNumber = updatedAbonent.HouseEntranceNumber!;
                        currAbonent.HouseFloorNumber = updatedAbonent.HouseFloorNumber!;
                        currAbonent.AddressZipCode = updatedAbonent.AddressZipCode;
                        currAbonent.SecretPhrase = updatedAbonent.SecretPhrase;
                        currAbonent.SMSSending = updatedAbonent.SMSSending;

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

        [HttpPut("ApplyPayment")]
        public async Task<ActionResult> ApplyPaymentToAbonentBalance(PaymentDto paymentDto)
        {
            try
            {
                if (paymentDto is null)
                {
                    return BadRequest("Ошибка. Платёж не содержит данных.");
                }

                var abonToUpdate = _abonentRepository.GetAbonent(paymentDto.AbonentId);
                if (abonToUpdate is not null)
                {
                    abonToUpdate.Balance = abonToUpdate.Balance + paymentDto.Amount;
                }

                await _abonentRepository.UpdateAbonent(abonToUpdate);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении нового абонента в базу");
            }
        }
    }
}
