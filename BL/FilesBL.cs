using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

using System.Web;

namespace BL
{
    public static class FilesBL
    {
        public static string GetTextFromFile(string folderName, string fileName = null)
        {
            string FolderPath = HttpContext.Current.Server.MapPath("~\\Files\\" + folderName + "\\");
            DirectoryInfo FolderDir = new DirectoryInfo(FolderPath);
            if (!FolderDir.Exists)
            {
                return "Not Found Folder";
            }
            var filePath = "";
            if (fileName == null)
                filePath = Directory.GetFiles(FolderPath).OrderByDescending(file => File.GetLastWriteTime(file)).First();
            else
            {
                var files = Directory.GetFiles(FolderPath);
                bool flag = true;
                for (int i = 0; i < files.Length && flag; i++)
                {
                    if (Path.GetFileName(files[i]) == fileName)
                    {
                        filePath = files[i];
                        flag = false;
                    }
                }
                if (filePath == null)
                    return "Can't find the file";
            }
            return DL.FilesDL.GetTextFromFile(filePath);
        }
        public static string SaveFile(HttpRequest files, string specificFolder, int ItemKind)
        {
            try
            {
                var result = DL.FilesDL.SaveFile(files, specificFolder);
                if (!result.Contains("Error"))
                {
                    ItemsBL.AddItem(new Dto.Items1 { EnableSearch = true, ItemKind = ItemKind, ItemName = result ,ContextUrl=result});
                    return "Success";
                }
                return result;
            }
            catch (Exception ex)
            {
                return "Error Saving File";
            }
        }
        public static List<string> GetAllFilesWithName(string name, string specificFolder)
        {
            return DL.FilesDL.GetAllFilesWithName(name, specificFolder);
        }
        public static HttpResponseMessage DownloadFile(string fileFolder, string fileName)
        {
            return DL.FilesDL.DownloadFile(fileFolder, fileName);
        }
        public static bool Delete(string folderName, string fileName)
        {
            return DL.FilesDL.Delete(folderName, fileName);
        }
    }
}
