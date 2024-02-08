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
        public int max_results = 20;

        protected override async Task OnInitializedAsync()
        {
            citiesList = await CityService.GetCitiesList();
            citiesList = citiesList.OrderBy(x => x.Name).ToList();
            abonentsList = await AbonentService.GetAllAbonents();
            abonentsList.Take(max_results);
        }

        //protected void Search(SearchAbonentFilter filter, int max_result_count)
        //{
        //    if (selectedCity != "Все доступные")
        //    {
        //        filter.City = selectedCity;
        //    }
        //    else
        //    {
        //        filter.City = null;
        //    }

        //    if (max_result_count < 0) max_result_count = 0;

        //    if (filter == null)
        //    {
        //        abonHandler.GetAbonents().OrderBy(x => x.abon_id);
        //    }
        //    else
        //    {
        //        abonList = abonHandler.SearchAbonents(filter).OrderBy(x => x.abon_id);
        //        if (max_result_count > 0)
        //        {
        //            abonList = abonList.Take(max_result_count);
        //        }
        //    }
        //}



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
            max_results = 20;
        }

        protected void GoToAbonPage(int abon_id)
        {
            navManager.NavigateTo($"/Abonent/{abon_id}/Info");
        }
    }
}
