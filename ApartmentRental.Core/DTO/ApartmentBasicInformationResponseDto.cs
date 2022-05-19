namespace ApartmentRental.Core.DTO;

public class ApartmentBasicInformationResponseDto
{
    public decimal Price { get; set; }
    public int RoomsNumber { get; set; }
    public decimal Square { get; set; }
    public bool IsElevator { get; set; }
    public string City { get; set; }
    public string Street { get; set; }

    public ApartmentBasicInformationResponseDto(decimal price, int roomsNumber, decimal square, 
        bool isElevator, string city, string street)
    {
        Price = price;
        RoomsNumber = roomsNumber;
        Square = square;
        IsElevator = isElevator;
        City = city;
        Street = street;
    }
}