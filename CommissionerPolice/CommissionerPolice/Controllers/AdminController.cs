using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommissionerPolice.Models;
using System.Data;
using System.Data.Entity;
using CommissionerPolice.Abstract;
using CommissionerPolice.Helper;
using Newtonsoft.Json;
using System.Configuration;

namespace CommissionerPolice.Controllers
{
    public class AdminController : Controller
    {
        private readonly IApplicationRepository applicationRepository;

        public AdminController(IApplicationRepository appRepository)
        {
            applicationRepository = appRepository;
        }
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            try
            {
                var data = applicationRepository.CheckLogin(username, password);

                if(data!=null)
                {
                    Session["areaid"] = data.AreaId;
                    Session["username"] = data.FirstName;
                    TempData["Message"] = "Application Submitted Successfully";
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    TempData["Message"] = "Username or password is incorrect";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
        [HttpGet]
        public ActionResult Dashboard()
        {
            try
            {
                if (Session["username"] != null)
                {
                    int area = Convert.ToInt32(Session["areaid"]);

                    var data = applicationRepository.dashboard(area);

                    return View(data);
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpGet]
        public ActionResult ApplicationList()
        {
            try
            {
                if (Session["username"] != null)
                {
                    int area = Convert.ToInt32(Session["areaid"]);
                    ViewBag.policeStattions = applicationRepository.policeStattions().Where(x=>x.AreaId==area);
                    var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Status == "Submitted"&& x.AreaId == area).OrderByDescending(x => x.ApplicantId);
                    ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                    ViewBag.data = data;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult ApplicationList(string policestation)
        {
            try
            {
                if (Session["username"] != null)
                {
                    if (policestation != "0")
                    {
                        int area = Convert.ToInt32(Session["areaid"]);
                        int psid = Convert.ToInt32(policestation);
                        ViewBag.policeStattionsid = psid;
                        ViewBag.policeStattions = applicationRepository.policeStattions().Where(x => x.AreaId == area);
                        var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Ps_Id == psid&& x.Status == "Submitted"&& x.AreaId == area).OrderByDescending(x => x.ApplicantId);
                        ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                        ViewBag.data = data;

                        return View("ApplicationList");
                    }
                    else
                    {
                        int area = Convert.ToInt32(Session["areaid"]);
                        ViewBag.policeStattions = applicationRepository.policeStattions().Where(x => x.AreaId == area); 
                        var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Status == "Submitted" && x.AreaId == area).OrderByDescending(x => x.ApplicantId);
                        ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                        ViewBag.data = data;

                        return View("ApplicationList");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpGet]
        public ActionResult ApproveRejectApplication()
        {
            try
            {
                if (Session["username"] != null)
                {
                    int area = Convert.ToInt32(Session["areaid"]);
                    ViewBag.policeStattions = applicationRepository.policeStattions().Where(x => x.AreaId == area);
                    var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Status != "Submitted"&& x.AreaId == area).OrderByDescending(x => x.ApplicantId);
                    ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                    ViewBag.data = data;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult ApproveRejectApplication(string policestation,string fdate,string tdate)
        {
            try
            {
                if (Session["username"] != null)
                {
                    int area = Convert.ToInt32(Session["areaid"]);

                    if (policestation != "0"&&fdate==""&&tdate=="")
                    {
                        int psid = Convert.ToInt32(policestation);
                        ViewBag.policeStattionsid = psid;
                        ViewBag.policeStattions = applicationRepository.policeStattions().Where(x => x.AreaId == area);
                        var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Ps_Id == psid && x.Status != "Submitted"&& x.AreaId == area).OrderByDescending(x => x.ApplicantId);
                        ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                        ViewBag.data = data;

                        return View("ApproveRejectApplication");
                    }
                    else if (policestation == "0" && fdate != "" && tdate != "")
                    {
                        DateTime fd = Convert.ToDateTime(fdate);
                        DateTime td = Convert.ToDateTime(tdate);
                        ViewBag.fd = fdate;
                        ViewBag.td = tdate;
                        int psid = Convert.ToInt32(policestation);
                        ViewBag.policeStattionsid = psid;
                        ViewBag.policeStattions = applicationRepository.policeStattions().Where(x => x.AreaId == area);
                        var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Status != "Submitted" && x.AreaId == area && (x.Funcdt>=fd&&x.Funcdt<=td)).OrderByDescending(x => x.ApplicantId);
                        ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                        ViewBag.data = data;

                        return View("ApproveRejectApplication");
                    }
                    else if (policestation != "0" && fdate != "" && tdate != "")
                    {
                        DateTime fd = Convert.ToDateTime(fdate);
                        DateTime td = Convert.ToDateTime(tdate);
                        ViewBag.fd = fdate;
                        ViewBag.td = tdate;
                        int psid = Convert.ToInt32(policestation);
                        ViewBag.policeStattionsid = psid;
                        ViewBag.policeStattions = applicationRepository.policeStattions().Where(x => x.AreaId == area);
                        var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Ps_Id == psid && x.AreaId == area && x.Status != "Submitted" && (x.Funcdt >= fd && x.Funcdt <= td)).OrderByDescending(x => x.ApplicantId);
                        ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                        ViewBag.data = data;

                        return View("ApproveRejectApplication");
                    }
                    else
                    {
                        ViewBag.policeStattions = applicationRepository.policeStattions().Where(x => x.AreaId == area);
                        var data = applicationRepository.vw_ApplicationDetails().Where(x => x.Status != "Submitted" && x.AreaId == area).OrderByDescending(x => x.ApplicantId);
                        ViewBag.baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
                        ViewBag.data = data;

                        return View("ApproveRejectApplication");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult ApplicationDetail(int id)
        {
            var data = applicationRepository.sp_ApplicationDetail_Result(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ParticipantDetail(int id)
        {
            var data = applicationRepository.sp_ParticipantDetail_Results(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ApproveReject(int id,string remark, string status)
        {
            var data = applicationRepository.ApproveReject(id,remark,status);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult MarriagePermission(int id)
        {
            var data = applicationRepository.sp_ApplicationDetail_Result(id);

            ViewBag.Name = data.Name;
            ViewBag.fName = data.FathersName;
            ViewBag.address = data.Address;
            ViewBag.date = data.FunctionDate;
            ViewBag.from = data.FromTime;
            ViewBag.to = data.ToTime;
            ViewBag.Duration = data.Duration;
            ViewBag.venue = data.Venue;
            ViewBag.participant = data.TotalParticipant;
            return View();
        }
        [HttpGet]
        public ActionResult FuneralPermission(int id)
        {
            var data = applicationRepository.sp_ApplicationDetail_Result(id);

            ViewBag.Name = data.Name;
            ViewBag.fName = data.FathersName;
            ViewBag.address = data.Address;
            ViewBag.date = data.FunctionDate;
            ViewBag.from = data.FromTime;
            ViewBag.to = data.ToTime;
            ViewBag.venue = data.Venue;
            ViewBag.participant = data.TotalParticipant;
            return View();
        }
    }
}