// See https://aka.ms/new-console-template for more information

using MessageSender.QueueProvider;
using MessageSender.QueueProvider.Abstractions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddQueuesServices(options =>
        {
            options.QueueName = "";
            options.ConnectionString = "";
        });
var serviceBuilder = services.BuildServiceProvider();
var queueProvider = serviceBuilder.GetRequiredService<IQueueProvider>();
await queueProvider.PushToQueueAsync<string>("Hello Queue");

var messageFromQueue = await queueProvider.ReceiveFromQueueAsync<string>();

Console.WriteLine("Received Message");
