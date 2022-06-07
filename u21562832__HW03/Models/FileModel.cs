using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace u21562832__HW03.Models
{
    public class FileModel
    {
      //decorator
     [Display(Name = "File Name")]

     //adding attribute
     public string FileName { get; set; }

    //decorator
    [Display(Name = "Browse File")]
     public HttpPostedFileBase[] Files { get; set; }
    }
}