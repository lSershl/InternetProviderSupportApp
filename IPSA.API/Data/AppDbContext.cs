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

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AbonentRequests)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<Abonent>()
                .HasMany(e => e.ConnectedTariffs)
                .WithOne(e => e.Abonent)
                .HasForeignKey(e => e.AbonentId)
                .IsRequired();

            modelBuilder.Entity<Abonent>()
                .HasMany(e => e.AbonentRequests)
                .WithOne(e => e.Abonent)
                .HasForeignKey(e => e.AbonentId)
                .IsRequired();

            modelBuilder.Entity<Tariff>()
                .HasMany(e => e.ConnectedTariffs)
                .WithOne(e => e.Tariff)
                .HasForeignKey(e => e.TariffId)
                .IsRequired();

            // Seed Data

            // Departments
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                Name = "Менеджеры сети",
                EmloyeeRole = "Менеджер сети"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 2,
                Name = "Служба технической поддержки",
                EmloyeeRole = "Техподдержка"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 3,
                Name = "Инженеры сети и наладчики",
                EmloyeeRole = "Наладчик"
            });

            // Employees
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FullName = "Увалова Александра Николаевна",
                ShortName = "Увалова А.",
                RegistrationDateTime = DateTime.UtcNow,
                Login = "manager",
                Password = "manager"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                DepartmentId = 2,
                FullName = "Свиридов Иван Петрович",
                ShortName = "Свиридов И.",
                RegistrationDateTime = DateTime.UtcNow,
                Login = "techsup",
                Password = "techsup"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                DepartmentId = 3,
                FullName = "Донских Александр Иванович",
                ShortName = "Донских А.",
                RegistrationDateTime = DateTime.UtcNow,
                Login = "engineer",
                Password = "engineer"
            });

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

            // AbonentRequests
            modelBuilder.Entity<AbonentRequest>().HasData(new AbonentRequest
            {
                Id = 1,
                AbonentId = 1,
                EmployeeId = 1,
                CreationDateTime = DateTime.UtcNow,
                LastUpdateDateTime = DateTime.UtcNow,
                CompletionDate = new DateOnly(2024, 03, 05),
                CompletionTimePeriod = "15:00 - 17:00",
                Type = "Подключение СПД",
                Description = "Подкл. СПД через роутер абонента, документы выданы, кабеля нет, предв. позвонить",
                Status = "Открыта"
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
                PaymentType = "Наличными в офисе",
                Comment = "тест",
                Amount = 10m,
                Cancelled = true
            });

            // Tariffs
            modelBuilder.Entity<Tariff>().HasData(new Tariff
            {
                Id = 1,
                CreationDateTime = DateTime.UtcNow,
                Name = "Безлимитный 100",
                Type = "Интернет",
                PricingModel = "Месячный",
                MonthlyPrice = 400m,
                DailyPrice = 13.4m,
                Description = "Безлимитный Интернет со скоростью 100 Мбит/сек с ежемесячной платой",
                Archived = false
            });

            modelBuilder.Entity<Tariff>().HasData(new Tariff
            {
                Id = 2,
                CreationDateTime = DateTime.UtcNow,
                Name = "Базовое ЦКТВ",
                Type = "ЦКТВ",
                PricingModel = "Месячный",
                MonthlyPrice = 200m,
                DailyPrice = 6.7m,
                Description = "Базовый пакет каналов цифрового телевидения с ежемесячной платой",
                Archived = false
            });

            modelBuilder.Entity<Tariff>().HasData(new Tariff
            {
                Id = 3,
                CreationDateTime = DateTime.UtcNow,
                Name = "Посуточный Безлимит 100",
                Type = "Интернет",
                PricingModel = "Посуточный",
                MonthlyPrice = 0,
                DailyPrice = 50m,
                Description = "Безлимитный Интернет со скоростью до 100 Мбит/сек с посуточным списанием платы",
                Archived = false
            });

            // ConnectedTariffs
            modelBuilder.Entity<ConnectedTariff>().HasData(new ConnectedTariff
            {
                Id = 1,
                CreationDateTime = DateTime.UtcNow,
                AbonentId = 1,
                TariffId = 1,
                IpAddress = "127.0.0.1",
                LinkToHardware = "(ссылка на мост к сетевому оборудованию)",
                IsBlocked = false
            });

            modelBuilder.Entity<ConnectedTariff>().HasData(new ConnectedTariff
            {
                Id = 2,
                CreationDateTime = DateTime.UtcNow,
                AbonentId = 1,
                TariffId = 2,
                IpAddress = "127.0.0.1",
                LinkToHardware = "(ссылка на мост к сетевому оборудованию)",
                IsBlocked = false
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



            // Streets
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 1,
                Name = "Мира",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 2,
                Name = "Южная",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 3,
                Name = "Подбельского",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 4,
                Name = "Кирова",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 5,
                Name = "Пихтовая",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 6,
                Name = "Ленина",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 7,
                Name = "Обручева",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 8,
                Name = "Советская",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 9,
                Name = "Гагарина",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 10,
                Name = "Рябикова",
                CityId = 1
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 11,
                Name = "Байкальская",
                CityId = 2
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 12,
                Name = "Пушкина",
                CityId = 3
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 13,
                Name = "2-й квартал",
                CityId = 4
            });
            modelBuilder.Entity<Street>().HasData(new Street
            {
                Id = 14,
                Name = "Кошевого",
                CityId = 5
            });
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<AbonPageComment> AbonPageComments { get; set; }
        public DbSet<AbonentRequest> AbonentRequests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<ConnectedTariff> ConnectedTariffs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
    }
}
