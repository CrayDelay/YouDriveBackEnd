namespace CargoOrderingService.Domain.Drivers.Dtos;

using CargoOrderingService.Resources;

public sealed class DriverParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
