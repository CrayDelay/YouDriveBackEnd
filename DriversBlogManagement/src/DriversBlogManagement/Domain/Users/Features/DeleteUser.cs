namespace DriversBlogManagement.Domain.Users.Features;

using DriversBlogManagement.Domain.Users.Services;
using DriversBlogManagement.Services;
using DriversBlogManagement.Exceptions;
using DriversBlogManagement.Domain;
using HeimGuard;
using MediatR;

public static class DeleteUser
{
    public sealed record Command(Guid UserId) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeimGuardClient _heimGuard;

        public Handler(IUserRepository userRepository, IUnitOfWork unitOfWork, IHeimGuardClient heimGuard)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _heimGuard = heimGuard;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanDeleteUsers);

            var recordToDelete = await _userRepository.GetById(request.UserId, cancellationToken: cancellationToken);
            _userRepository.Remove(recordToDelete);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}