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
    [RoutePrefix("api/subjects")]
    public class SubjectsController : ApiController
    {

        //GetAllSubjects
        public IHttpActionResult GetAllSubjects()
        {
            return Ok(SubjectsBL.GetAllSubjects());
        }
        //GetSubjectById
        [Route("GetSubjectById/{subjectId=subjectId:int}")]
        public IHttpActionResult GetSubjectById(int subjectId)
        {
            try
            {
                return Ok(SubjectsBL.GetSubjectById(subjectId));
            }
            catch
            {
                return NotFound();
            }
        }

        //GetOnlyParents
        [Route("GeSubjectOnlyParents")]
        public IHttpActionResult GeSubjectOnlyParents()
        {
            return Ok(BL.SubjectsBL.GeSubjectOnlyParents());
        }
        //GetByParentId
        [Route("GeSubjectByParentId/{parentId}")]
        public IHttpActionResult GeSubjectByParentId(int parentId)
        {
            return Ok(BL.SubjectsBL.GeSubjectByParentId(parentId));
        }
        //GetSubjectByName
        [Route("GetSubjectByName/{subject}")]
        public IHttpActionResult GetSubjectByName(string subject)
        {
            try
            {
                return Ok(SubjectsBL.GetSubjectByName(subject));
            }
            catch
            {
                return NotFound();
            }
        }
        // POST: api/Subject 
        public IHttpActionResult Post([FromBody] Subjects1 subject)
        {
            try
            {
                SubjectsBL.AddSubject(subject);
                return Ok();
            }
            catch(Exception e)
            {
                return Conflict();
            }
        }

        // PUT: api/Subject/5
        //UPDATE
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put([FromBody] Subjects1 subject)
        {
            try
            {
                SubjectsBL.UpdateSubject(subject);
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }

        // DELETE: api/Subject/5
        public IHttpActionResult Delete(Subjects1 subject)
        {
            try
            {
                SubjectsBL.DeleteSubject(subject);
                return Ok(); 
            }
            catch(Exception e)
            {
                return Conflict();
            }
        }

    }
}
