﻿// <auto-generated />
using System;
using IPSA.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IPSA.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231204112336_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CommentDateTime = new DateTime(2023, 12, 4, 11, 23, 35, 540, DateTimeKind.Utc).AddTicks(8382),
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

            modelBuilder.Entity("IPSA.Models.District", b =>
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

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "1-й мкрн"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "2-й мкрн"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "4-й мкрн"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            Name = "9-й мкрн"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            Name = "10-й мкрн"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            Name = "11-й мкрн"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 1,
                            Name = "14-й мкрн"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 1,
                            Name = "17-й мкрн"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 1,
                            Name = "18-й мкрн"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 1,
                            Name = "20-й мкрн"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 1,
                            Name = "21-й мкрн"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 1,
                            Name = "22-й мкрн"
                        },
                        new
                        {
                            Id = 13,
                            CityId = 1,
                            Name = "23-й мкрн"
                        },
                        new
                        {
                            Id = 14,
                            CityId = 1,
                            Name = "24-й мкрн"
                        },
                        new
                        {
                            Id = 15,
                            CityId = 2,
                            Name = "Иркутск"
                        },
                        new
                        {
                            Id = 16,
                            CityId = 3,
                            Name = "Усть-Кут"
                        },
                        new
                        {
                            Id = 17,
                            CityId = 4,
                            Name = "Железногорск"
                        },
                        new
                        {
                            Id = 18,
                            CityId = 5,
                            Name = "Вихоревка"
                        });
                });

            modelBuilder.Entity("IPSA.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("DistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            DistId = 1,
                            Name = "1",
                            StreetId = 1
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            DistId = 3,
                            Name = "52",
                            StreetId = 5
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            DistId = 4,
                            Name = "16",
                            StreetId = 4
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            DistId = 9,
                            Name = "18",
                            StreetId = 8
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            DistId = 14,
                            Name = "26",
                            StreetId = 10
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            DistId = 14,
                            Name = "26",
                            StreetId = 10
                        },
                        new
                        {
                            Id = 7,
                            CityId = 2,
                            DistId = 15,
                            Name = "26",
                            StreetId = 11
                        },
                        new
                        {
                            Id = 8,
                            CityId = 3,
                            DistId = 16,
                            Name = "26",
                            StreetId = 12
                        },
                        new
                        {
                            Id = 9,
                            CityId = 4,
                            DistId = 17,
                            Name = "26",
                            StreetId = 13
                        },
                        new
                        {
                            Id = 10,
                            CityId = 5,
                            DistId = 18,
                            Name = "26",
                            StreetId = 14
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
                            Comment = "",
                            ManagerId = 1,
                            PaymentDateTime = new DateTime(2023, 12, 4, 11, 23, 35, 540, DateTimeKind.Utc).AddTicks(8410),
                            PaymentType = ""
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

                    b.Property<int>("DistId")
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
                            DistId = 1,
                            Name = "Мира"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            DistId = 1,
                            Name = "Южная"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            DistId = 1,
                            Name = "Подбельского"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            DistId = 2,
                            Name = "Кирова"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            DistId = 3,
                            Name = "Пихтовая"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            DistId = 6,
                            Name = "Ленина"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 1,
                            DistId = 7,
                            Name = "Обручева"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 1,
                            DistId = 9,
                            Name = "Советская"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 1,
                            DistId = 11,
                            Name = "Гагарина"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 1,
                            DistId = 14,
                            Name = "Рябикова"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 2,
                            DistId = 15,
                            Name = "Байкальская"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 3,
                            DistId = 16,
                            Name = "Пушкина"
                        },
                        new
                        {
                            Id = 13,
                            CityId = 4,
                            DistId = 17,
                            Name = "2-й квартал"
                        },
                        new
                        {
                            Id = 14,
                            CityId = 5,
                            DistId = 18,
                            Name = "Кошевого"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
