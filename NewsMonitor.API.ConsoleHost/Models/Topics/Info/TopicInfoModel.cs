﻿using System;
using NewsMonitor.API.Models;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.Topics.Info
{
    public class TopicInfoModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("date"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}