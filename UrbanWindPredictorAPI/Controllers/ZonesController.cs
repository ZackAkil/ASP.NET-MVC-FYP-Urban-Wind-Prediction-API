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
    public class ZonesController : ApiController
    {
        private urban_wind_prediction_db_entities db = new urban_wind_prediction_db_entities();

        // GET: api/Zones
        public IQueryable<Zone> GetZone()
        {
            return db.Zone;
        }

        // GET: api/Zones/5
        [ResponseType(typeof(Zone))]
        public async Task<IHttpActionResult> GetZone(int id)
        {
            Zone zone = await db.Zone.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }

            return Ok(zone);
        }

        //// PUT: api/Zones/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutZone(int id, Zone zone)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != zone.zoneID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(zone).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ZoneExists(id))
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

        //// POST: api/Zones
        //[ResponseType(typeof(Zone))]
        //public async Task<IHttpActionResult> PostZone(Zone zone)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Zone.Add(zone);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = zone.zoneID }, zone);
        //}

        //// DELETE: api/Zones/5
        //[ResponseType(typeof(Zone))]
        //public async Task<IHttpActionResult> DeleteZone(int id)
        //{
        //    Zone zone = await db.Zone.FindAsync(id);
        //    if (zone == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Zone.Remove(zone);
        //    await db.SaveChangesAsync();

        //    return Ok(zone);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZoneExists(int id)
        {
            return db.Zone.Count(e => e.zoneID == id) > 0;
        }
    }
}