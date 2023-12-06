using IPSA.Web.Dtos;
using IPSA.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace IPSA.Web
{
    public class NewAbonentBase : ComponentBase
    {
        //[Inject]
        //public IAbonentHandler? abonHandler { get; set; }
        //[Inject]
        //public IAddressHandler? addressHandler { get; set; }
        [Inject]
        public IAbonentService AbonentService { get; set; }
        [Inject]
        public NavigationManager NavManager { get; set; }

        public AbonentCreateDto newAbonent = new AbonentCreateDto();

        public AbonentCreateDto testAbonent = new AbonentCreateDto
        {
            LastName = "Петров",
            FirstName = "Николай",
            Surname = "Иванович",
            DateOfBirth = new DateOnly(1991, 02, 08),
            BirthPlace = "гор. Братск",
            PhoneNumber = "+78041656565",
            PhoneNumberForSending = "+78041656565",
            Email = "sample@gmail.com",
            PassportSeries = "4565",
            PassportNumber = "254656",
            PassportRegistration = "ГУ МВД России по Иркутской обл.",
            PassportRegDate = new DateOnly(2018, 02, 10),
            RegistrationAddress = "гор. Братск, ул. Советская 1-8",
            RegistrationZipCode = "",
            City = "Братск",
            Street = "Советская",
            House = "1",
            Apartment = "8",
            HouseEntranceNumber = "1",
            HouseFloorNumber = "4",
            AddressZipCode = "",
            SecretPhrase = "Слово",
            SMSSending = false,
            Balance = 0m
        };

        //public List<City>? citiesList;
        //public List<District>? districtsList;
        //public List<Street>? streetsList;
        //public List<House>? housesList;

        public string registryCity;
        public string registryStreet;
        public string registryHouse;
        public string registryApartment;

        public bool isBusy = false;

        protected override void OnInitialized()
        {
            //citiesList = addressHandler.GetCitiesList();
            //abon.conn_city = citiesList.FirstOrDefault().city_name;
            //streetsList = addressHandler.GetStreetsByCity(citiesList.FirstOrDefault().city_id).DistinctBy(x => x.street_name).OrderBy(x => x.street_name).ToList();

            //AbonentService.AddNewAbonent(testAbonent);
        }

        //protected void SelectCity(string city_name)
        //{
        //    RefreshDistrictsList(city_name);
        //    if (streetsList != null)
        //    {
        //        streetsList.Clear();
        //        RefreshStreetsList(city_name);
        //    }
        //}

        //protected void RefreshDistrictsList(string city_name)
        //{
        //    City city = addressHandler.GetCitiesList().FirstOrDefault(x => x.city_name == city_name);
        //    districtsList = addressHandler.GetDistrictsByCity(city.city_id);
        //}

        //protected void RefreshStreetsList(int distId)
        //{
        //    streetsList = addressHandler.GetStreetsByDistrict(distId);
        //}

        //protected void RefreshStreetsList(string city_name)
        //{
        //    City city = addressHandler.GetCitiesList().FirstOrDefault(x => x.city_name == city_name);
        //    streetsList = addressHandler.GetStreetsByCity(city.city_id).DistinctBy(x => x.street_name).OrderBy(x => x.street_name).ToList();
        //}

        protected void Save_Button_Click()
        {
            isBusy = true;
            //newAbonent.Id = 0;
            //newAbonent.RegistrationAddress = registryCity + ", " + registryStreet + " " + registryHouse + "-" + registryApartment;
            //AbonentService.AddNewAbonent(newAbonent);

            AbonentService.AddNewAbonent(testAbonent);
            
            NavManager.NavigateTo("/abonents");
        }
    }
}
