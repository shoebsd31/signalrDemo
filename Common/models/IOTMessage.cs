
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.models
{
    public class IOTMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        public dynamic Data { get; set; }
    }

    public class SensorData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("sensor1")]
        public string Sensor1 { get; set; }

        [JsonProperty("sensor2")]
        public string Sensor2 { get; set; }

        [JsonProperty("sensor3")]
        public string Sensor3 { get; set; }

        [JsonProperty("sensor4")]
        public string Sensor4 { get; set; }
    }

}
