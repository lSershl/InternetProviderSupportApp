using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentDocumentsBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; init; }
        [Inject]
        public required NavigationManager navManager { get; init; }
    }
}
