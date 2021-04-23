//using ICSharpCode.Decompiler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Web;
using System.Web.Http;

namespace RatzKatzvi.Controllers
{
    [RoutePrefix("api/Files")]
    public class FilesController : ApiController
    {
        [HttpGet]
        [Route("GetCvText")]
        public IHttpActionResult GetCvText()
        {
            try
            {
                return Ok(BL.FilesBL.GetTextFromFile("CV"));
            }
            catch (Exception ex) { return NotFound(); }
        }
        //GetTextFromFile
        [HttpGet]
        [Route("GetTextFromFile/{folderName}/{fileName}")]
        public IHttpActionResult GetTextFromFile(string folderName, string fileName)
        {
            try
            {
                return Ok(BL.FilesBL.GetTextFromFile(folderName,fileName));
            }
            catch (Exception ex) { return NotFound(); }
        }
        [HttpGet]
        [Route("GetCVWithName/{name}")]
        public IHttpActionResult GetCVWithName(string name)
        {
            try
            {
                return Ok(BL.FilesBL.GetAllFilesWithName(name, "CV/"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetAllFilesWithName/{name}")]
        public IHttpActionResult GetAllFilesWithName(string name)
        {
            try
            {
                return Ok(BL.FilesBL.GetAllFilesWithName(name, ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetVideoWithName/{name}")]
        public IHttpActionResult GetVideoWithName(string name)
        {
            try
            {
                return Ok(BL.FilesBL.GetAllFilesWithName(name, "Video/"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetLessonWithName/{name}")]
        public IHttpActionResult GetLessonWithName(string name)
        {
            try
            {
                return Ok(BL.FilesBL.GetAllFilesWithName(name, "Lesson/"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetImageWithName/{name}")]
        public IHttpActionResult GetImageWithName(string name)
        {
            try
            {
                return Ok(BL.FilesBL.GetAllFilesWithName(name, "Image/"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }
       

        //[HttpGet]
        //[Route("GetTextFromFile")]
        //public IHttpActionResult GetTextFromFile()
        //{
        //    try
        //    {
        //        return Ok(BL.FilesBL.GetTextFromFile());
        //    }
        //    catch (Exception ex) { return NotFound(); }
        //}


        //----POST----
        public IHttpActionResult Post()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //TODO
                //change the third arg in th next row to the correct type
                string itemName = BL.FilesBL.SaveFile(httpRequest,"Book", 1);
                // לשנות את ItemKind בכל פונקציה למה שמתאים
                BL.ItemsBL.AddItem(new Dto.Items1 { EnableSearch = true, ItemKind = 1, ItemName = itemName });
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST CV
        [HttpPost]
        [Route("PostCV")]
        public IHttpActionResult PostCV()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //TODO
                //change the third arg in th next row to the correct type
                return Ok(BL.FilesBL.SaveFile(httpRequest, "CV/", 0));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST Video
        [HttpPost]
        [Route("PostVideo")]
        public IHttpActionResult PostVideo()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //TODO
                //change the third arg in th next row to the correct type
                return Ok(BL.FilesBL.SaveFile(httpRequest, "Video/", (int)Dto.EnumItemsKinds.Video));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST Lesson
        [HttpPost]
        [Route("PostLesson")]
        public IHttpActionResult PostLesson()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                return Ok(BL.FilesBL.SaveFile(httpRequest, "Lesson/", (int)Dto.EnumItemsKinds.Lesson));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST LessonSummary
        [HttpPost]
        [Route("PostLessonSummary")]
        public IHttpActionResult PostLessonSummary()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //TODO
                //change the third arg in th next row to the correct type
                return Ok(BL.FilesBL.SaveFile(httpRequest, "LessonSummary/", (int)Dto.EnumItemsKinds.LessonSummary));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST Bookmarks
        [HttpPost]
        [Route("PostBookmarks")]
        public IHttpActionResult PostBookmarks()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //TODO
                //change the third arg in th next row to the correct type
                return Ok(BL.FilesBL.SaveFile(httpRequest, "Bookmarks/", (int)Dto.EnumItemsKinds.Bookmarks));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST Image
        [HttpPost]
        [Route("PostImage")]
        public IHttpActionResult PostImage()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //TODO
                //change the third arg in th next row to the correct type
                return Ok(BL.FilesBL.SaveFile(httpRequest, "Image/", (int)Dto.EnumItemsKinds.Image));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        //POST Book
        [HttpPost]
        [Route("PostBook")]
        public IHttpActionResult PostBook()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //TODO
                //change the third arg in th next row to the correct type
                return Ok(BL.FilesBL.SaveFile(httpRequest, "Book/", (int)Dto.EnumItemsKinds.Book));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }


        //DOWNLOAD

        /// <summary>
        /// send the file name with suffix
        /// </summary>
        [HttpGet]
        [Route("DownloadFile/{fileName}")]
        public HttpResponseMessage DownloadFile( string fileName)
        {
            return BL.FilesBL.DownloadFile("", fileName);
        }
        [HttpGet]
        [Route("DownloadCV/{fileName}")]
        public HttpResponseMessage DownloadCV(string fileName)
        {
            return BL.FilesBL.DownloadFile("CV/", fileName);
        }
        [HttpGet]
        [Route("DownloadVideo/{fileName}")]
        public HttpResponseMessage DownloadVideo(string fileName)
        {
            return BL.FilesBL.DownloadFile("Video/", fileName);
        }
        [HttpGet]
        [Route("DownloadLesson/{fileName}")]
        public HttpResponseMessage DownloadLesson(string fileName)
        {
            return BL.FilesBL.DownloadFile("Lesson/", fileName);
        }
        [HttpGet]
        [Route("DownloadImage/{fileName}")]
        public HttpResponseMessage DownloadImage(string fileName)
        {
            return BL.FilesBL.DownloadFile("Image/", fileName);
        }
        [HttpGet]
        [Route("DownloadBook/{fileName}")]
        public HttpResponseMessage DownloadBook(string fileName)
        {
            return BL.FilesBL.DownloadFile("Book/", fileName);
        }

        //DELETE
        /// <summary>
        /// send the file name with suffix
        /// </summary>
        public IHttpActionResult Delete(string fileName)
        {
            bool result = BL.FilesBL.Delete("",fileName);
            if (result)
                return Ok(result);
            return NotFound();
        }
        [Route("DeleteCV")]
        public IHttpActionResult DeleteCV(string fileName)
        {
            try
            {
                bool result = BL.FilesBL.Delete("CV/", fileName);
                if (result)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST Video
        [HttpDelete]
        [Route("DeleteVideo")]
        public IHttpActionResult DeleteVideo(string fileName)
        {
            try
            {
                bool result = BL.FilesBL.Delete("Video/", fileName);
                if (result)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST Lesson
        [HttpDelete]
        [Route("DeleteLesson")]
        public IHttpActionResult DeleteLesson(string fileName)
        {
            try
            {
                bool result = BL.FilesBL.Delete("Lesson/", fileName);
                if (result)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        //POST Image
        [HttpDelete]
        [Route("DeleteImage")]
        public IHttpActionResult DeleteImage(string fileName)
        {
            try
            {
                bool result = BL.FilesBL.Delete("Image/", fileName);
                if (result)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        //POST Image
        [HttpDelete]
        [Route("DeleteBook")]
        public IHttpActionResult DeleteBook(string fileName)
        {
            try
            {
                bool result = BL.FilesBL.Delete("Book/", fileName);
                if (result)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
    }
}