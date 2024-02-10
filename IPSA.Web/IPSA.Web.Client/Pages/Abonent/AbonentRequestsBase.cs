using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages.Abonent
{
    public class AbonentRequestsBase : ComponentBase
    {
        [Parameter]
        public int abon_id { get; set; }
    }
}
