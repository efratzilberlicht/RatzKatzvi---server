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
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        [HttpGet]
        [Route("ConvertItemsTBookPages")]
        public IHttpActionResult ConvertItemsTBookPages()
        {
            try
            {
                return Ok(ItemsBL.ConvertItemsToBookPages());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }
        }
        //GetAllItems
        public IHttpActionResult GetAllItems()
        {
            try
            {
                return Ok(ItemsBL.GetAllItems());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }
        }
        //GetItemById
        [HttpGet]
        [Route("GetById/{itemId}")]
        public IHttpActionResult GetItemById(int itemId)
        {
            try
            {
                return Ok(ItemsBL.GetItemById(itemId));
            }
            catch
            {
                return NotFound();
            }
        }
        //GetItemByName
        [HttpGet]
        [Route("GetAllByName/{item}")]
        public IHttpActionResult GetAllByName(string item)
        {
            try
            {

                Items1 it = ItemsBL.GetItemByName(item);
                return Ok(it);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return NotFound();
            }
        }
        //GetAllVideos
        [Route("GetAllVideos/{kindId}/{pageNum}")]
        public IHttpActionResult GetAllVideos(int kindId, int pageNum)
        {
            try
            {
                List<Items1> items = ItemsBL.GetAllVideos(kindId, pageNum);
                if (items.Count == 0)
                    throw new Exception();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        //GetAllByKind
        [Route("GetAllByKind/{kindId}")]
        public IHttpActionResult GetAllByKind(int kindId)
        {
            try
            {
                List<Items1> items = ItemsBL.GetAllByKind(kindId);
                if (items.Count == 0)
                    throw new Exception();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        //GetAllBySubjectId
        [Route("GetAllBySubjectId/{subjectId}")]
        public IHttpActionResult GetAllBySubjectId(int subjectId)
        {
            try
            {
                List<Items1> items = ItemsBL.GetAllBySubjectId(subjectId);
                if (items.Count == 0)
                    throw new Exception();
                return Ok(items);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Ok();
            }
        }
        //GetItemsBySubjectId
        [Route("GetItemsBySubjectId/{subjectId}")]
        public IHttpActionResult GetItemsBySubjectId(int subjectId)
        {
            try
            {
                ItemsForSubject items = ItemsBL.GetItemsBySubjectId(subjectId);
                if (items == null)
                    throw new Exception();
                return Ok(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Ok();
            }
        }
        //GetItemsBySubjectIdAndKind
        [Route("GetItemsBySubjectIdAndKind/{subjectId}/{kindId}")]
        public IHttpActionResult GetItemsBySubjectIdAndKind(int subjectId, int kindId)
        {
            try
            {
                List<Items1> items = ItemsBL.GetItemsBySubjectIdAndKind(subjectId, kindId);
                if (items.Count == 0)
                    throw new Exception();
                return Ok(items);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Ok();
            }
        }
        //GetItemsForAllSubjects
        [Route("GetItemsForAllSubjects")]
        public IHttpActionResult GetItemsForAllSubjects()
        {
            try
            {
                return Ok(ItemsBL.GetItemsForAllSubjects());
            }catch(Exception ex)
            {
                return NotFound();
            }
        }
        // POST: api/Items
        public IHttpActionResult Post([FromBody] Items1 item)
        {
            try
            {
                ItemsBL.AddItem(item);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict();
            }
        }

        // PUT: api/Items/5
        //UPDATE

        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put([FromBody] Items1 item)
        {
            try
            {
                ItemsBL.UpdateItem(item);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        // DELETE: api/Items/5
        public IHttpActionResult Delete(Items1 item)
        {
            try
            {
                ItemsBL.DeleteItem(item);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict();
            }
        }
    }
}
