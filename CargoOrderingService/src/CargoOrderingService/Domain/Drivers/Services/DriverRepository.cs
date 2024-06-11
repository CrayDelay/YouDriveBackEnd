namespace CargoOrderingService.Domain.Drivers.Services;

using CargoOrderingService.Domain.Drivers;
using CargoOrderingService.Databases;
using CargoOrderingService.Services;

public interface IDriverRepository : IGenericRepository<Driver>
{
}

public sealed class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    private readonly OrderingContext _dbContext;

    public DriverRepository(OrderingContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
