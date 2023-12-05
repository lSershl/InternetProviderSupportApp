//using IPEA.Data;
//using IPEA.Handlers.Interfaces;
using IPSA.Models;
using IPSA.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web
{
    public class AbonentsBase : ComponentBase
    {
        //[Inject]
        //public IAbonentHandler abonHandler { get; set; }
        //[Inject]
        //public IAddressHandler? addressHandler { get; set; }
        [Inject]
        public required IAbonentService AbonentService { get; set; }
        [Inject]
        public required NavigationManager navManager { get; set; }

        public IEnumerable<Abonent>? abonList;
        //public List<City> citiesList;
        public SearchAbonentFilter? filter = new SearchAbonentFilter();
        public string selectedCity;
        public int max_result_count = 20;

        protected override async Task OnInitializedAsync()
        {
            abonList = await AbonentService.GetAllAbonents();
            //citiesList = addressHandler.GetCitiesList();
            selectedCity = "Все доступные";
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



        //protected void ClearFilter()
        //{
        //    filter.abon_id = null;
        //    filter.first_name = null;
        //    filter.last_name = null;
        //    filter.surname = null;
        //    filter.phone = null;
        //    filter.conn_city = null;
        //    filter.conn_street = null;
        //    filter.conn_house = null;
        //    filter.conn_apartment = null;
        //    selectedCity = "Все доступные";
        //    max_result_count = 20;
        //}

        protected void GoToAbonPage(int abon_id)
        {
            navManager.NavigateTo($"/abon/info/{abon_id}");
        }
    }
}
