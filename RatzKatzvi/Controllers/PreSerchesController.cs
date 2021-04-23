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
    [RoutePrefix("api/preSerches")]
    public class PreSerchesController : ApiController
    {
        //GetAllKeyWords
        [Route("GetAllKeyWords")]
        public IHttpActionResult GetAllKeyWords()
        {
            return Ok(PreSerchesBL.GetAllPreSerches());
        }
        //GetById
        [Route("GetById/{preSercheId=preSercheId:int}")]
        public IHttpActionResult GetById(int preSercheId)
        {
            try
            {
                return Ok(PreSerchesBL.GetById(preSercheId));
            }
            catch
            {
                return NotFound();
            }
        }
        //GetWordIdByName

        [Route("GetAllByName/{preSearch=preSearch:string}")]
        public IHttpActionResult GetWordIdByName(string preSearch)
        {
            try
            {
               List<PreSerches1> presearch = PreSerchesBL.GetWordIdByName(preSearch);
                if (preSearch.Count()>0)
                    return Ok(presearch);
                return Ok(0);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        //GetAllByItemId
        [Route("GetAllByItem/{itemId}")]
        public IHttpActionResult GetAllByItemId(int itemId)
        {

            //   {

            // {
            //  return Ok(PreSerchesBL.GetAllByItemId(itemId));
            //Racheli change - PreSerchesBL.GetAllByItemId doing error
            return BadRequest();
        }

        // POST: api/PreSerches
        public IHttpActionResult Post([FromBody] PreSerches1 preSerch)
        {
            try
            {
                PreSerchesBL.AddPreSerch(preSerch);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }

        // PUT: api/PreSerches
        //UPDATE
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put([FromBody] PreSerches1 preSerch)
        {
            try
            {
                PreSerchesBL.UpdatePreSerch(preSerch);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
        // DELETE: api/PreSerches/5
        public IHttpActionResult Delete([FromBody] PreSerches1 preSerch)
        {
            try
            {
                PreSerchesBL.DeletePreSerch(preSerch);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }
    }
}

