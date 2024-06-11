namespace CargoOrderingService.SharedTestHelpers.Fakes.Driver;

using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.Models;

public class FakeDriverBuilder
{
    private DriverForCreation _creationData = new FakeDriverForCreation().Generate();

    public FakeDriverBuilder WithModel(DriverForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeDriverBuilder WithDriverName(string driverName)
    {
        _creationData.DriverName = driverName;
        return this;
    }
    
    public FakeDriverBuilder WithLicenseNumber(string licenseNumber)
    {
        _creationData.LicenseNumber = licenseNumber;
        return this;
    }
    
    public FakeDriverBuilder WithPhoneNumber(string phoneNumber)
    {
        _creationData.PhoneNumber = phoneNumber;
        return this;
    }
    
    public FakeDriverBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public Driver Build()
    {
        var result = Driver.Create(_creationData);
        return result;
    }
}