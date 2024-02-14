using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentTariffsBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; set; }
        [Inject]
        public required IConnectedTariffService TariffService { get; set; }
        protected List<ConnectedTariffDto>? connectedTariffs  = new List<ConnectedTariffDto>();

        protected override async Task OnInitializedAsync()
        {
            connectedTariffs = await TariffService.GetConnectedTariffsListByAbonent(AbonId);
        }
    }
}
