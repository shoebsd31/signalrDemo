using Common.models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace IOTDataListener
{
    public class Listener
    {
        HubConnection connection;
        public async void Initialize()
        {
            connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/SensorDataHub")
            .Build();

            connection.Closed += async (error) =>
            {
                Console.WriteLine("connection closed");
            };

            await connection.StartAsync();
        }

        public void Close()
        {
            connection.StopAsync();
        }

        public void RecieveMessage()
        {
            connection.On<string, IOTMessage>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"Listener 2 recieved from : {user} message : {message.Type}");
            });
        }
    }
}
