namespace CargoOrderingService.SharedTestHelpers.Fakes.Driver;

using AutoBogus;
using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.Models;

public sealed class FakeDriverForCreation : AutoFaker<DriverForCreation>
{
    public FakeDriverForCreation()
    {
    }
}