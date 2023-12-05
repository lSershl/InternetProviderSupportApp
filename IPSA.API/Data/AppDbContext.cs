using Microsoft.EntityFrameworkCore;
using IPSA.Models;


namespace IPSA.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Abonents
            modelBuilder.Entity<Abonent>().HasData(new Abonent
            {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Иван",
                Surname = "Иванович",
                DateOfBirth = new DateOnly(1993, 01, 10),
                BirthPlace = "гор. Братск",
                PhoneNumber = "+78005553535",
                PhoneNumberForSending = "+78005553535",
                Email = "sample@gmail.com",
                PassportSeries = "1122",
                PassportNumber = "334455",
                PassportRegistration = "ГУ МВД России по Иркутской обл.",
                PassportRegDate = new DateOnly(2020, 01, 10),
                RegistrationAddress = "гор. Братск, ул. Городская 1-1",
                RegistrationZipCode = "",
                City = "Братск",
                Street = "Советская",
                House = "1",
                Apartment = "3",
                HouseEntranceNumber = "1",
                HouseFloorNumber = "2",
                AddressZipCode = "",
                SecretPhrase = "Код. слово",
                SMSSending = false,
                Balance = 0m
            });

            // AbonPageComments
            modelBuilder.Entity<AbonPageComment>().HasData(new AbonPageComment
            {
                Id = 1,
                AbonentId = 1,
                EmployeeId = 1,
                Text = "Тестовый комментарий",
                CommentDateTime = DateTime.UtcNow
            });

            // Payments
            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                Id = 1,
                AbonentId = 1,
                ManagerId = 1,
                PaymentDateTime = DateTime.UtcNow,
                PaymentType = "",
                Comment = "",
                Amount = 10m
            });

            // Cities
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 1,
                Name = "Братск"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 2,
                Name = "Иркутск"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 3,
                Name = "Усть-Кут"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 4,
                Name = "Железногорск"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 5,
                Name = "Вихоревка"
            });

            // Districts
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 1,
                Name = "1-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 2,
                Name = "2-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 3,
                Name = "4-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 4,
                Name = "9-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 5,
                Name = "10-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 6,
                Name = "11-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 7,
                Name = "14-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 8,
                Name = "17-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 9,
                Name = "18-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 10,
                Name = "20-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 11,
                Name = "21-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 12,
                Name = "22-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 13,
                Name = "23-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 14,
                Name = "24-й мкрн",
                CityId = 1
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 15,
                Name = "Иркутск",
                CityId = 2
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 16,
                Name = "Усть-Кут",
                CityId = 3
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 17,
                Name = "Железногорск",
                CityId = 4
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 18,
                Name = "Вихоревка",
                CityId = 5
            });

            // Streets
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 1,
                Name = "Мира",
                CityId = 1,
                DistId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 2,
                Name = "Южная",
                CityId = 1,
                DistId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 3,
                Name = "Подбельского",
                CityId = 1,
                DistId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 4,
                Name = "Кирова",
                CityId = 1,
                DistId = 2
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 5,
                Name = "Пихтовая",
                CityId = 1,
                DistId = 3
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 6,
                Name = "Ленина",
                CityId = 1,
                DistId = 6
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 7,
                Name = "Обручева",
                CityId = 1,
                DistId = 7
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 8,
                Name = "Советская",
                CityId = 1,
                DistId = 9
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 9,
                Name = "Гагарина",
                CityId = 1,
                DistId = 11
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 10,
                Name = "Рябикова",
                CityId = 1,
                DistId = 14
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 11,
                Name = "Байкальская",
                CityId = 2,
                DistId = 15
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 12,
                Name = "Пушкина",
                CityId = 3,
                DistId = 16
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 13,
                Name = "2-й квартал",
                CityId = 4,
                DistId = 17
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 14,
                Name = "Кошевого",
                CityId = 5,
                DistId = 18
            });

            // Houses
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 1,
                Name = "1",
                CityId = 1,
                DistId = 1,
                StreetId = 1
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 2,
                Name = "52",
                CityId = 1,
                DistId = 3,
                StreetId = 5
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 3,
                Name = "16",
                CityId = 1,
                DistId = 4,
                StreetId = 4
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 4,
                Name = "18",
                CityId = 1,
                DistId = 9,
                StreetId = 8
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 5,
                Name = "26",
                CityId = 1,
                DistId = 14,
                StreetId = 10
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 6,
                Name = "26",
                CityId = 1,
                DistId = 14,
                StreetId = 10
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 7,
                Name = "26",
                CityId = 2,
                DistId = 15,
                StreetId = 11
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 8,
                Name = "26",
                CityId = 3,
                DistId = 16,
                StreetId = 12
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 9,
                Name = "26",
                CityId = 4,
                DistId = 17,
                StreetId = 13
            });
            modelBuilder.Entity<House>().HasData(new House
            {
                Id = 10,
                Name = "26",
                CityId = 5,
                DistId = 18,
                StreetId = 14
            });
        }

        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<AbonPageComment> AbonPageComments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
