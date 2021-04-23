using BL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RatzKatzvi.Controllers
{
    [RoutePrefix("api/lastLocation")]
    public class LastLocationController : ApiController
    {
        // GET: api/LastLocation
        //GetAllLastLocations
        public IHttpActionResult GetAllLastLocations()
        {
            return Ok(LastLocationBL.GetAllLastLocations());
        }
        //GetLastLocationById
        [Route("GetLastLocationById/{lastLocationId}")]
        public IHttpActionResult GetLastLocationById(int lastLocationId)
        {
            try
            {
                return Ok(LastLocationBL.GetLastLocationById(lastLocationId));
            }
            catch
            {
                return NotFound();
            }
        }
        //GetByUserId
        [Route("GetByUserId/{userId}")]
        public IHttpActionResult GetByUserId(int userId)
        {
            try
            {
                return Ok(LastLocationBL.GetByUserId(userId));
            }
            catch
            {
                return NotFound();
            }
        }
        //GetLastLocationByFullDate
        [Route("GetLastLocationByFullDate/{date}")]
        public IHttpActionResult GetByUserId(DateTime date)
        {
            try
            {
                return Ok(LastLocationBL.GetLastLocationByFullDate(date));
            }
            catch
            {
                return NotFound();
            }
        }
        //GetLastLocationByMonth
        [Route("GetLastLocationByMonth/{month}/{year}")]
        public IHttpActionResult GetByUserId(int month,int year)
        {
            try
            {
                return Ok(LastLocationBL.GetLastLocationByMonth(month,year));
            }
            catch
            {
                return NotFound();
            }
        }
        //GetLastLocationByYear
        [Route("GetLastLocationByYear/{year}")]
        public IHttpActionResult GetLastLocationByYear(int year)
        {
            try
            {
                return Ok(LastLocationBL.GetLastLocationByYear(year));
            }
            catch
            {
                return NotFound();
            }
        }
        // PUT: api/LastLocation
        //UPDATE
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put([FromBody] LastLocation1 lastLocation)
        {
            try
            {
                LastLocationBL.UpdateLastLocation(lastLocation);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        // POST: api/LastLocation
        public IHttpActionResult Post([FromBody] LastLocation1 lastLocation)
        {
            try
            {
                LastLocationBL.AddLastLocation(lastLocation);
                return Ok();
            }
            catch(Exception ex)
            {
                return Conflict();
            }
        }

        // DELETE: api/LastLocation/5
        public IHttpActionResult Delete(LastLocation1 lastLocation)
        {
            try
            {
                LastLocationBL.DeleteLastLocation(lastLocation);
                return Ok();
            }
            catch(Exception ex)
            {
                return Conflict();
            }
        }

    }
}
