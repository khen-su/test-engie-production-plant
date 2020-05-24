using System;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleSignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to start listening..");
            Console.ReadKey();
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:8888/ws")
                .AddMessagePackProtocol()
                .Build();

            connection.On<string>("message", (message) =>
                Console.WriteLine($"Message:\n{message}\n"));

            connection.StartAsync().GetAwaiter().GetResult();

            Console.WriteLine("Listening. Press a key to quit");
            Console.ReadKey();
        }
    }
}
