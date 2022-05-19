using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApartmentRental.Core.DTO;

public class ApartmentCreationRequestDto
{
    public decimal Price { get; set; }
    public int RoomsNumber { get; set; }
    public int Square { get; set; }
    public int Floor { get; set; }
    public bool IsElevator { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
    public string ApartmentNumber { get; set; }
    public string BuildingNumber { get; set; }
    public string Country { get; set; }
    public int LandlordId { get; set; }
}