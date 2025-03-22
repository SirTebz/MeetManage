using MeetManage.Models;
using MeetManage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetManage.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event eventEntity)
        {
            if (ModelState.IsValid)
            {
                await _eventRepository.AddEventAsync(eventEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(eventEntity);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var eventEntity = await _eventRepository.GetEventByIdAsync(id);
            if (eventEntity == null)
                return NotFound();
            return View(eventEntity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Event eventEntity)
        {
            if (id != eventEntity.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _eventRepository.UpdateEventAsync(eventEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(eventEntity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetEventByIdAsync(id);
            if (eventEntity == null) return NotFound();
            return View(eventEntity);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventRepository.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
