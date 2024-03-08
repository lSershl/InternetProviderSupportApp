using IPSA.Shared.Dtos;
using IPSA.Shared.Contracts;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages
{
    public class AbonentsBase : ComponentBase
    {
        [Inject]
        public required IAbonentService AbonentService { get; set; }
        [Inject]
        public required ICityService CityService { get; set; }
        [Inject]
        public required IStreetService StreetService { get; set; }
        [Inject]
        public required NavigationManager navManager { get; set; }

        public IEnumerable<AbonentReadDto>? abonentsList;
        public List<CityReadDto>? citiesList = new List<CityReadDto>();
        public SearchAbonentFilter? filter = new SearchAbonentFilter();
        protected const string selectAllCities = "Все доступные";
        protected string selectedCity = selectAllCities;
        public int maxResults = 20;

        protected override async Task OnInitializedAsync()
        {
            citiesList = await CityService.GetCitiesList();
            citiesList = citiesList.OrderBy(x => x.Name).ToList();
            abonentsList = await AbonentService.GetAllAbonents();
            abonentsList.Take(maxResults);
        }

        protected async Task Search(SearchAbonentFilter filter, int maxResults)
        {
            if (selectedCity != "Все доступные")
            {
                filter.City = selectedCity;
            }
            else
            {
                filter.City = null;
            }

            if (maxResults < 0) maxResults = 0;

            if (filter is null)
            {
                abonentsList = await AbonentService.GetAllAbonents();
                abonentsList.Take(maxResults);
            }
            else
            {
                abonentsList = await AbonentService.GetAbonentsByFilter(filter);
                abonentsList = abonentsList.OrderBy(x => x.Id);
                if (maxResults > 0)
                {
                    abonentsList = abonentsList.Take(maxResults);
                }
            }
        }

        protected void ClearFilter()
        {
            filter!.AbonentId = null;
            filter.FirstName = null;
            filter.LastName = null;
            filter.Surname = null;
            filter.PhoneNumber = null;
            filter.City = null;
            filter.Street = null;
            filter.House = null;
            filter.Apartment = null;
            selectedCity = "Все доступные";
            maxResults = 20;
        }

        protected void GoToAbonPage(int abon_id)
        {
            navManager.NavigateTo($"/Abonent/{abon_id}/Info");
        }
    }
}
