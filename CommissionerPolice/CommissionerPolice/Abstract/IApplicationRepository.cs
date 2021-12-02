using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommissionerPolice.Models;

namespace CommissionerPolice.Abstract
{
    public interface IApplicationRepository
    {
        int SaveApplication(ApplicationDetail applicationDetail, List<ParticipantDetail> participantDetails);
        User CheckLogin(string username, string password);
        List<vw_ApplicationDetail> vw_ApplicationDetails();
        sp_ApplicationDetail_Result sp_ApplicationDetail_Result(int id);
        List<sp_ParticipantDetail_Result> sp_ParticipantDetail_Results(int id);
        bool ApproveReject(int id, string remark, string status);
        List<PoliceStattion> policeStattions();
        List<Area> Areas();
        DashboardModel dashboard(int id);
    }
}
