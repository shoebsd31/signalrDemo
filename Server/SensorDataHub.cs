using Common.models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Repository;
using System;
using System.Threading.Tasks;

namespace Server
{
    public class SensorDataHub : Hub
    {
        private IAction action;
        public SensorDataHub(IAction _action)
        {
            action = _action;
        }
        public async Task SendMessage(string device, string deviceData)
        {
            Console.WriteLine($"send message recieved from {device} : {deviceData}");
            var iotMessage =  JsonConvert.DeserializeObject<IOTMessage>(deviceData);
            action.Save(iotMessage);
            await Clients.All.SendAsync("ReceiveMessage", device, iotMessage);
        }
    }
}
