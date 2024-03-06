using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class CreateRequestBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; set; }
        [Inject]
        public required IAbonentRequestService RequestService { get; set; }
        [Inject]
        public required NavigationManager NavManager { get; set; }

        protected List<AbonentRequestDto>? dayRequests = new();
        protected AbonentRequestDto abonentRequest = new();
        protected DateDto? selectedDate = new();
        protected override async Task OnInitializedAsync()
        {
            selectedDate!.DateWithTime = DateTime.UtcNow.AddDays(1);
            selectedDate!.DateOnly = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1));

            abonentRequest!.AbonentId = AbonId;
            abonentRequest!.EmployeeId = 1;
            abonentRequest!.CompletionDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1));
            abonentRequest!.CompletionTimePeriod = "10:00 - 12:00";
            abonentRequest!.Type = "Подключение СПД";
            abonentRequest!.Status = "Открыта";
            abonentRequest!.AllocatedEngineer = "";

            dayRequests = await RequestService.GetAbonentRequestsByDate(selectedDate);
        }

        protected async Task SaveNewRequest()
        {
            await RequestService.CreateAbonentRequest(abonentRequest);
            NavManager.NavigateTo($"/Abonent/{AbonId}/Requests/");
        }

        protected async Task RefreshRequestsList()
        {
            selectedDate!.DateOnly = abonentRequest.CompletionDate;
            dayRequests = await RequestService.GetAbonentRequestsByDate(selectedDate);
        }
    }
}
