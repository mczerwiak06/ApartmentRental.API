using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentRental.Core.DTO;
using ApartmentRental.Core.Services;
using ApartmentRental.Infrastructure.Entities;
using ApartmentRental.Infrastructure.Exceptions;
using ApartmentRental.Infrastructure.Repository;
using FluentAssertions;
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
        var apartmentRepositoryMock = new Moq.Mock<IApartmentRepository>();
        apartmentRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(apartments);

        var sut = new ApartmentService(apartmentRepositoryMock.Object, Mock.Of<ILandlordRepository>(),
            Mock.Of<IAddressService>());

        var result = await sut.GetTheCheapestApartmentAsync();
        result.Should().NotBeNull();
        result.City.Should().Be("Gdynia");
        result.Street.Should().Be("Śląska");
        result.Price.Should().Be(900);
        result.Square.Should().Be(42);
        result.RoomsNumber.Should().Be(1);
        result.IsElevator.Should().BeTrue();
    }

    [Fact]
    public async Task
        AddNewApartmentToExisitingLandlordAsync_ShouldThrowEntityNotFoundException_WhenLandlordWithGivenIdDoesntExist()
    {
        var sut = new ApartmentService(Mock.Of<IApartmentRepository>(), Mock.Of<ILandlordRepository>(),
            Mock.Of<IAddressService>());
        Func<Task> check = async () => await sut.AddNewApartmentToExistingLandLordAsync(new ApartmentCreationRequestDto(200, 2, 50, 4, false, "Gdynia", "Miegonia", "81-103", "b7", "16", "Polska", 33));

        await check.Should().ThrowAsync<EntityNotFoundException>();
    }
    
    
    [Fact]
    public async Task GetAllApartmentsBasicInfosAsync_ShouldNotReturnNull()
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
        var apartmentRepositoryMock = new Moq.Mock<IApartmentRepository>();
        apartmentRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(apartments);
        
        var sut = new ApartmentService(apartmentRepositoryMock.Object, Mock.Of<ILandlordRepository>(),
            Mock.Of<IAddressService>());

        var result = await sut.GetAllApartmentsBasicInfosAsync();

        result.Should().NotBeNull();
        result.Count().Should().Be(2);
    }


}
