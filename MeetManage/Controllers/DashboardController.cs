using MeetManage.Data;
using MeetManage.Hubs;
using Microsoft.AspNetCore.Mvc;

namespace MeetManage.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var model = new DashboardViewModel
            {
                UpcomingMeetings = _context.meetingRequests
                 .Where(m => m.MeetingTime > DateTime.Now)
                 .ToList(),
                PendingInvitations = _context.Invitations
                 .Where(i => i.Decision == "Pending")
                 .ToList(),
                OngoingMeetings = _context.meetingRequests
                 .Where(m => m.MeetingTime <= DateTime.Now)
                 .ToList()
            };

            return View(model);
        }
    }
}
