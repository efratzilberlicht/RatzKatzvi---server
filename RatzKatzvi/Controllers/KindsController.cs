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
    [RoutePrefix("api/kinds")]
    public class KindsController : ApiController
    {

        //GetAllKinds
        public IHttpActionResult GetAllKinds()
        {
            return Ok(KindsBL.GetAllKinds());
        }
        //GetKindById
        [Route("GetKindById/{kind}")]
        public IHttpActionResult GetKindById(int kind)
        {
            try
            {
                return Ok(KindsBL.GetKindById(kind));
            }
            catch
            {
                return NotFound();
            }
        }
        //GetKindByName
        [Route("GetKindByName/{kind}")]
        public IHttpActionResult GetKindByName(string kind)
        {
            try
            {
                return Ok(KindsBL.GetKindByName(kind));
            }
            catch
            {
                return NotFound();
            }
        }
        // POST: api/Kinds
        public IHttpActionResult Post([FromBody] Kinds1 kind)
        {
            try
            {
                KindsBL.AddKind(kind);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }


        // PUT: api/Kinds/5
        //UPDATE
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put([FromBody] Kinds1 kind)
        {
            try
            {
                KindsBL.UpdateKind(kind);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/Kinds/5
        public IHttpActionResult Delete(Kinds1 kind)
        {
            try
            {
                KindsBL.DeleteKind(kind);
                return Ok();
            }
            catch(Exception ex)
            {
                return Conflict();
            }
        }

    }
}
