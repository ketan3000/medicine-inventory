using MedicineInventory.Domain.Entities;


namespace MedicineInventory.Application.Interfaces.Repository;

public interface IMedicineRepository
{
    Task<List<Medicine>> GetMedicinesAsync(string? searchText);
}
