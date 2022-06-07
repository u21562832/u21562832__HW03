using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21562832__HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
   
        }

        public ActionResult AboutMe()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string Upload)
        {
     if (files == null || Upload == null)
            {
                ViewBag.Message = "Please make sure that file and file type is selected";
            }
            else if (Upload == "Image")
            {
                // Upload  image to the image folder               
                string name = Path.GetFileName(files.FileName);
                string path = "~/Media/Images/" + name;
                files.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;
            }
            else if (Upload == "Video")
            {
                // Upload video the vidoes folder
                string name = Path.GetFileName(files.FileName);
                string path = "~/Media/Videos/" + name;
                files.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;
            }
            else if (Upload == "Document")
            {
                // Upload document to the documents folder
                string name = Path.GetFileName(files.FileName);
                string path = "~/Media/Documents/" + name;
                files.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;

            }
            return View();

        }
    }
  


    }
