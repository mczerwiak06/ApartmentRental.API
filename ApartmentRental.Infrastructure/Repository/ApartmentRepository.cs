﻿using ApartmentRental.Infrastructure.Context;
using ApartmentRental.Infrastructure.Entities;
using ApartmentRental.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.Infrastructure.Repository;

public class ApartmentRepository : IApartmentRepository
{
    private readonly MainContext _mainContext;

    public ApartmentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Apartment>> GetAllAsync()
    {
        var apartments = await _mainContext.Apartment.ToListAsync();
        foreach (var apartment in apartments)
        {
            await _mainContext.Entry(apartment).Reference(x => x.Address).LoadAsync();
        }
        
        return apartments;
    }

    public async Task<Apartment> GetByIdAsync(int id)
    {
        var apartment = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == id);
        if (apartment != null)
        {
            await _mainContext.Entry(apartment).Reference(x => x.Address).LoadAsync();
            return apartment;
        }

        throw new EntityNotFoundException();
    }

    public async Task AddAsync(Apartment entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Apartment entity)
    {
        var apartmentToUpdate = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (apartmentToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        apartmentToUpdate.Floor = entity.Floor;
        apartmentToUpdate.IsElevator = entity.IsElevator;
        apartmentToUpdate.Price = entity.Price;
        apartmentToUpdate.Square = entity.Square;
        apartmentToUpdate.RoomsNumber = entity.RoomsNumber;
        apartmentToUpdate.DateOfUpdate = DateTime.UtcNow;
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var apartmentToDelete = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == id);
        if (apartmentToDelete != null)
        {
            _mainContext.Apartment.Remove(apartmentToDelete);
            await _mainContext.SaveChangesAsync();
        }

        throw new EntityNotFoundException();
    }
}

