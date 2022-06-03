using ApartmentRental.Core.DTO;
using ApartmentRental.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentRental.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LandLordController : ControllerBase
{
    private readonly ILandlordService _landlordService;

    public LandLordController(ILandlordService landlordService)
    {
        _landlordService = landlordService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateNewLandLordAccount([FromBody] LandlordCreationRequestDto dto)
    {
        await _landlordService.AddNewLandlordAsync(dto);
        return NoContent();
    }
    
}