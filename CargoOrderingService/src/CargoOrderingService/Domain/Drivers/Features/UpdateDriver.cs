namespace CargoOrderingService.Domain.Drivers.Features;

using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Domain.Drivers.Dtos;
using CargoOrderingService.Domain.Drivers.Services;
using CargoOrderingService.Services;
using CargoOrderingService.Domain.Drivers.Models;
using CargoOrderingService.Exceptions;
using CargoOrderingService.Domain;
using HeimGuard;
using Mappings;
using MediatR;

public static class UpdateDriver
{
    public sealed record Command(Guid DriverId, DriverForUpdateDto UpdatedDriverData) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
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

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanUpdateDriver);

            var driverToUpdate = await _driverRepository.GetById(request.DriverId, cancellationToken: cancellationToken);
            var driverToAdd = request.UpdatedDriverData.ToDriverForUpdate();
            driverToUpdate.Update(driverToAdd);

            _driverRepository.Update(driverToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}