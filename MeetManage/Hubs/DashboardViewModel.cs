using MeetManage.Models;

namespace MeetManage.Hubs
{
    public class DashboardViewModel
    {
        public List<MeetingRequest> UpcomingMeetings { get; set; }
        public List<Invitation> PendingInvitations { get; set; }
        public List<MeetingRequest> OngoingMeetings { get; set; }
    }
}
