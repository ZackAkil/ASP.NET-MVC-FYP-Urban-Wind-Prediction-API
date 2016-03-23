using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UrbanWindPredictorAPI.Models;

using System.Data.Entity.Validation;
using System.Diagnostics;

namespace UrbanWindPredictorAPI.Controllers
{
    public class StationDataController : ApiController
    {
        private urban_wind_prediction_db_entities db = new urban_wind_prediction_db_entities();

        //// GET: api/StationData
        //public IQueryable<StationData> GetStationData()
        //{
        //    return db.StationData;
        //}

        // GET: api/StationData/5
        [ResponseType(typeof(StationData))]
        public IHttpActionResult GetStationData(int id)
        {
            StationData stationData = db.StationData.Find(id);
            if (stationData == null)
            {
                return NotFound();
            }

            return Ok(stationData);
        }

        //// PUT: api/StationData/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutStationData(int id, StationData stationData)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != stationData.stationDataID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(stationData).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StationDataExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/StationData
        [ResponseType(typeof(StationDataCollector))]
        public IHttpActionResult PostStationData(StationDataCollector stationDataCollector)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            stationDataCollector.dateTimeCollected = DateTime.Now;

            int apiKeyId = db.ApiKey.Where(a => a.apiKeyValue == stationDataCollector.apiKey).First().apiKeyID;

            StationData stationData = stationDataCollector.ConvertToDb(apiKeyId);

            db.StationData.Add(stationData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stationData.stationDataID }, stationDataCollector);
        }

        //// DELETE: api/StationData/5
        //[ResponseType(typeof(StationData))]
        //public IHttpActionResult DeleteStationData(int id)
        //{
        //    StationData stationData = db.StationData.Find(id);
        //    if (stationData == null)
        //    {
        //        return NotFound();
        //    }

        //    db.StationData.Remove(stationData);
        //    db.SaveChanges();

        //    return Ok(stationData);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationDataExists(int id)
        {
            return db.StationData.Count(e => e.stationDataID == id) > 0;
        }
    }
}