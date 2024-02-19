using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentRequestsBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; set; }
        [Inject]
        public required IAbonentRequestService RequestService { get; set; }
        [Inject]
        public required NavigationManager NavManager { get; set; }

        protected List<AbonentRequestDto> abonRequests = new List<AbonentRequestDto>();

        protected override async Task OnInitializedAsync()
        {
            abonRequests = await RequestService.GetAbonentRequests(AbonId);
        }

        protected void CreateRequest()
        {
            NavManager.NavigateTo($"/Abonent/{AbonId}/CreateRequest/");
        }
    }
}
