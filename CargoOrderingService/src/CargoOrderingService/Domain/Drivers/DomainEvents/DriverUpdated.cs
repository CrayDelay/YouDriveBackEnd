namespace CargoOrderingService.Domain.Drivers.DomainEvents;

public sealed class DriverUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            