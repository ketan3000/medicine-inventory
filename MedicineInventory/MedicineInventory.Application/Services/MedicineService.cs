using MedicineInventory.Application.DTOs;
using MedicineInventory.Application.Interfaces.Repository;
using MedicineInventory.Application.Interfaces.Service;
using MedicineInventory.Domain.Entities;

namespace MedicineInventory.Application.Services;

public class MedicineService : IMedicineService
{
    private readonly IMedicineRepository _medicineRepository;

    public MedicineService(IMedicineRepository medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }

    public async Task<List<MedicineDto>> GetMedicinesAsync(string? searchText)
    {
        var medicines = await _medicineRepository.GetMedicinesAsync(searchText);

        var today = DateTime.Today;

        return medicines.Select(m => new MedicineDto
        {
            Id = m.Id,
            FullName = m.FullName,
            ExpiryDate = m.ExpiryDate,
            Quantity = m.Quantity,
            Price = Math.Round(m.Price, 2),
            Brand = m.Brand,
            RowColor = GetRowColor(m, today)
        }).ToList();
    }

    private static string GetRowColor(Medicine medicine, DateTime today)
    {
        var daysToExpire = (medicine.ExpiryDate.Date - today).TotalDays;

        if (daysToExpire < 30)
        {
            return "red";
        }

        if (medicine.Quantity < 10)
        {
            return "yellow";
        }

        return "normal";
    }
}
