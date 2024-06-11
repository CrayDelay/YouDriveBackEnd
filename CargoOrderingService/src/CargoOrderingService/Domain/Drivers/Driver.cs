namespace CargoOrderingService.Domain.Drivers;

using System.ComponentModel.DataAnnotations;
using CargoOrderingService.Domain.Deliveries;
using CargoOrderingService.Domain.Orders;
using CargoOrderingService.Domain.Deliveries;
using CargoOrderingService.Domain.Orders;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CargoOrderingService.Exceptions;
using CargoOrderingService.Domain.Drivers.Models;
using CargoOrderingService.Domain.Drivers.DomainEvents;
using CargoOrderingService.Domain.Orders;
using CargoOrderingService.Domain.Orders.Models;
using CargoOrderingService.Domain.Deliveries;
using CargoOrderingService.Domain.Deliveries.Models;


public class Driver : BaseEntity
{
    public string DriverName { get; private set; }

    public string LicenseNumber { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Email { get; private set; }

    public IReadOnlyCollection<Order> Orders { get; } = new List<Order>();

    public IReadOnlyCollection<Delivery> Deliveries { get; } = new List<Delivery>();

    private readonly List<Order> _orders = new();
    //public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    private readonly List<Delivery> _deliveries = new();
    //public IReadOnlyCollection<Delivery> Deliveries => _deliveries.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Driver Create(DriverForCreation driverForCreation)
    {
        var newDriver = new Driver();

        newDriver.DriverName = driverForCreation.DriverName;
        newDriver.LicenseNumber = driverForCreation.LicenseNumber;
        newDriver.PhoneNumber = driverForCreation.PhoneNumber;
        newDriver.Email = driverForCreation.Email;

        newDriver.QueueDomainEvent(new DriverCreated(){ Driver = newDriver });
        
        return newDriver;
    }

    public Driver Update(DriverForUpdate driverForUpdate)
    {
        DriverName = driverForUpdate.DriverName;
        LicenseNumber = driverForUpdate.LicenseNumber;
        PhoneNumber = driverForUpdate.PhoneNumber;
        Email = driverForUpdate.Email;

        QueueDomainEvent(new DriverUpdated(){ Id = Id });
        return this;
    }

    public Driver AddOrder(Order order)
    {
        _orders.Add(order);
        return this;
    }
    
    public Driver RemoveOrder(Order order)
    {
        _orders.RemoveAll(x => x.Id == order.Id);
        return this;
    }

    public Driver AddDelivery(Delivery delivery)
    {
        _deliveries.Add(delivery);
        return this;
    }
    
    public Driver RemoveDelivery(Delivery delivery)
    {
        _deliveries.RemoveAll(x => x.Id == delivery.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Driver() { } // For EF + Mocking
}
