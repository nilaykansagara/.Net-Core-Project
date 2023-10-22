using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EBill.Models.Domain;
using EBill.Repositories.Abstract;

namespace EBill.Controllers
{
    [Authorize]
    public class ModelController : Controller
    {
        private readonly IModelService service;
        public ModelController(IModelService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(pcModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(pcModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Delete(int id)
        {

            var result = service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = service.GetAll();
            return View(data);
        }

    }
}
