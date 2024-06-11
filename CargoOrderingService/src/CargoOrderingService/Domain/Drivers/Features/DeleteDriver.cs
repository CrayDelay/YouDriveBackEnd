namespace CargoOrderingService.Domain.Drivers.Features;

using CargoOrderingService.Domain.Drivers.Services;
using CargoOrderingService.Services;
using CargoOrderingService.Exceptions;
using CargoOrderingService.Domain;
using HeimGuard;
using MediatR;

public static class DeleteDriver
{
    public sealed record Command(Guid DriverId) : IRequest;

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
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanDeleteDriver);

            var recordToDelete = await _driverRepository.GetById(request.DriverId, cancellationToken: cancellationToken);
            _driverRepository.Remove(recordToDelete);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}