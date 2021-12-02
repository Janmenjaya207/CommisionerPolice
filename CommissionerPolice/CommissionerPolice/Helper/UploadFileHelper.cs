using CommissionerPolice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommissionerPolice.Helper
{
    public static class UploadFileHelper
    {
        internal static CommissionerPolice.Models.File SaveFileIntoLocal(HttpPostedFileBase file, FileTypes fileType)
        {
            var fileId = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            var ext = file.FileName.Split('.');
            if (!(System.IO.Directory.Exists(HttpContext.Current.Server.MapPath($"~/{ConfigurationManager.AppSettings["FileUploadFolder"]}"))))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath($"~/{ConfigurationManager.AppSettings["FileUploadFolder"]}"));
            }
            
            var path =Path.Combine(HttpContext.Current.Server.MapPath($"~/{ConfigurationManager.AppSettings["FileUploadFolder"]}"),
                                       Path.GetFileName(fileId));

            if (ext.Length >= 2)
                path = $"{path}.{ext[ext.Length - 1]}";

            file.SaveAs(path);

            CommissionerPolice.Models.File fileObject = new CommissionerPolice.Models.File()
            {
                FileId = fileId,
                CreatedOn = DateTime.Now,
                FileName = file.FileName,
                FileLocation = "FileUploaded",
                FileTypeId = (int)fileType,
                FileSize = file.ContentLength,
                CreatedBy = "APPLICANT",
                FileExtension = Path.GetExtension(path),
                ContentType = file.ContentType,
                SystemFileName = $"{fileId}{Path.GetExtension(path)}"
            };
            return fileObject;
        }
    }
}