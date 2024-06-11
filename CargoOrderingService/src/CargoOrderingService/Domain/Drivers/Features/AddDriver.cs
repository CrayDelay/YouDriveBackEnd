namespace CargoOrderingService.Domain.Drivers.Features;

using CargoOrderingService.Domain.Drivers.Services;
using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.Dtos;
using CargoOrderingService.Domain.Drivers.Models;
using CargoOrderingService.Services;
using CargoOrderingService.Exceptions;
using CargoOrderingService.Domain;
using HeimGuard;
using Mappings;
using MediatR;

public static class AddDriver
{
    public sealed record Command(DriverForCreationDto DriverToAdd) : IRequest<DriverDto>;

    public sealed class Handler : IRequestHandler<Command, DriverDto>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeimGuardClient _heimGuard;

        public Handler(IDriverRepository driverRepository, IUnitOfWork unitOfWork, IHeimGuardClient heimGuard)
        {
            _driverRepository = driverRepository;
            _unitOfWork = unitOfWork;
            _heimGuard = heimGuard;
        }

        public async Task<DriverDto> Handle(Command request, CancellationToken cancellationToken)
        {
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanAddDriver);

            var driverToAdd = request.DriverToAdd.ToDriverForCreation();
            var driver = Driver.Create(driverToAdd);

            await _driverRepository.Add(driver, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);

            return driver.ToDriverDto();
        }
    }
}