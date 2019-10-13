using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IOTDataSender
{
    public class Sendor
    {
        HubConnection connection;
        public async void Initialize()
        {
            connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/SensorDataHub")
            .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            await connection.StartAsync();
        }

        public async void SendMessage()
        {
            var client = "sensorclient";
            var message = "{'timestamp': 1545581650234,'type': 'SensorData','id': '7e8b93c3-44bb-425f-a8d8-f48bb8e58365','data': {'sensor1': 12.3,'sensor2': 10.0,'sensor3': 12.3,'sensor4': 'open'}}";
            await connection.InvokeAsync("SendMessage", client
                  , message);
            Console.WriteLine($"sending data from: {client} : {message}");
        }

    }
}

