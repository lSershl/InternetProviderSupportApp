﻿using IPSA.Shared.Dtos;
using IPSA.Shared.Contracts;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web.Client.Pages
{
    public class NewAbonentBase : ComponentBase
    {
        [Inject]
        public required IAbonentService AbonentService { get; set; }
        [Inject]
        public required ICityService CityService { get; set; }
        [Inject]
        public required IStreetService StreetService { get; set; }
        [Inject]
        public required NavigationManager NavManager { get; set; }

        public AbonentCreateDto newAbonent = new AbonentCreateDto();

        public List<CityReadDto>? citiesList = new List<CityReadDto>();
        public List<StreetReadDto>? streetsList = new List<StreetReadDto>();

        protected override async Task OnInitializedAsync()
        {
            citiesList = await CityService.GetCitiesList();

            citiesList = citiesList.OrderBy(x => x.Name).ToList();
        }

        protected async Task RefreshStreetsListOnCityChange()
        {
            int selectedCityId = citiesList!.FirstOrDefault(x => x.Name == newAbonent.City)!.Id;

            streetsList = await StreetService.GetStreetsListByCity(selectedCityId);

            streetsList = streetsList.OrderBy(x => x.Name).ToList();
        }

        protected async Task SaveNewAbonent()
        {
            await AbonentService.AddNewAbonent(newAbonent);

            NavManager.NavigateTo("/Abonents");
        }
    }
}
