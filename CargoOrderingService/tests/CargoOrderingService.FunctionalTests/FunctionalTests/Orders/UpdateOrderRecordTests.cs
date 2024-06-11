namespace CargoOrderingService.FunctionalTests.FunctionalTests.Orders;

using CargoOrderingService.SharedTestHelpers.Fakes.Order;
using CargoOrderingService.FunctionalTests.TestUtilities;
using CargoOrderingService.Domain;
using System.Net;
using System.Threading.Tasks;

public class UpdateOrderRecordTests : TestBase
{
    [Fact]
    public async Task put_order_returns_nocontent_when_entity_exists_and_auth_credentials_are_valid()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        var updatedOrderDto = new FakeOrderForUpdateDto().Generate();

        var callingUser = await AddNewSuperAdmin();
        FactoryClient.AddAuth(callingUser.Identifier);
        await InsertAsync(order);

        // Act
        var route = ApiRoutes.Orders.Put(order.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedOrderDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
            
    [Fact]
    public async Task put_order_returns_unauthorized_without_valid_token()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        var updatedOrderDto = new FakeOrderForUpdateDto { }.Generate();

        // Act
        var route = ApiRoutes.Orders.Put(order.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedOrderDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
            
    [Fact]
    public async Task put_order_returns_forbidden_without_proper_scope()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        var updatedOrderDto = new FakeOrderForUpdateDto { }.Generate();
        FactoryClient.AddAuth();

        // Act
        var route = ApiRoutes.Orders.Put(order.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedOrderDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}