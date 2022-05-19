﻿using ApartmentRental.Infrastructure.Context;
using ApartmentRental.Infrastructure.Entities;
using ApartmentRental.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.Infrastructure.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly MainContext _mainContext;

    public AddressRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public async Task<IEnumerable<Address>> GetAllAsync()
    {
        var address = await _mainContext.Address.ToListAsync();
        return address;
    }

    public async Task<Address> GetByIdAsync(int id)
    {
        var address = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == id);
        if (address == null)
        {
            throw new EntityNotFoundException();
        }

        return address;
    }

    public async Task AddAsync(Address entity)
    {
        var addressToAdd = await _mainContext.Address.AnyAsync(x =>
            x.City == entity.City
            && x.Street == entity.Street
            && x.BuildingNumber == entity.BuildingNumber
            && x.AppartmentNumber == entity.AppartmentNumber
            && x.PostCode == entity.PostCode
            && x.Country == entity.Country);

        if (addressToAdd)
        {
            throw new EntityAlreadyExistsException();
        }
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Address entity)
    {
        var addressToUpdate = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (addressToUpdate == null)
        {
            throw new EntityNotFoundException();
        }
        addressToUpdate.Street = entity.Street;
        addressToUpdate.AppartmentNumber = entity.AppartmentNumber;
        addressToUpdate.BuildingNumber = entity.BuildingNumber;
        addressToUpdate.City = entity.City;
        addressToUpdate.PostCode = entity.PostCode;
        addressToUpdate.Country = entity.Country;
        addressToUpdate.DateOfUpdate = DateTime.UtcNow;
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var addressToDelete = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == id);
        if (addressToDelete != null)
        {
            _mainContext.Address.Remove(addressToDelete);
            await _mainContext.SaveChangesAsync();
        }
        throw new EntityNotFoundException();
    }
}
