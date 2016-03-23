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

namespace UrbanWindPredictorAPI.Controllers
{
    public class ScoutDataController : ApiController
    {
        private urban_wind_prediction_db_entities db = new urban_wind_prediction_db_entities();

        // GET: api/ScoutData
        public IQueryable<ScoutData> GetScoutData()
        {
            return db.ScoutData;
        }

        // GET: api/ScoutData/5
        [ResponseType(typeof(ScoutData))]
        public IHttpActionResult GetScoutData(int id)
        {
            ScoutData scoutData = db.ScoutData.Find(id);
            if (scoutData == null)
            {
                return NotFound();
            }

            return Ok(scoutData);
        }

        //// PUT: api/ScoutData/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutScoutData(int id, ScoutData scoutData)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != scoutData.scoutDataID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(scoutData).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ScoutDataExists(id))
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

        // POST: api/ScoutData
        [ResponseType(typeof(ScoutDataCollector))]
        public IHttpActionResult PostScoutData(ScoutDataCollector scoutDataCollector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            scoutDataCollector.dateTimeCollected = DateTime.Now;

            int apiKeyId = db.ApiKey.Where(a => a.apiKeyValue == scoutDataCollector.apiKey).First().apiKeyID;

            ScoutData scoutData = scoutDataCollector.ConvertToDb(apiKeyId);

            db.ScoutData.Add(scoutData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = scoutData.scoutDataID }, scoutDataCollector);
        }

        //// DELETE: api/ScoutData/5
        //[ResponseType(typeof(ScoutData))]
        //public IHttpActionResult DeleteScoutData(int id)
        //{
        //    ScoutData scoutData = db.ScoutData.Find(id);
        //    if (scoutData == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ScoutData.Remove(scoutData);
        //    db.SaveChanges();

        //    return Ok(scoutData);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScoutDataExists(int id)
        {
            return db.ScoutData.Count(e => e.scoutDataID == id) > 0;
        }
    }
}