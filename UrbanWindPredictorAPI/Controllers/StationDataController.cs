using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UrbanWindPredictorAPI.Models;

namespace UrbanWindPredictorAPI.Controllers
{
    public class StationDataController : ApiController
    {
        private urban_wind_prediction_db_entities db = new urban_wind_prediction_db_entities();

        // GET: api/StationData
        public IQueryable<StationData> GetStationData()
        {
            return db.StationData;
        }

        // GET: api/StationData/5
        [ResponseType(typeof(StationData))]
        public async Task<IHttpActionResult> GetStationData(int id)
        {
            StationData stationData = await db.StationData.FindAsync(id);
            if (stationData == null)
            {
                return NotFound();
            }

            return Ok(stationData);
        }

        //// PUT: api/StationData/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutStationData(int id, StationData stationData)
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
        //        await db.SaveChangesAsync();
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

        //// POST: api/StationData
        //[ResponseType(typeof(StationData))]
        //public async Task<IHttpActionResult> PostStationData(StationData stationData)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.StationData.Add(stationData);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = stationData.stationDataID }, stationData);
        //}

        //// DELETE: api/StationData/5
        //[ResponseType(typeof(StationData))]
        //public async Task<IHttpActionResult> DeleteStationData(int id)
        //{
        //    StationData stationData = await db.StationData.FindAsync(id);
        //    if (stationData == null)
        //    {
        //        return NotFound();
        //    }

        //    db.StationData.Remove(stationData);
        //    await db.SaveChangesAsync();

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