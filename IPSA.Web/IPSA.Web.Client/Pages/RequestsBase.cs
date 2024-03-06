using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages
{
    public class RequestsBase : ComponentBase
    {
        [Inject]
        public required IAbonentRequestService RequestService { get; set; }
        [Inject]
        public required NavigationManager NavManager { get; set; }

        protected DatePeriodDto datePeriod = new DatePeriodDto();
        protected List<AbonentRequestDto> abonRequests = new List<AbonentRequestDto>();
        protected string[] allocationTypes = ["Все", "Привязанные", "Непривязанные"];
        protected string selectedAllocationType = "Все";

        protected override async Task OnInitializedAsync()
        {
            datePeriod.StartDate = new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year, DateOnly.FromDateTime(DateTime.Now).Month, 1);
            datePeriod.EndDate = datePeriod.StartDate.AddMonths(1);
            await RefreshRequestsList();
        }

        protected async Task RefreshRequestsList()
        {
            switch (selectedAllocationType)
            {
                case "Все":
                    abonRequests = await RequestService.GetAbonentRequestsByDatePeriod(datePeriod);
                    break;
                case "Привязанные":
                    abonRequests = await RequestService.GetAbonentRequestsByDatePeriod(datePeriod);
                    abonRequests = abonRequests.Where(x => String.IsNullOrEmpty(x.AllocatedEngineer) is false).ToList();
                    break;
                case "Непривязанные":
                    abonRequests = await RequestService.GetAbonentRequestsByDatePeriod(datePeriod);
                    abonRequests = abonRequests.Where(x => String.IsNullOrEmpty(x.AllocatedEngineer) is true).ToList();
                    break;
                default: 
                    abonRequests = await RequestService.GetAbonentRequestsByDatePeriod(datePeriod);
                    break;
            }
        }

        protected void EditRequest(int abonentId, int requestId)
        {
            NavManager.NavigateTo($"/Abonent/{abonentId}/EditRequest/{requestId}");
        }
    }
}
