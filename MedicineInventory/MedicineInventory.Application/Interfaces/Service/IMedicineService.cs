using MedicineInventory.Application.DTOs;


namespace MedicineInventory.Application.Interfaces.Service;

public interface IMedicineService
{
    Task<List<MedicineDto>> GetMedicinesAsync(string? searchText);

}
