using IPSA.Shared.Dtos;
using IPSA.Shared.Contracts;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages
{
    public class AbonentEditBase : ComponentBase
    {
        [Parameter]
        public int AbonId { get; set; }
        [Inject]
        public required IAbonentService AbonentService { get; set; }
        [Inject]
        public required ICityService CityService { get; set; }
        [Inject]
        public required IStreetService StreetService { get; set; }
        [Inject]
        public required NavigationManager NavManager { get; set; }

        protected AbonentCreateDto abonentToUpdate = new AbonentCreateDto();

        protected List<CityReadDto>? citiesList = new List<CityReadDto>();
        protected List<StreetReadDto>? streetsList = new List<StreetReadDto>();

        protected override async Task OnInitializedAsync()
        {
            abonentToUpdate = await AbonentService.GetAbonentForEdit(AbonId);

            citiesList = await CityService.GetCitiesList();
            citiesList = citiesList.OrderBy(x => x.Name).ToList();

            int selectedCityId = citiesList!.FirstOrDefault(x => x.Name == abonentToUpdate.City)!.Id;
            streetsList = await StreetService.GetStreetsListByCity(selectedCityId);
            streetsList = streetsList.OrderBy(x => x.Name).ToList();

        }

        protected async Task RefreshStreetsListOnCityChange()
        {
            int selectedCityId = citiesList!.FirstOrDefault(x => x.Name == abonentToUpdate.City)!.Id;
            streetsList = await StreetService.GetStreetsListByCity(selectedCityId);
            streetsList = streetsList.OrderBy(x => x.Name).ToList();
        }

        protected async Task SaveChangesToAbonent()
        {
            await AbonentService.UpdateAbonent(AbonId, abonentToUpdate);

            NavManager.NavigateTo($"/Abonent/{AbonId}/Info/");
        }
    }
}
