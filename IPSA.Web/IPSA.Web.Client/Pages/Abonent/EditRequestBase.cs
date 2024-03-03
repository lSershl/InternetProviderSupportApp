using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class EditRequestBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; set; }
        [Parameter]
        public int RequestId { get; set; }
        [CascadingParameter]
        protected Task<AuthenticationState>? authStateTask { get; set; }
        [Inject]
        public required IAbonentRequestService RequestService { get; set; }
        [Inject]
        public required NavigationManager NavManager { get; set; }

        protected List<AbonentRequestDto>? dayRequests = new();
        protected AbonentRequestDto abonentRequest = new();
        protected DateDto? selectedDate = new();
        protected string userId = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            selectedDate!.DateWithTime = DateTime.UtcNow;
            selectedDate!.DateOnly = DateOnly.FromDateTime(DateTime.UtcNow);

            if (authStateTask is not null)
            {
                var authState = await authStateTask;
                var user = authState.User;
                if (user.Identity!.IsAuthenticated)
                    userId = user.Claims.FirstOrDefault(x => x.Type.Contains("identifier"))!.Value;
            }

            abonentRequest = await RequestService.GetAbonentRequestById(RequestId);

            selectedDate.DateOnly = abonentRequest.CompletionDate;
            selectedDate.DateWithTime = selectedDate.DateOnly.ToDateTime(TimeOnly.MinValue);

            dayRequests = await RequestService.GetAbonentRequestsByDate(selectedDate);
        }

        protected async Task UpdateRequest()
        {
            abonentRequest!.EmployeeId = Int32.Parse(userId);
            await RequestService.UpdateAbonentRequest(abonentRequest);
            NavManager.NavigateTo($"/Abonent/{AbonId}/EditRequest/{RequestId}", forceLoad:true);
        }

        protected async Task RefreshRequestsList()
        {
            selectedDate!.DateOnly = abonentRequest.CompletionDate;
            dayRequests = await RequestService.GetAbonentRequestsByDate(selectedDate);
        }
    }
}
