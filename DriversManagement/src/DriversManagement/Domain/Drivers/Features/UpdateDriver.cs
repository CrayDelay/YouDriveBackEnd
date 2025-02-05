namespace DriversManagement.Domain.Drivers.Features;

using DriversManagement.Domain.Drivers;
using DriversManagement.Domain.Drivers.Dtos;
using DriversManagement.Domain.Drivers.Services;
using DriversManagement.Services;
using DriversManagement.Domain.Drivers.Models;
using DriversManagement.Exceptions;
using DriversManagement.Domain;
using HeimGuard;
using Mappings;
using MediatR;
using MassTransit;

public static class UpdateDriver
{
    public sealed record Command(Guid DriverId, DriverForUpdateDto driverForUpdateDto) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IDriverRepository _driverRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeimGuardClient _heimGuard;

        public Handler(IDriverRepository driverRepository, 
            IUnitOfWork unitOfWork, 
            IHeimGuardClient heimGuard, 
            IPublishEndpoint publishEndpoint)
        {
            _driverRepository = driverRepository;
            _unitOfWork = unitOfWork;
            _heimGuard = heimGuard;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            //await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanUpdateDriver);

            Driver driverToUpdate = await _driverRepository.GetById(request.DriverId, cancellationToken: cancellationToken);
            DriverForUpdate driverToAdd = request.driverForUpdateDto.ToDriverForUpdate();
            driverToUpdate.Update(driverToAdd);

            //���������� � ���������� ���������
            _driverRepository.Update(driverToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
            //�������� ������
            
            
            var message = new SharedKernel.Messages.DriverUpdated
            {
                DriverId = driverToUpdate.Id,
                FirstName = driverToUpdate.FirstName,
                LastName = driverToUpdate.LastName
            };
            //�������� � ������� ������
            await _publishEndpoint.Publish<SharedKernel.Messages.IDriverUpdated>(message, cancellationToken);
        }
    }
}