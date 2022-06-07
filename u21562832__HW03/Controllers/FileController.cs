using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21562832__HW03.Models;

namespace u21562832__HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Files()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);

        }

        [HttpPost]
        public ActionResult Files(HttpPostedFileBase files)
        {

            if (files != null && files.ContentLength > 0)
            {

                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);

                files.SaveAs(path);
            }
            return RedirectToAction("Files");

        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);
            return RedirectToAction("Index");
        }
    }

}