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

        protected override async Task OnInitializedAsync()
        {
            datePeriod.StartDate = new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year, DateOnly.FromDateTime(DateTime.Now).Month, 1);
            datePeriod.EndDate = datePeriod.StartDate.AddMonths(1);
            abonRequests = await RequestService.GetAbonentRequestsByDatePeriod(datePeriod);
        }

        protected async Task RefreshRequestsList()
        {
            abonRequests = await RequestService.GetAbonentRequestsByDatePeriod(datePeriod);
        }

        protected void EditRequest(int abonentId, int requestId)
        {
            NavManager.NavigateTo($"/Abonent/{abonentId}/EditRequest/{requestId}");
        }
    }
}
