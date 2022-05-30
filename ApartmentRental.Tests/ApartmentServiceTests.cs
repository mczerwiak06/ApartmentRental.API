﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace ApartmentRental.Tests;

public class ApartmentServiceTests
{
    [Fact]
    public async Task GetTheCheapestApartmentAsync_ShouldReturnNull_WhenApartmentsCollectionIsNull()
    {
        var sut = new ApartmentService(Mock.Of<IApartmentRepository>(), Mock.Of<ILandlordRepository>(),
            Mock.Of<IAddressService>());
        var result = await sut.GetTheCheapestApartmentAsync();
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetTheCheapestApartmentAsync_ShouldReturnTheCheapestApartment()
    {
        var apartments = new List<Apartment>
        {
            new()
            {
                Address = new Address()
                {
                    City = "Gdańsk",
                    Country = "Poland",
                    Street = "Grunwaldzka",
                    AppartmentNumber = "1",
                    BuildingNumber = "2",
                    PostCode = "80-000",
                },
                Floor = 1,
                Price = 1000,
                Square = 45,
                RoomsNumber = 3,
                IsElevator = true,
            },
            new()
            {
                Address = new Address()
                {
                    City = "Gdynia",
                    Country = "Poland",
                    Street = "Śląska",
                    AppartmentNumber = "2",
                    BuildingNumber = "3",
                    PostCode = "80-001",
                },
                Floor = 2,
                Price = 900,
                Square = 42,
                RoomsNumber = 1,
                IsElevator = true,
            }

        };
    }
}