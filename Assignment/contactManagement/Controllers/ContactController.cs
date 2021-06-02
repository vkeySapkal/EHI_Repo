using contactManagement.Model;
using contactManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace contactManagement.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepo;

        public ContactController(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public ViewResult Index()
        {
            var model = _contactRepo.getAll();
            return View(model);
        }

        [HttpGet]
        [Route("Controller/Create")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Controller/Create")]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepo.addContact(contact);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Controller/Edit")]
        public ActionResult Edit(int id)
        {
            Contact contact = _contactRepo.getContactById(id);
            return View(contact);
        }

        [HttpPost]
        [Route("Controller/Edit")]
        public ActionResult Edit(Contact contact)
        {
            _contactRepo.updateContact(contact);
            return RedirectToAction("Index");
        }

        [Route("Controller/Details")]
        public ActionResult Details(int id)
        {
            Contact contact = _contactRepo.getContactById(id);
            return View(contact);
        }

        [Route("Controller/DeleteContact")]
        public ActionResult DeleteContact(Int64 id)
        {
            _contactRepo.deleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
