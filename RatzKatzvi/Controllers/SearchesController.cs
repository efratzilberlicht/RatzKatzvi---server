using System;
using Dto;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace RatzKatzvi.Controllers
{
    [RoutePrefix("api/Searches")]
    public class SearchesController : ApiController
    {
        [HttpGet]
        [Route("SearchText/{text}")]
        public IHttpActionResult SearchText(string text)
        {
            try
            {
                return Ok(SearchesBL.SearchText(text));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }
        }

        [HttpGet]

        [Route("GetBookById/{bookId}")]

        public IHttpActionResult GetBookById(int itemId)
        {
            try
            {
                return Ok(BookPagesBL.GetBookById(itemId));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]

        [Route("GetPage/{itemId}/{page}")]

        public IHttpActionResult GetPage(int itemId, int page)
        {
            try
            {
                return Ok(BookPagesBL.GetPage(itemId, page));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
