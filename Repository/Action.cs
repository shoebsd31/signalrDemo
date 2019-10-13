using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.models;

namespace Repository
{
    public class Action : IAction
    {
        private SensorDBContext sensorDBContext;
        public Action(SensorDBContext _sensorDBContext)
        {
            sensorDBContext = _sensorDBContext;
        }
        public void Save(IOTMessage message)
        {
            switch(message.Type)
            {
                case "SensorData":
                    sensorDBContext.SensorData.Add((SensorData)message.Data);
                    break;
                default:break;
            }
            sensorDBContext.SaveChanges();
        }
    }
}
