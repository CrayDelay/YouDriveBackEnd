namespace Billing.Domain;

using DriversBlogManagement.Databases;
using DriversBlogManagement.Domain.Drivers.Models;
using DriversBlogManagement.Domain.Drivers.Services;
using DriversBlogManagement.Services;
using MassTransit;
using SharedKernel.Messages;
using System.Threading;
using System.Threading.Tasks;


public sealed class SyncDriver : IConsumer<IDriverUpdated>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SyncDriver(IDriverRepository drv_repo, IUnitOfWork uow)
    {
        _driverRepository = drv_repo;
        _unitOfWork = uow;
    }

    public async Task Consume(ConsumeContext<IDriverUpdated> context)
    { 
        Console.WriteLine("WE GOT MESSAGE FORM QUEUE");
            Console.WriteLine("Id of driver => " + context.Message.DriverId);
            Console.WriteLine("FirstName of driver => " + context.Message.FirstName);
            Console.WriteLine("LastName of driver => " + context.Message.LastName);

        context.Message.DriverId = Guid.Parse("7FA72F44-2825-2B26-D190-152DFADF6D0D");
        var resieved_message = context.Message;

        var driverToUpdate = await _driverRepository.GetById(resieved_message.DriverId);
        if (driverToUpdate == null) { return; }

        // Создать экземпляр DriverForUpdate на основе данных из ивента
        var driverForUpdate = new DriverForUpdate
        {
            FirstName = context.Message.FirstName,
            LastName = context.Message.LastName
        };

        driverToUpdate.Update(driverForUpdate);

        _driverRepository.Update(driverToUpdate);
        await _unitOfWork.CommitChanges();

        Console.WriteLine("JOB IS DONE");
    }
}