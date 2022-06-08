using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21562832__HW03.Models;

namespace u21562832__HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Videos()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/Media/Videos"));

            List<FileModel> fileModels = new List<FileModel>();
            for (int i = 0; i < files.Length; i++)
            {
                FileModel file = new FileModel();
                file.FileName = Path.GetFileName(files[i]);
                fileModels.Add(file);
            }
            return View(fileModels);
        }

        public ActionResult Download(string VideoName)
        {
            string fullName = Server.MapPath("~/Media/Videos/" + VideoName);

            byte[] fileBytes = GetFile(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, VideoName);
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }

        public ActionResult Delete(string VideoName)
        {
            string fullPath = Request.MapPath("~/Media/Videos/" + VideoName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Videos");
        }

    }
}