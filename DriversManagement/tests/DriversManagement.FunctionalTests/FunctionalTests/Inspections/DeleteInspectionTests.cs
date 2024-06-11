namespace DriversManagement.FunctionalTests.FunctionalTests.Inspections;

using DriversManagement.SharedTestHelpers.Fakes.Inspection;
using DriversManagement.FunctionalTests.TestUtilities;
using DriversManagement.Domain;
using System.Net;
using System.Threading.Tasks;

public class DeleteInspectionTests : TestBase
{
    [Fact]
    public async Task delete_inspection_returns_nocontent_when_entity_exists_and_auth_credentials_are_valid()
    {
        // Arrange
        var inspection = new FakeInspectionBuilder().Build();

        var callingUser = await AddNewSuperAdmin();
        FactoryClient.AddAuth(callingUser.Identifier);
        await InsertAsync(inspection);

        // Act
        var route = ApiRoutes.Inspections.Delete(inspection.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
            
    [Fact]
    public async Task delete_inspection_returns_unauthorized_without_valid_token()
    {
        // Arrange
        var inspection = new FakeInspectionBuilder().Build();

        // Act
        var route = ApiRoutes.Inspections.Delete(inspection.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
            
    [Fact]
    public async Task delete_inspection_returns_forbidden_without_proper_scope()
    {
        // Arrange
        var inspection = new FakeInspectionBuilder().Build();
        FactoryClient.AddAuth();

        // Act
        var route = ApiRoutes.Inspections.Delete(inspection.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}