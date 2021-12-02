using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using CommissionerPolice.Abstract;
using CommissionerPolice.Models;
using CommissionerPolice.Helper;
using System.Text;
using System.Net;
using System.IO;

namespace CommissionerPolice.Concrete
{
    public class ApplicationRepository : IApplicationRepository
    {
        ePermissionEntities con = new ePermissionEntities();

        public const string UserId = "1048";
        public const string Secretcode = "x4/pv9Ve/n/6RlWJEtJox9xcHwE+4WiwTAr++9mpxgE=";
        public const string Sender = "OTCPBC";
        public const string REQ_ID = "1";
        public const string FORMAT = "text";
        public const string ROUTE_ID = "3";
        public const string URL_ID = "";
        public const string UNIQUE = "0";
        public const string FLASH = "0";

        #region--------------------------Mail Method------------------------- 
        public bool SendMail(string to, string subject, string body)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("cimsdev2020@gmail.com");
            mail.Subject = "Download Admit Card";
            string Body = body;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("cimsdev2020@gmail.com", "India@12345"); // Enter seders User name and password       
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return true; 
        }

        #endregion

        #region-------------------------Sms Method---------------------------
        public bool SendSms(string secode, string mobile, string sms)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("https://apps.sandeshlive.com/API/WebSMS/Http/v1.0a/index.php?");
            sb.Append("userid=" + UserId + "&password=" + secode + "&sender=" + Sender);
            sb.Append("&to=" + mobile + "&message=" + HttpUtility.UrlEncode(sms));
            sb.Append("&reqid=" + REQ_ID + "&format=" + FORMAT + "&route_id=" + ROUTE_ID);
            sb.Append("&url_id=" + URL_ID + "&unique=" + UNIQUE + "&sendondate=" + DateTime.Now.ToString() + "&flash=" + FLASH);

            string sendSMSUri = sb.ToString();
            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sendSMSUri);
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseString = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region----------------Application region----------------------------
        public int SaveApplication(ApplicationDetail applicationDetail, List<ParticipantDetail> participantDetails)
        {
            int result = 0;
            try
            {
                ApplicationDetail obj = new ApplicationDetail();
                obj.FunctionType= applicationDetail.FunctionType;
                obj.Name = applicationDetail.Name;
                obj.FathersName = applicationDetail.FathersName;
                obj.Address = applicationDetail.Address;
                obj.AreaId = applicationDetail.AreaId;
                obj.Ps_Id = applicationDetail.Ps_Id;
                obj.MobileNo = applicationDetail.MobileNo;
                obj.FunctionDate = applicationDetail.FunctionDate;
                obj.FromTime = applicationDetail.FromTime;
                obj.ToTime = applicationDetail.ToTime;
                obj.Duration = applicationDetail.Duration;
                obj.Venue = applicationDetail.Venue;
                obj.TotalSittingCapacity = applicationDetail.TotalSittingCapacity;
                obj.WorkingPlaceSize = applicationDetail.WorkingPlaceSize;
                obj.TotalParticipant = applicationDetail.TotalParticipant;
                obj.IdProof = applicationDetail.IdProof;
                obj.AddressProof = applicationDetail.AddressProof;
                obj.Status = "Submitted";
                obj.IsActive = true;
                obj.IsDeleted = false;
                obj.CreatedBy = applicationDetail.Name;
                obj.CreatedOn = DateTime.Now;
                con.ApplicationDetails.Add(obj);
                con.SaveChanges();

                int appid = obj.ApplicantId;

                obj.ApplicationNo = "CP/" + "OD/" + DateTime.Now.Year + "/" + appid;
                con.SaveChanges();

                if (participantDetails.ToList().Count > 0)
                {
                    foreach (var item in participantDetails)
                    {
                        ParticipantDetail obj1 = new ParticipantDetail();
                        obj1.ApplicantId = appid;
                        obj1.ParticipantName = item.ParticipantName;
                        obj1.Age = item.Age;
                        obj1.MobileNo = item.MobileNo;
                        obj1.PermissionFrom = item.PermissionFrom;
                        obj1.PermissionTo = obj.Venue;
                        obj1.IsActive = true;
                        obj1.IsDeleted = false;
                        obj1.CreatedBy = applicationDetail.Name;
                        obj1.CreatedOn = DateTime.Now;
                        con.ParticipantDetails.Add(obj1);
                        con.SaveChanges();
                    }
                }

                result = obj.ApplicantId;
            }
      
            catch(Exception ex)
            {
                result = 0;
            }
            return result;
        }
        public List<PoliceStattion> policeStattions()
        {
            var data = con.PoliceStattions.ToList();

            return data;
        }
        public List<Area> Areas()
        {
            var data = con.Areas.ToList();

            return data;
        }
        #endregion

        #region-----------------------Admin Section--------------------------
        public User CheckLogin(string username, string password)
        {
            var data = con.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();

            return data;
        }
        public List<vw_ApplicationDetail> vw_ApplicationDetails()
        {
            var data = con.vw_ApplicationDetail.ToList();

            return data;
        }
        public sp_ApplicationDetail_Result sp_ApplicationDetail_Result(int id)
        {
            var data = con.sp_ApplicationDetail(id).FirstOrDefault();

            return data;
        }
        public List<sp_ParticipantDetail_Result> sp_ParticipantDetail_Results(int id)
        {
            var data = con.sp_ParticipantDetail(id).ToList();

            return data;
        }
        public DashboardModel dashboard(int id)
        {
            DashboardModel dashboardModel = new DashboardModel();

            dashboardModel.marriage = con.ApplicationDetails.Where(x => x.AreaId == id && x.FunctionType == "Marriage").ToList().Count;
            dashboardModel.funeral = con.ApplicationDetails.Where(x => x.AreaId == id && x.FunctionType == "Funeral").ToList().Count;
            //dashboardModel.thread = con.ApplicationDetails.Where(x => x.AreaId == id && x.FunctionType == "Thread").ToList().Count;
            dashboardModel.pending = con.ApplicationDetails.Where(x => x.AreaId == id && x.Status == "Submitted").ToList().Count;
            dashboardModel.reject = con.ApplicationDetails.Where(x => x.AreaId == id && x.Status == "Rejected").ToList().Count;

            return dashboardModel;
        }
        public bool ApproveReject(int id, string remark, string status)
        {
            string baseurl = ConfigurationManager.AppSettings["BaseWebUrl"];
            string secode = Utilites.Decrypt(Secretcode);
            var data = con.ApplicationDetails.Where(x => x.ApplicantId == id).FirstOrDefault();
            string sid = data.ApplicantId.ToString();
            string encode = EncodeDecode.Base64Encode(sid);
            string attachedurl = "";

            if (data.FunctionType=="Marriage")
            {
                attachedurl = baseurl + "Applicant/MarriagePermission?appno=" + encode;
            }
            else if(data.FunctionType == "Funeral")
            {
                attachedurl = baseurl + "Applicant/FuneralPermission?appno=" + encode;
            }
            else
            {
                attachedurl = baseurl + "Applicant/ThreadPermission?appno=" + encode;
            }
            if (data!=null)
            {
                data.Status = status;
                data.Remarks = remark;
                con.SaveChanges();

                var police = con.PoliceStattions.Where(x => x.Ps_Id == data.Ps_Id).FirstOrDefault();
                var applicant = con.ParticipantDetails.Where(x => x.ApplicantId == data.ApplicantId).ToList();

                if (data.Status=="Rejected")
                {
                    var body = new StringBuilder();
                    string result = data.Remarks;

                    if (data.Remarks.Length > 25)
                    {
                        result = data.Remarks.Substring(0, 25);
                    }
                    body.AppendFormat("Your " + data.FunctionType + " function application has been rejected by the Commissionerate of Police, ");
                    body.AppendLine("Bhubaneswar CPBC. Reason- " + result + ". ");
                    body.AppendLine("Regards");
                    body.AppendLine("DCP Bhubaneswar");

                    string mailbody = body.ToString();
                    SendSms(secode,data.MobileNo, mailbody);
                }
                else
                {
                    string fundate = Convert.ToDateTime(data.FunctionDate).ToLongDateString();
                    string place = data.Venue;

                    if(data.Venue.Length>25)
                    {
                        place= data.Venue.Substring(0, 25);

                    }
                    string aname = data.Name;

                    if (data.Name.Length > 25)
                    {
                        aname = data.Name.Substring(0, 25);
                    }

                    if (data.Name.Length > 25)
                    {
                        aname = data.Name.Substring(0, 25);
                    }

                    #region------------------For police station----------------------
                    var body = new StringBuilder();
                    string time = data.FromTime + " to " + data.ToTime;
                    body.AppendFormat("A " + data.FunctionType + " function has been approved by the DCP, ");
                    body.AppendLine("Bhubaneswar CPBC under your police station " + police.Ps_Name + ". Applicant name- " + aname + ", ");
                    body.AppendLine("Mobile Number- " + data.MobileNo + ", date- " + fundate + ", Place- " + place + " and time- " + time + ". ");
                    body.AppendLine("Kindly conduct surprise check for Covid guidelines.");
                    body.AppendLine("DCP Bhubaneswar");

                    string mailbody = body.ToString();
                    SendSms(secode, police.Ps_Contact_No, mailbody);
                    #endregion

                    #region---------------------For applicant------------------------
                    var userbody = new StringBuilder();
                    userbody.AppendFormat("Your " + data.FunctionType + " function application has been approved by the Commissionerate of Police, ");
                    userbody.AppendLine("Bhubaneswar CPBC. Function Date- " + fundate + ", Place- " + place + " and time- " + time + " ");
                    userbody.AppendLine("under police station- " + police.Ps_Name + ". ");
                    userbody.AppendLine("All invitees have been sent passes individually.");
                    userbody.AppendLine("Regards");
                    userbody.AppendLine("DCP Bhubaneswar");

                    string usermailbody = userbody.ToString();
                    SendSms(secode, police.Ps_Contact_No, usermailbody);
                    #endregion

                    #region--------------------For participant-----------------------
                    //string mobilenos = "";
                    foreach (var item in applicant)
                    {
                        string fromplace = item.PermissionFrom;

                        if (item.PermissionFrom.Length > 25)
                        {
                            fromplace = item.PermissionFrom.Substring(0, 25);
                        }
                        string perway = fromplace + " to " + place;
                        var applicantbody = new StringBuilder();
                        applicantbody.AppendFormat("You are invited by " + aname + " for " + data.FunctionType + " function on date- " + fundate + ", ");
                        applicantbody.AppendLine("place- " + perway + " and time between " + data.FromTime + " to " + data.ToTime + ", ");
                        applicantbody.AppendLine("approved by the Commissionerate of Police, Bhubaneswar CPBC.");
                        applicantbody.AppendLine("Regards");
                        applicantbody.AppendLine("DCP Bhubaneswar");
                        string applicantmailbody = applicantbody.ToString();

                        //mobilenos += item.MobileNo + ",";
                        SendSms(secode, item.MobileNo, applicantmailbody);
                    }
                    #endregion
                }
            }
            return true;
        }

        // GET: Test
        #endregion
    }
}