using GemBox.Document;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
//using System.Web;
//using ICSharpCode.Decompiler.Util;
using System.Configuration;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
//using Grpc.Core;

namespace DL
{
    public static class FilesDL
    {
        public static string GetTextFromFile(string filePath)
        {
            try
            {
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                // Load a document from a Stream contained in FileUpload control.
                var document = DocumentModel.Load(new MemoryStream(File.ReadAllBytes(filePath)), LoadOptions.DocxDefault);

                // Initialize new StringBuilder.
                var sb = new StringBuilder();

                // Iterate over all paragraphs in the document and append new line to StringBuilder.
                foreach (Paragraph paragraph in document.GetChildElements(true, ElementType.Paragraph))
                {
                    // Iterate over all text elements in the parent paragraph and append its text to StringBuilder.
                    foreach (Run run in paragraph.GetChildElements(true, ElementType.Run))
                        sb.Append(run.Text);
                    sb.AppendLine();
                }
                return sb.ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static string SaveFile(HttpRequest files, string specificFolder)
        {
            try
            {
                if (files.Files.Count > 0)
                {
                    foreach (string file in files.Files)
                    {
                        var postedFile = files.Files[file];
                        string FolderPath = "~\\Files\\" + specificFolder;
                        DirectoryInfo FolderDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(FolderPath));
                        if (!FolderDir.Exists)
                            FolderDir.Create();
                        string filePath = Path.Combine(HttpContext.Current.Server.MapPath(FolderPath), postedFile.FileName);
                        if (!File.Exists(filePath))
                        {
                            try
                            {
                                postedFile.SaveAs(filePath);
                                return Path.GetFileName(filePath);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                return "Error: Fail Uploading File";
                            }
                        }
                        return "Error: File is Exist";
                    }
                }

                return "";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return "Error";
            }
        }
        public static List<string> GetAllFilesWithName(string name, string specificFolder)
        {
            string[] filesArray = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Files/" + specificFolder), "*.*", SearchOption.AllDirectories);
            List<string> resultFiles = new List<string>();
            for (int i = 0; i < filesArray.Length; i++)
            {
                var split = filesArray[i].Split('\\');
                if (split[split.Length - 1].Contains(name))
                {
                    resultFiles.Add(filesArray[i]);
                }
            }
            return resultFiles;
        }
        public static HttpResponseMessage DownloadFile(string fileFolder, string fileName)
        {
            if ((System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/Files/" + fileFolder + "/" + fileName))))

                using (var webClient = new WebClient())
                {
                    try
                    {
                        byte[] data = webClient.DownloadData(HttpContext.Current.Server.MapPath("~/Files/" + fileFolder + "/" + fileName));
                        var ms = new MemoryStream(data);

                        var result = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(ms.ToArray())
                        };
                        result.Content.Headers.ContentDisposition =
                            new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = fileName
                            };
                        result.Content.Headers.ContentType =
                            new MediaTypeHeaderValue("application/octet-stream");

                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            return new HttpResponseMessage(HttpStatusCode.NotFound);

        }
        public static bool Delete(string folderName, string fileName)
        {
            if ((System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/Files/" + folderName + fileName))))
            {
                try
                {
                    File.Delete(HttpContext.Current.Server.MapPath("~/Files/" + folderName + fileName));
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
            return false;
        }
    }
}

