namespace CargoOrderingService.FunctionalTests;

using CargoOrderingService.Databases;
using CargoOrderingService;
using CargoOrderingService.Domain.Roles;
using CargoOrderingService.Domain.Users;
using CargoOrderingService.SharedTestHelpers.Fakes.User;
using AutoBogus;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
 
[Collection(nameof(TestBase))]
public class TestBase : IDisposable
{
    private static IServiceScopeFactory _scopeFactory;
    protected static HttpClient FactoryClient  { get; private set; }

    public TestBase()
    {
        var factory = new TestingWebApplicationFactory();
        _scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
        FactoryClient = factory.CreateClient(new WebApplicationFactoryClientOptions());

        AutoFaker.Configure(builder =>
        {
            // configure global autobogus settings here
            builder.WithDateTimeKind(DateTimeKind.Utc)
                .WithRecursiveDepth(3)
                .WithTreeDepth(1)
                .WithRepeatCount(1);
        });
        
        // seed root user so tests won't always have user as super admin
        AddNewSuperAdmin().Wait();
    }
    
    public void Dispose()
    {
        FactoryClient.Dispose();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetService<ISender>();
        return await mediator.Send(request);
    }

    public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetService<OrderingContext>();
        return await context.FindAsync<TEntity>(keyValues);
    }

    public static async Task AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetService<OrderingContext>();
        context.Add(entity);
        await context.SaveChangesAsync();
    }

    public static async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OrderingContext>();
        await action(scope.ServiceProvider);
    }

    public static async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OrderingContext>();
        return await action(scope.ServiceProvider);
    }

    public static Task ExecuteDbContextAsync(Func<OrderingContext, Task> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<OrderingContext>()));

    public static Task ExecuteDbContextAsync(Func<OrderingContext, ValueTask> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<OrderingContext>()).AsTask());

    public static Task ExecuteDbContextAsync(Func<OrderingContext, IMediator, Task> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<OrderingContext>(), sp.GetService<IMediator>()));

    public static Task<T> ExecuteDbContextAsync<T>(Func<OrderingContext, Task<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<OrderingContext>()));

    public static Task<T> ExecuteDbContextAsync<T>(Func<OrderingContext, ValueTask<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<OrderingContext>()).AsTask());

    public static Task<T> ExecuteDbContextAsync<T>(Func<OrderingContext, IMediator, Task<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<OrderingContext>(), sp.GetService<IMediator>()));

    public static Task<int> InsertAsync<T>(params T[] entities) where T : class
    {
        return ExecuteDbContextAsync(db =>
        {
            foreach (var entity in entities)
            {
                db.Set<T>().Add(entity);
            }
            return db.SaveChangesAsync();
        });
    }

    public static async Task<User> AddNewSuperAdmin()
    {
        var user = new FakeUserBuilder().Build();
        user.AddRole(Role.SuperAdmin());
        await InsertAsync(user);
        return user;
    }

    public static async Task<User> AddNewUser(List<Role> roles)
    {
        var user = new FakeUserBuilder().Build();
        foreach (var role in roles)
            user.AddRole(role);
        
        await InsertAsync(user);
        return user;
    }

    public static async Task<User> AddNewUser(params Role[] roles)
        => await AddNewUser(roles.ToList());
}