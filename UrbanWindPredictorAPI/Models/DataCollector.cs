﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrbanWindPredictorAPI.Models
{
    public abstract class DataCollector
    {
        public DateTime dateTimeCollected { get; set; }
        public string apiKey { get; set; }
        public double windSpeed { get; set; }
        public double windDirection { get; set; }

    }

    public class ScoutDataCollector : DataCollector
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }

    public class StationDataCollector : DataCollector
    {
        public int zoneId { get; set; }
    }
}