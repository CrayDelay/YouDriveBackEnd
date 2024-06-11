namespace CargoOrderingService.Domain.Drivers.Features;

using CargoOrderingService.Domain.Drivers.Dtos;
using CargoOrderingService.Domain.Drivers.Services;
using CargoOrderingService.Exceptions;
using CargoOrderingService.Resources;
using CargoOrderingService.Domain;
using HeimGuard;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetAllDrivers
{
    public sealed record Query() : IRequest<List<DriverDto>>;

    public sealed class Handler : IRequestHandler<Query, List<DriverDto>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IHeimGuardClient _heimGuard;

        public Handler(IDriverRepository driverRepository, IHeimGuardClient heimGuard)
        {
            _driverRepository = driverRepository;
            _heimGuard = heimGuard;
        }

        public async Task<List<DriverDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanReadDrivers);

            return _driverRepository.Query()
                .AsNoTracking()
                .ToDriverDtoQueryable()
                .ToList();
        }
    }
}