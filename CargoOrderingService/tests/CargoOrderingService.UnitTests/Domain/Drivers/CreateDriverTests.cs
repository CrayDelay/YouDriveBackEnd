namespace CargoOrderingService.UnitTests.Domain.Drivers;

using CargoOrderingService.SharedTestHelpers.Fakes.Driver;
using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CargoOrderingService.Exceptions.ValidationException;

public class CreateDriverTests
{
    private readonly Faker _faker;

    public CreateDriverTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_driver()
    {
        // Arrange
        var driverToCreate = new FakeDriverForCreation().Generate();
        
        // Act
        var driver = Driver.Create(driverToCreate);

        // Assert
        driver.DriverName.Should().Be(driverToCreate.DriverName);
        driver.LicenseNumber.Should().Be(driverToCreate.LicenseNumber);
        driver.PhoneNumber.Should().Be(driverToCreate.PhoneNumber);
        driver.Email.Should().Be(driverToCreate.Email);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var driverToCreate = new FakeDriverForCreation().Generate();
        
        // Act
        var driver = Driver.Create(driverToCreate);

        // Assert
        driver.DomainEvents.Count.Should().Be(1);
        driver.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DriverCreated));
    }
}