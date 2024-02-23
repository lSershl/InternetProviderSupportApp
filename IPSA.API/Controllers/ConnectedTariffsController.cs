using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ConnectedTariffsController(IConnectedTariffsRepository connectedTariffsRepository, ITariffRepository tariffRepository) : ControllerBase
    {
        private readonly IConnectedTariffsRepository _connectedTariffsRepository = connectedTariffsRepository;
        private readonly ITariffRepository _tariffRepository = tariffRepository;

        [HttpGet("Abonent/{abonId:int}")]
        public async Task<ActionResult<List<ConnectedTariffDto>>> GetConnectedTariffsByAbonent(int abonId)
        {
            try
            {
                List<ConnectedTariffDto> resultingList = new();
                var abonConnTariffs = _connectedTariffsRepository.GetConnectedTariffsListByAbonent(abonId);

                if (abonConnTariffs is null)
                {
                    return NoContent();
                }
                else
                {
                    foreach (var connTariff in abonConnTariffs)
                    {
                        ConnectedTariffDto resultingListItem = new();
                        Tariff tariff = _tariffRepository.GetTariffById(connTariff.TariffId);

                        resultingListItem.Id = connTariff.Id;
                        resultingListItem.Name = tariff.Name;
                        resultingListItem.IpAddress = connTariff.IpAddress;
                        resultingListItem.LinkToHardware = connTariff.LinkToHardware;
                        resultingListItem.PricingModel = tariff.PricingModel;
                        resultingListItem.MonthlyPrice = tariff.MonthlyPrice;
                        resultingListItem.DailyPrice = tariff.DailyPrice;
                        resultingListItem.IsBlocked = connTariff.IsBlocked;

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
