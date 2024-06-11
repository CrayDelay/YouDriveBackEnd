namespace CargoOrderingService.UnitTests.Domain.Drivers;

using CargoOrderingService.SharedTestHelpers.Fakes.Driver;
using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CargoOrderingService.Exceptions.ValidationException;

public class UpdateDriverTests
{
    private readonly Faker _faker;

    public UpdateDriverTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_driver()
    {
        // Arrange
        var driver = new FakeDriverBuilder().Build();
        var updatedDriver = new FakeDriverForUpdate().Generate();
        
        // Act
        driver.Update(updatedDriver);

        // Assert
        driver.DriverName.Should().Be(updatedDriver.DriverName);
        driver.LicenseNumber.Should().Be(updatedDriver.LicenseNumber);
        driver.PhoneNumber.Should().Be(updatedDriver.PhoneNumber);
        driver.Email.Should().Be(updatedDriver.Email);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var driver = new FakeDriverBuilder().Build();
        var updatedDriver = new FakeDriverForUpdate().Generate();
        driver.DomainEvents.Clear();
        
        // Act
        driver.Update(updatedDriver);

        // Assert
        driver.DomainEvents.Count.Should().Be(1);
        driver.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DriverUpdated));
    }
}