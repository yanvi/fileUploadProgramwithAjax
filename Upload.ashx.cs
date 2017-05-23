using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {
        private static DirectoryInfo UploadFilePath = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Upload"));
        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;
            if (context.Request.Files.Count > 0)
            {

                if (UploadFilePath.GetFiles().Count() > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        string newFileName = GetNewFileName(System.IO.Path.GetFileNameWithoutExtension(files[i].FileName));
                        HttpPostedFile file = files[i];
                        string path = context.Server.MapPath("~/Upload/" + newFileName + Path.GetExtension(files[i].FileName));
                        file.SaveAs(path);
                    }
                }
            }
        }

        private bool IsExistFile(string fileName)
        {
            if (UploadFilePath.GetFiles().Count() > 0)
            {
                if (UploadFilePath.GetFiles().Where(p => Path.GetFileNameWithoutExtension(p.FullName).Equals(fileName)).FirstOrDefault() != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        private string GetNewFileName(string fileName)
        {
            while (IsExistFile(fileName))
            {
                fileName = fileName + "_1";
            }
            return fileName;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}