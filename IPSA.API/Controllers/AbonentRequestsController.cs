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
    public class AbonentRequestsController(IAbonentRequestRepository abonentRequestRepository, IMapper mapper) : ControllerBase
    {
        private readonly IAbonentRequestRepository _abonentRequestRepository = abonentRequestRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<AbonentRequest>>> GetAllAbonentsRequestsList()
        {
            try
            {
                var abonRequests = _abonentRequestRepository.GetAllAbonentsRequestsList();

                if (abonRequests is null)
                {
                    return NoContent();
                }

                return Ok(abonRequests);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPut("Date")]
        public async Task<ActionResult<List<AbonentRequest>>> GetRequestsListByDate(DateDto dateDto)
        {
            try
            {
                var abonRequests = _abonentRequestRepository.GetRequestsListByDate(dateDto.DateOnly);

                if (abonRequests is null)
                {
                    return NoContent();
                }

                return Ok(abonRequests);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPut("DatePeriod")]
        public async Task<ActionResult<List<AbonentRequest>>> GetRequestsListByDatePeriod(DatePeriodDto datePeriodDto)
        {
            try
            {
                var abonRequests = _abonentRequestRepository.GetRequestsListByDatePeriod(datePeriodDto.StartDate, datePeriodDto.EndDate);

                if (abonRequests is null)
                {
                    return NoContent();
                }

                return Ok(abonRequests);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpGet("Abonent/{abonId:int}")]
        public async Task<ActionResult<List<AbonentRequest>>> GetRequestsListByAbonent(int abonId)
        {
            try
            {
                var abonRequests = _abonentRequestRepository.GetRequestsListByAbonent(abonId);

                if (abonRequests is null)
                {
                    return NoContent();
                }

                return Ok(abonRequests);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpGet("Request/{requestId:int}")]
        public async Task<ActionResult<AbonentRequest>> GetRequestById(int requestId)
        {
            try
            {
                var request = _abonentRequestRepository.GetRequestById(requestId);

                if (request is null)
                {
                    return NoContent();
                }

                return Ok(request);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAbonentRequest(AbonentRequestDto abonentRequestDto)
        {
            try
            {
                if (abonentRequestDto is null)
                {
                    return BadRequest("Ошибка. Заявка не содержит данных.");
                }

                var newAbonentRequest = _mapper.Map<AbonentRequest>(abonentRequestDto);
                await _abonentRequestRepository.CreateAbonentRequest(newAbonentRequest);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении комментария в базу");
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateAbonentRequest(AbonentRequestDto updatedAbonentRequestDto)
        {
            try
            {
                if (updatedAbonentRequestDto is null)
                {
                    return BadRequest("Ошибка. Заявка не содержит данных.");
                }

                var currRequest = _abonentRequestRepository.GetRequestById(updatedAbonentRequestDto.Id);
                
                if (currRequest is not null)
                {
                    currRequest.EmployeeId = updatedAbonentRequestDto.EmployeeId;
                    currRequest.LastUpdateDateTime = updatedAbonentRequestDto.UpdateDateTime;
                    currRequest.CompletionDate = updatedAbonentRequestDto.CompletionDate;
                    currRequest.CompletionTimePeriod = updatedAbonentRequestDto.CompletionTimePeriod;
                    currRequest.Type = updatedAbonentRequestDto.Type;
                    currRequest.Description = updatedAbonentRequestDto.Description;
                    currRequest.Status = updatedAbonentRequestDto.Status;
                    currRequest.AllocatedEngineer = updatedAbonentRequestDto.AllocatedEngineer;

                    await _abonentRequestRepository.UpdateAbonentRequest(currRequest);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при обновлении заявки");
            }
        }
    }
}
