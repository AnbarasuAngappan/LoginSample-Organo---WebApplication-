using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LoginSample.Models;

namespace LoginSample.Controllers
{
    public class DashBoardController : Controller
    {
        //private designdbEntities db = new designdbEntities();
        // GET: DashBoard
        public ActionResult Index()
        {
                      
            return View();
        }
    
    }
}