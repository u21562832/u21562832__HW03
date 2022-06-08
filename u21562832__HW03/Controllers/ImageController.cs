using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21562832__HW03.Models;

namespace u21562832__HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Images()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            List<FileModel> fileModels = new List<FileModel>();

            for (int i = 0; i < files.Length; i++)
            {
                FileModel file = new FileModel();
                file.FileName = Path.GetFileName(files[i]);
                fileModels.Add(file);
            }
            return View(fileModels);
        }


        public FileResult Download(string fileName)
        {
            string path = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }


        public ActionResult Delete(string fileName)
        {
            string fullPath = Request.MapPath("~/Media/Images/" + fileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Images");
        }

    }
}