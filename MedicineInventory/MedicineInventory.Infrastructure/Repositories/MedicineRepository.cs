using MedicineInventory.Application.Interfaces.Repository;
using MedicineInventory.Domain.Entities;
using MedicineInventory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicineInventory.Infrastructure.Repositories;

public class MedicineRepository : IMedicineRepository
{
    private readonly MedicineDbContext _context;

    public MedicineRepository(MedicineDbContext context)
    {
        _context = context;
    }

    public async Task<List<Medicine>> GetMedicinesAsync(string? searchText)
    {
        IQueryable<Medicine> query = _context.Medicines
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            searchText = searchText.Trim();

            query = query.Where(x =>
                EF.Functions.Like(x.FullName, $"%{searchText}%"));
        }

        return await query
            .OrderBy(x => x.FullName)
            .ToListAsync();
    }
}