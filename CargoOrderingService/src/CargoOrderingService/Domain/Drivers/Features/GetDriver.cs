namespace CargoOrderingService.Domain.Drivers.Features;

using CargoOrderingService.Domain.Drivers.Dtos;
using CargoOrderingService.Domain.Drivers.Services;
using CargoOrderingService.Exceptions;
using CargoOrderingService.Domain;
using HeimGuard;
using Mappings;
using MediatR;

public static class GetDriver
{
    public sealed record Query(Guid DriverId) : IRequest<DriverDto>;

    public sealed class Handler : IRequestHandler<Query, DriverDto>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IHeimGuardClient _heimGuard;

        public Handler(IDriverRepository driverRepository, IHeimGuardClient heimGuard)
        {
            _driverRepository = driverRepository;
            _heimGuard = heimGuard;
        }

        public async Task<DriverDto> Handle(Query request, CancellationToken cancellationToken)
        {
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanReadDriver);

            var result = await _driverRepository.GetById(request.DriverId, cancellationToken: cancellationToken);
            return result.ToDriverDto();
        }
    }
}