using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Spatial;

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

        public ScoutData convertToDb(int confirmedApiKeyId)
        {
            ScoutData convert = new ScoutData();
            convert.apiKeyID = confirmedApiKeyId;
            convert.dateTimeCollected = this.dateTimeCollected;
            convert.windDirection = System.Convert.ToDecimal(this.windDirection);
            convert.windSpeed = System.Convert.ToDecimal(this.windSpeed);

            var point = string.Format("POINT({1} {0})", latitude, longitude);
            convert.locationPoint = DbGeometry.FromText(point);

            return convert;
        }
    }

    public class StationDataCollector : DataCollector
    {
        public int zoneId { get; set; }

        public StationData convertToDb(int confirmedApiKeyId)
        {
            StationData convert = new StationData();
            convert.apiKeyID = confirmedApiKeyId;
            convert.dataTimeCollected = this.dateTimeCollected;
            convert.windDirection = System.Convert.ToDecimal(this.windDirection);
            convert.windSpeed = System.Convert.ToDecimal(this.windSpeed);
            convert.zoneID = this.zoneId;

            return convert;
        }
    }
}