using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var announcement = _announcementService.TGetList();
            var values = _mapper.Map<List<AnnouncementListDTO>>(announcement);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO addDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _mapper.Map<Announcement>(addDTO);
                values.Date = DateTime.Now;
                _announcementService.TAdd(values);
                return RedirectToAction("Index");
            }

            return View(addDTO);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            var updateDTO = _mapper.Map<AnnouncementUpdateDTO>(values);
            return View(updateDTO);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO updateDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _mapper.Map<Announcement>(updateDTO);
                values.Date = DateTime.Now;
                _announcementService.TUpdate(values);
                return RedirectToAction("Index");
            }
            return View(updateDTO);
        }
    }
}
