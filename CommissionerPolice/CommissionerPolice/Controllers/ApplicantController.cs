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
    public class ApplicantController : Controller
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicantController(IApplicationRepository appRepository)
        {
            applicationRepository = appRepository;
        }
        // GET: Applicant
        #region------------------Application Submit--------------------
        [HttpGet]
        public ActionResult Application()
        {
            ViewBag.policeStattions = applicationRepository.policeStattions().Where(x=>x.AreaId==1);
            ViewBag.policeStattions2 = applicationRepository.policeStattions().Where(x => x.AreaId == 2);
            ViewBag.Areas = applicationRepository.Areas();
            return View();
        }
        [HttpPost]
        public ActionResult Application(string functype,string appname,string fname,string phone,string address,string funcdate,string timefrom,
            string timeto,string venue,string sitting,string workplace,string totalparticipant, HttpPostedFileBase idproof, HttpPostedFileBase addressproof,
            string[] partname,string[] age,string[] mobileno,string[] dist,string Duration,string policestation,string[] from,string area,string policestation2) 
        {
            try
            {
                string fileloc = "/FileUploaded/";

                ApplicationDetail applicationDetail = new ApplicationDetail();
                if (idproof != null)
                {
                    var id_proof = UploadFileHelper.SaveFileIntoLocal(idproof, FileTypes.IdProof);
                    applicationDetail.IdProof = fileloc + id_proof.SystemFileName;
                }
                if (addressproof != null)
                {
                    var address_proof = UploadFileHelper.SaveFileIntoLocal(addressproof, FileTypes.ResidentProof);
                    applicationDetail.AddressProof = fileloc + address_proof.SystemFileName;
                }
                
                applicationDetail.AreaId = Convert.ToInt32(area);
                applicationDetail.Duration = Duration;
                applicationDetail.FunctionType = functype;
                applicationDetail.Name = appname;
                applicationDetail.FathersName = fname;
                applicationDetail.MobileNo = phone;
                applicationDetail.Address = address;
                if (area == "1")
                {
                    applicationDetail.Ps_Id = Convert.ToInt32(policestation);
                }
                else
                {
                    applicationDetail.Ps_Id = Convert.ToInt32(policestation2);
                }
                applicationDetail.FunctionDate = Convert.ToDateTime(funcdate);
                applicationDetail.FromTime = timefrom;
                applicationDetail.ToTime = timeto;
                applicationDetail.Venue = venue;
                applicationDetail.TotalSittingCapacity = Convert.ToInt32(sitting);
                applicationDetail.WorkingPlaceSize = workplace;
                applicationDetail.TotalParticipant = Convert.ToInt32(totalparticipant);


                List<ParticipantDetail> ParticipantDetail = new List<ParticipantDetail>();
                if (partname.Length > 0)
                {
                    for (int i = 0; i < partname.Length; i++)
                    {
                        ParticipantDetail obj;
                        obj = new ParticipantDetail();
                        obj.ParticipantName = partname[i];
                        obj.Age = Convert.ToInt32(age[i]);
                        obj.MobileNo = mobileno[i];
                        obj.PermissionFrom = from[i];                        
                        ParticipantDetail.Add(obj);
                    }
                }

                int count = applicationRepository.SaveApplication(applicationDetail, ParticipantDetail);

                if(count>0)
                {
                    TempData["Message"] = "Application Submitted Successfully";
                    return RedirectToAction("Application", "Applicant");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Application", "Applicant");
            }
            return View();
        }
        [HttpGet]
        public ActionResult MarriagePermission(string appno)
        {
            int id = Convert.ToInt32(EncodeDecode.Base64Decode(appno));
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
        public ActionResult FuneralPermission(string appno)
        {
            int id = Convert.ToInt32(EncodeDecode.Base64Decode(appno));
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
        [HttpPost]
        public ActionResult CheckDate(string funcdate,string functype)
        {
            DateTime today = DateTime.Now.Date;
            DateTime functiondate = Convert.ToDateTime(funcdate).Date;
            bool data = false;
            if (funcdate == "Marriage")
            {
                if ((functiondate - today).Days >= 3)
                {
                    data = true;
                }
            }
            else
            {
                if ((functiondate - today).Days >= 2)
                {
                    data = true;
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}