namespace CargoOrderingService.SharedTestHelpers.Fakes.Driver;

using AutoBogus;
using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.Dtos;

public sealed class FakeDriverForUpdateDto : AutoFaker<DriverForUpdateDto>
{
    public FakeDriverForUpdateDto()
    {
    }
}