﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceMonitoring.Models;
namespace AttendanceMonitoring.Controllers
{
    public class HomeController : Controller
    {
        Employee emp = new Employee();
        Attendance att = new Attendance();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult FindEmployee(Attendance _att)
        {
            att.AddAttendance(new Attendance(Convert.ToDateTime(DateTime.Now).ToShortDateString(), _att.EmpID, Convert.ToDateTime(DateTime.Now).ToShortTimeString()));
            return Json(emp.FindEmployee(_att.EmpID), JsonRequestBehavior.AllowGet);
        }
    }
}