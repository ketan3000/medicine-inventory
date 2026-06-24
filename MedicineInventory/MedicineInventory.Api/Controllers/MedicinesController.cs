using MedicineInventory.Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineInventory.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MedicinesController : ControllerBase
{
    private readonly IMedicineService _medicineService;

    public MedicinesController(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMedicines([FromQuery] string? searchText)
    {
        var result = await _medicineService.GetMedicinesAsync(searchText);
        return Ok(result);
    }
}
