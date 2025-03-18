using MeetManage.Data;
using MeetManage.Hubs;
using MeetManage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace MeetManage.Controllers
{
    public class MeetingRequestController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IHubContext<MeetingRequstHub> _hubContext;
        public MeetingRequestController(ApplicationDbContext db, IHubContext<MeetingRequstHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View(_db.meetingRequests.ToList());
        }

        public  IActionResult Create()
        {
            var users = _db.users.Select(u => new { u.Id, Name = u.FirstName + " " + u.LastName }).ToList();
            ViewBag.UserId = new SelectList(users, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MeetingRequest meetingRequest)
        {
            if (!ModelState.IsValid)
            {

                _db.Add(meetingRequest);
                await _db.SaveChangesAsync();

                // Notify John (recipient) about the new meeting request
                if (!string.IsNullOrEmpty(meetingRequest.UserId))
                {
                    await _hubContext.Clients.User(meetingRequest.UserId).SendAsync("ReceiveMeetingRequestNotification");
                }

                return RedirectToAction(nameof(Index));
            }
           // ViewBag.UserId = new SelectList(_db.users, "Id", "Name", meetingRequest.UserId);
            return View(meetingRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDecision(int id, string decision, string action)
        {
            var meetingRequest = await _db.meetingRequests.FindAsync(id);
            if (meetingRequest == null) return NotFound();

            meetingRequest.Decision = decision;
            meetingRequest.Action = action;
            await _db.SaveChangesAsync();

            // Notify the creator of the meeting request (Nick)
            if (!string.IsNullOrEmpty(meetingRequest.From))
            {
                await _hubContext.Clients.User(meetingRequest.From).SendAsync("ReceiveDecisionUpdate", decision, action);
            }

            return RedirectToAction(nameof(Index));
        }



        //Edit Get action method
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var meetingRequest = _db.meetingRequests.Find(id);
            if (meetingRequest == null)
            {
                return NotFound();
            }
            return View(meetingRequest);
        }

        //Edit Post Action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MeetingRequest meetingRequest)
        {
            if (ModelState.IsValid)
            {
                _db.Update(meetingRequest);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingRequest);
        }
        //Details Get Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var meetingRequest = _db.meetingRequests.Find(id);
            if (meetingRequest == null)
            {
                return NotFound();
            }
            return View(meetingRequest);
        }

        //Details Post Action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(MeetingRequest meetingRequest)
        {

            return RedirectToAction(nameof(Index));


        }

        //Delete Get Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var meetingRequest = _db.meetingRequests.Find(id);
            if (meetingRequest == null)
            {
                return NotFound();
            }
            return View(meetingRequest);
        }

        //Delete Post Action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, MeetingRequest meetingRequest)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != meetingRequest.Id)
            {
                return NotFound();
            }

            var productType = _db.meetingRequests.Find(id);
            if (productType == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }
    }
}
