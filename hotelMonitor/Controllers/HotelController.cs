using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hotelMonitor.Models;
using hotelMonitor.Services;
using hotelMonitor.Services.Interface;

namespace hotelMonitor.Controllers
{
    [AllowAnonymous]
    public class HotelController : Controller
    {

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(string taskName, string workerName, string roomName)
        {
            IHotelService hotelService = new HotelService();
            hotelService.AddTask(taskName,workerName,roomName);
            return new JsonResult();
        }

        [HttpGet]
        public ActionResult GetTasks(int index, int rowCount)
        {
            IHotelService hotelService = new HotelService();
            var data = hotelService.GetTasks(index,rowCount);

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = data,
            };
        }
    }
}