namespace CargoOrderingService.Domain.Drivers.Models;

using Destructurama.Attributed;

public sealed record DriverForUpdate
{
    public string DriverName { get; set; }
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

}
