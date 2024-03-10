﻿// <auto-generated />
using System;
using IPSA.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IPSA.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IPSA.Models.AbonPageComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AbonPageComments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbonentId = 1,
                            CommentDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5453),
                            EmployeeId = 1,
                            Text = "Тестовый комментарий"
                        });
                });

            modelBuilder.Entity("IPSA.Models.Abonent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseEntranceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseFloorNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("PassportRegDate")
                        .HasColumnType("date");

                    b.Property<string>("PassportRegistration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumberForSending")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SMSSending")
                        .HasColumnType("bit");

                    b.Property<string>("SecretPhrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abonents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressZipCode = "",
                            Apartment = "3",
                            Balance = 0m,
                            BirthPlace = "гор. Братск",
                            City = "Братск",
                            DateOfBirth = new DateOnly(1993, 1, 10),
                            Email = "sample@gmail.com",
                            FirstName = "Иван",
                            House = "1",
                            HouseEntranceNumber = "1",
                            HouseFloorNumber = "2",
                            LastName = "Иванов",
                            PassportNumber = "334455",
                            PassportRegDate = new DateOnly(2020, 1, 10),
                            PassportRegistration = "ГУ МВД России по Иркутской обл.",
                            PassportSeries = "1122",
                            PhoneNumber = "+78005553535",
                            PhoneNumberForSending = "+78005553535",
                            RegistrationAddress = "гор. Братск, ул. Городская 1-1",
                            RegistrationZipCode = "",
                            SMSSending = false,
                            SecretPhrase = "Код. слово",
                            Street = "Советская",
                            Surname = "Иванович"
                        },
                        new
                        {
                            Id = 2,
                            AddressZipCode = "",
                            Apartment = "1",
                            Balance = 300m,
                            BirthPlace = "гор. Братск",
                            City = "Братск",
                            DateOfBirth = new DateOnly(1989, 5, 9),
                            Email = "petrov_s@gmail.com",
                            FirstName = "Сергей",
                            House = "5а",
                            HouseEntranceNumber = "1",
                            HouseFloorNumber = "1",
                            LastName = "Петров",
                            PassportNumber = "456123",
                            PassportRegDate = new DateOnly(2018, 1, 8),
                            PassportRegistration = "ГУ МВД России по Иркутской обл.",
                            PassportSeries = "1589",
                            PhoneNumber = "+78005553535",
                            PhoneNumberForSending = "+78005553535",
                            RegistrationAddress = "гор. Братск, ул. Мира 1-1",
                            RegistrationZipCode = "",
                            SMSSending = false,
                            SecretPhrase = "Петров",
                            Street = "Советская",
                            Surname = "Николаевич"
                        });
                });

            modelBuilder.Entity("IPSA.Models.AbonentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentId")
                        .HasColumnType("int");

                    b.Property<string>("AllocatedEngineer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CompletionDate")
                        .HasColumnType("date");

                    b.Property<string>("CompletionTimePeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbonentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AbonentRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbonentId = 1,
                            AllocatedEngineer = "",
                            CompletionDate = new DateOnly(2024, 3, 5),
                            CompletionTimePeriod = "15:00 - 17:00",
                            CreationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5424),
                            Description = "Подкл. СПД через роутер абонента, документы выданы, кабеля нет, предв. позвонить",
                            EmployeeId = 1,
                            LastUpdateDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5424),
                            Status = "Открыта",
                            Type = "Подключение СПД"
                        });
                });

            modelBuilder.Entity("IPSA.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Братск"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Иркутск"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Усть-Кут"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Железногорск"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Вихоревка"
                        });
                });

            modelBuilder.Entity("IPSA.Models.ConnectedTariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAutoblocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("LinkToHardware")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbonentId");

                    b.HasIndex("TariffId");

                    b.ToTable("ConnectedTariffs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbonentId = 1,
                            CreationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5593),
                            IpAddress = "127.0.0.1",
                            IsAutoblocked = false,
                            IsBlocked = false,
                            LinkToHardware = "(ссылка на мост к сетевому оборудованию)",
                            TariffId = 1
                        },
                        new
                        {
                            Id = 2,
                            AbonentId = 1,
                            CreationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5613),
                            IpAddress = "127.0.0.1",
                            IsAutoblocked = false,
                            IsBlocked = false,
                            LinkToHardware = "(ссылка на мост к сетевому оборудованию)",
                            TariffId = 2
                        },
                        new
                        {
                            Id = 3,
                            AbonentId = 2,
                            CreationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5628),
                            IpAddress = "127.0.0.1",
                            IsAutoblocked = false,
                            IsBlocked = false,
                            LinkToHardware = "(ссылка на мост к сетевому оборудованию)",
                            TariffId = 3
                        });
                });

            modelBuilder.Entity("IPSA.Models.DailyFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ConnectedTariffId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ConnectedTariffId");

                    b.ToTable("DailyFees");
                });

            modelBuilder.Entity("IPSA.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmloyeeRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmloyeeRole = "Менеджер сети",
                            Name = "Менеджеры сети"
                        },
                        new
                        {
                            Id = 2,
                            EmloyeeRole = "Техподдержка",
                            Name = "Служба технической поддержки"
                        },
                        new
                        {
                            Id = 3,
                            EmloyeeRole = "Наладчик",
                            Name = "Инженеры сети и наладчики"
                        });
                });

            modelBuilder.Entity("IPSA.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            FullName = "Увалова Александра Николаевна",
                            Login = "manager",
                            Password = "manager",
                            RegistrationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5316),
                            ShortName = "Увалова А."
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            FullName = "Свиридов Иван Петрович",
                            Login = "techsup",
                            Password = "techsup",
                            RegistrationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5336),
                            ShortName = "Свиридов И."
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 3,
                            FullName = "Донских Александр Иванович",
                            Login = "engineer",
                            Password = "engineer",
                            RegistrationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5350),
                            ShortName = "Донских А."
                        });
                });

            modelBuilder.Entity("IPSA.Models.FeeWithdraw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CompletionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConnectedTariffId")
                        .HasColumnType("int");

                    b.Property<string>("PricingModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbonentId");

                    b.HasIndex("ConnectedTariffId");

                    b.ToTable("FeeWithdraws");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbonentId = 1,
                            Amount = 400m,
                            CompletionDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5650),
                            ConnectedTariffId = 1,
                            PricingModel = "Месячный",
                            Type = "Списание"
                        },
                        new
                        {
                            Id = 2,
                            AbonentId = 1,
                            Amount = 200m,
                            CompletionDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5667),
                            ConnectedTariffId = 2,
                            PricingModel = "Месячный",
                            Type = "Списание"
                        },
                        new
                        {
                            Id = 3,
                            AbonentId = 2,
                            Amount = 50m,
                            CompletionDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5682),
                            ConnectedTariffId = 3,
                            PricingModel = "Посуточный",
                            Type = "Списание"
                        });
                });

            modelBuilder.Entity("IPSA.Models.MonthlyFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ConnectedTariffId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("ScheduledDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ConnectedTariffId");

                    b.ToTable("MonthlyFees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 400m,
                            ConnectedTariffId = 1,
                            IsCompleted = false,
                            ScheduledDate = new DateOnly(2024, 3, 5)
                        });
                });

            modelBuilder.Entity("IPSA.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbonentId = 1,
                            Amount = 10m,
                            Cancelled = true,
                            Comment = "тест",
                            ManagerId = 1,
                            PaymentDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5483),
                            PaymentType = "Наличными в офисе"
                        });
                });

            modelBuilder.Entity("IPSA.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Streets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Мира"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Южная"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "Подбельского"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            Name = "Кирова"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            Name = "Пихтовая"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            Name = "Ленина"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 1,
                            Name = "Обручева"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 1,
                            Name = "Советская"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 1,
                            Name = "Гагарина"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 1,
                            Name = "Рябикова"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 2,
                            Name = "Байкальская"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 3,
                            Name = "Пушкина"
                        },
                        new
                        {
                            Id = 13,
                            CityId = 4,
                            Name = "2-й квартал"
                        },
                        new
                        {
                            Id = 14,
                            CityId = 5,
                            Name = "Кошевого"
                        });
                });

            modelBuilder.Entity("IPSA.Models.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MonthlyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PricingModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tariffs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Archived = false,
                            CreationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5507),
                            DailyPrice = 13.4m,
                            Description = "Безлимитный Интернет со скоростью 100 Мбит/сек с ежемесячной платой",
                            MonthlyPrice = 400m,
                            Name = "Безлимитный 100",
                            PricingModel = "Месячный",
                            Type = "Интернет"
                        },
                        new
                        {
                            Id = 2,
                            Archived = false,
                            CreationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5554),
                            DailyPrice = 6.7m,
                            Description = "Базовый пакет каналов цифрового телевидения с ежемесячной платой",
                            MonthlyPrice = 200m,
                            Name = "Базовое ЦКТВ",
                            PricingModel = "Месячный",
                            Type = "ЦКТВ"
                        },
                        new
                        {
                            Id = 3,
                            Archived = false,
                            CreationDateTime = new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5572),
                            DailyPrice = 50m,
                            Description = "Безлимитный Интернет со скоростью до 100 Мбит/сек с посуточным списанием платы",
                            MonthlyPrice = 0m,
                            Name = "Посуточный Безлимит 100",
                            PricingModel = "Посуточный",
                            Type = "Интернет"
                        });
                });

            modelBuilder.Entity("IPSA.Models.AbonentRequest", b =>
                {
                    b.HasOne("IPSA.Models.Abonent", "Abonent")
                        .WithMany("AbonentRequests")
                        .HasForeignKey("AbonentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPSA.Models.Employee", "Employee")
                        .WithMany("AbonentRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abonent");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("IPSA.Models.ConnectedTariff", b =>
                {
                    b.HasOne("IPSA.Models.Abonent", "Abonent")
                        .WithMany("ConnectedTariffs")
                        .HasForeignKey("AbonentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPSA.Models.Tariff", "Tariff")
                        .WithMany("ConnectedTariffs")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abonent");

                    b.Navigation("Tariff");
                });

            modelBuilder.Entity("IPSA.Models.DailyFee", b =>
                {
                    b.HasOne("IPSA.Models.ConnectedTariff", "ConnectedTariff")
                        .WithMany()
                        .HasForeignKey("ConnectedTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConnectedTariff");
                });

            modelBuilder.Entity("IPSA.Models.Employee", b =>
                {
                    b.HasOne("IPSA.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("IPSA.Models.FeeWithdraw", b =>
                {
                    b.HasOne("IPSA.Models.Abonent", "Abonent")
                        .WithMany()
                        .HasForeignKey("AbonentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPSA.Models.ConnectedTariff", "ConnTariff")
                        .WithMany()
                        .HasForeignKey("ConnectedTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abonent");

                    b.Navigation("ConnTariff");
                });

            modelBuilder.Entity("IPSA.Models.MonthlyFee", b =>
                {
                    b.HasOne("IPSA.Models.ConnectedTariff", "ConnectedTariff")
                        .WithMany()
                        .HasForeignKey("ConnectedTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConnectedTariff");
                });

            modelBuilder.Entity("IPSA.Models.Abonent", b =>
                {
                    b.Navigation("AbonentRequests");

                    b.Navigation("ConnectedTariffs");
                });

            modelBuilder.Entity("IPSA.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("IPSA.Models.Employee", b =>
                {
                    b.Navigation("AbonentRequests");
                });

            modelBuilder.Entity("IPSA.Models.Tariff", b =>
                {
                    b.Navigation("ConnectedTariffs");
                });
#pragma warning restore 612, 618
        }
    }
}
