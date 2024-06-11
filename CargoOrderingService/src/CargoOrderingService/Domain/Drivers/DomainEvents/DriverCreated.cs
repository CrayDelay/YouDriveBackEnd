namespace CargoOrderingService.Domain.Drivers.DomainEvents;

public sealed class DriverCreated : DomainEvent
{
    public Driver Driver { get; set; } 
}
            