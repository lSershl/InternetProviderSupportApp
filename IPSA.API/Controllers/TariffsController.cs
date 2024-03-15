using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class TariffsController(ITariffRepository tariffRepository) : ControllerBase
    {
        private readonly ITariffRepository _tariffRepository = tariffRepository;

        [HttpGet]
        public async Task<ActionResult<List<TariffDto>>> GetTariffsList()
        {
            try
            {
                List<TariffDto> resultingList = new();
                var tariffsList = _tariffRepository.GetTariffsList().Where(t => t.Archived is false);

                if (tariffsList is null)
                {
                    return NoContent();
                }
                else
                {
                    foreach (var tariff in tariffsList)
                    {
                        TariffDto resultingListItem = new();

                        resultingListItem.Id = tariff.Id;
                        resultingListItem.Name = tariff.Name;
                        resultingListItem.Type = tariff.Type;
                        resultingListItem.Description = tariff.Description;
                        resultingListItem.PricingModel = tariff.PricingModel;
                        resultingListItem.MonthlyPrice = tariff.MonthlyPrice;
                        resultingListItem.DailyPrice = tariff.DailyPrice;

                        resultingList.Add(resultingListItem);
                    }
                }

                return Ok(resultingList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }
    }
}
