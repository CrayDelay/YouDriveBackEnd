namespace DriversManagement.Domain.Photos.Models;

using Destructurama.Attributed;

public sealed class PhotoForUpdate
{
    public string PhotoData { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public string FileSizels { get; set; }
}
