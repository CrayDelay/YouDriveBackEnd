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

public static class GetDriverList
{
    public sealed record Query(DriverParametersDto QueryParameters) : IRequest<PagedList<DriverDto>>;

    public sealed class Handler : IRequestHandler<Query, PagedList<DriverDto>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IHeimGuardClient _heimGuard;

        public Handler(IDriverRepository driverRepository, IHeimGuardClient heimGuard)
        {
            _driverRepository = driverRepository;
            _heimGuard = heimGuard;
        }

        public async Task<PagedList<DriverDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanReadDrivers);

            var collection = _driverRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToDriverDtoQueryable();

            return await PagedList<DriverDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}