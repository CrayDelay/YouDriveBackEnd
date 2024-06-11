namespace CargoOrderingService.SharedTestHelpers.Fakes.Driver;

using AutoBogus;
using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.Models;

public sealed class FakeDriverForUpdate : AutoFaker<DriverForUpdate>
{
    public FakeDriverForUpdate()
    {
    }
}