using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentTariffsBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; init; }
        [Inject]
        public required IConnectedTariffService ConnectedTariffService { get; init; }
        [Inject]
        public required ITariffService TariffService { get; init; }
        [Inject]
        public required NavigationManager navManager { get; init; }

        protected List<ConnectedTariffDto>? connectedTariffs  = new List<ConnectedTariffDto>();
        protected List<TariffDto>? tariffsList = new List<TariffDto>();
        protected TariffDto? selectedTariff = new();

        protected override async Task OnInitializedAsync()
        {
            connectedTariffs = await ConnectedTariffService.GetConnectedTariffsListByAbonent(AbonId);
            tariffsList = await TariffService.GetTariffsList();
            selectedTariff = tariffsList.FirstOrDefault();
            newTariffPopup = false;
        }

        protected bool newTariffPopup { get; set; }
        protected void ShowNewTariffPopup()
        {
            newTariffPopup = true;
        }
        protected void CloseNewTariffPopup()
        {
            newTariffPopup = false;
        }

        protected void ChangeSelectedTariff()
        {
            selectedTariff = tariffsList!.FirstOrDefault(x => x.Name == newConnTariff.Name);
            newConnTariff.PricingModel = selectedTariff!.PricingModel;
            newConnTariff.MonthlyPrice = selectedTariff!.MonthlyPrice;
            newConnTariff.DailyPrice = selectedTariff!.DailyPrice;
        }

        protected void ReloadPage()
        {
            navManager.NavigateTo($"/Abonent/{AbonId}/Tariffs/", true);
        }

        protected ConnectedTariffDto newConnTariff = new();
        protected async void ConnectNewTariff()
        {
            newConnTariff.AbonentId = AbonId;
            newConnTariff.TariffId = selectedTariff!.Id;
            newConnTariff.IpAddress = "127.0.0.1";
            newConnTariff.LinkToHardware = "(ссылка на мост к сетевому оборудованию)";
            newConnTariff.IsBlocked = false;
            await ConnectedTariffService.AddNewConnectedTariff(newConnTariff);
            ReloadPage();
        }

        protected async void BlockAllAbonentConnTariffs()
        {
            await ConnectedTariffService.BlockAllAbonentConnectedTariffs(AbonId);
            ReloadPage();
        }

        protected async void BlockConnectedTariff(int connectedTariffId)
        {
            await ConnectedTariffService.BlockConnectedTariff(connectedTariffId);
            ReloadPage();
        }

        protected async void UnblockConnectedTariff(int connectedTariffId)
        {
            await ConnectedTariffService.UnblockConnectedTariff(connectedTariffId);
            ReloadPage();
        }
    }
}
