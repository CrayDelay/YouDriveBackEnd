namespace DriversManagement.Domain.Repairs.Dtos;

using Destructurama.Attributed;

public sealed record RepairForCreationDto
{
    public string RepairDate { get; set; }
    public string Description { get; set; }
    public string Cost { get; set; }

}
