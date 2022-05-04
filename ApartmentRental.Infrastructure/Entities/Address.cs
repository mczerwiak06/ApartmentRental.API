namespace ApartmentRental.Infrastructure.Entities;

public class Address : BaseEntity
{
    public string Street { get; set; }
    public string? AppartmentNumber { get; set; }
    public string? BuildingNumber { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
}
