namespace ApartmentRental.Infrastructure.Entities;

public class Account : BaseEntity
{
    public string FirstName { get; set; }
    public string  LastName { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string IsAccountActive { get; set; }
    
    public int AddressId { get; set; }
    public Address Address { get; set; }
}