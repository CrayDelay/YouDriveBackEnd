namespace DriversManagement.Domain.Trucks.Dtos;

using Destructurama.Attributed;

public sealed record TruckForUpdateDto
{
    public string TruckNumber { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string Capacity { get; set; }
    public string FuelType { get; set; }
    public string RegistrationNumber { get; set; }
    public string VIN { get; set; }
    public string EngineNumber { get; set; }
    public string InsurancePolicyNumber { get; set; }
    public string InsuranceInspirationDate { get; set; }
}
