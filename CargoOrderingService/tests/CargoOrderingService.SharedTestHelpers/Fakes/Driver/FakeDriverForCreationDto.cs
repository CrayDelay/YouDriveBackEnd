namespace CargoOrderingService.SharedTestHelpers.Fakes.Driver;

using AutoBogus;
using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.Dtos;

public sealed class FakeDriverForCreationDto : AutoFaker<DriverForCreationDto>
{
    public FakeDriverForCreationDto()
    {
    }
}