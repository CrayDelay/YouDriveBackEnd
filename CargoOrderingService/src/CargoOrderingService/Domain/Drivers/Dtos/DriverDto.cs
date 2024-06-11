namespace CargoOrderingService.Domain.Drivers.Dtos;

using Destructurama.Attributed;

public sealed record DriverDto
{
    public Guid Id { get; set; }
    public string DriverName { get; set; }
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

}
