using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EBill.Models.Domain;
using EBill.Repositories.Abstract;

namespace EBill.Controllers
{
    [Authorize]
    public class BillController : Controller
    {
        private readonly IBillService billService;
        private readonly IWarrantyService warrantyService;
        private readonly IModelService modelService;
        private readonly IStorageService storageService;
        public BillController(IBillService billService, IModelService modelService, IStorageService storageService,IWarrantyService warrantyService)
        {
            this.billService = billService;
            this.modelService = modelService;
            this.storageService = storageService;
            this.warrantyService = warrantyService;
        }
        public IActionResult Add()
        {
            var model = new Bill();
            model.WarrantyList = warrantyService.GetAll().Select(a => new SelectListItem { Text = a.WarrantyName, Value = a.Id.ToString() }).ToList();
            model.StorageList = storageService.GetAll().Select(a => new SelectListItem { Text = a.StorageName, Value = a.Id.ToString() }).ToList();
            model.ModelList = modelService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Bill model)
        {
            model.WarrantyList = warrantyService.GetAll().Select(a => new SelectListItem { Text = a.WarrantyName, Value = a.Id.ToString(),Selected=a.Id==model.WarrantyId}).ToList();
            model.StorageList = storageService.GetAll().Select(a => new SelectListItem { Text = a.StorageName, Value = a.Id.ToString(),Selected=a.Id==model.StorageId }).ToList();
            model.ModelList = modelService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(),Selected=a.Id==model.ModelId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = billService.Add(model);
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
            var model = billService.FindById(id);
            model.WarrantyList = warrantyService.GetAll().Select(a => new SelectListItem { Text = a.WarrantyName, Value = a.Id.ToString(), Selected = a.Id == model.WarrantyId }).ToList();
            model.StorageList = storageService.GetAll().Select(a => new SelectListItem { Text = a.StorageName, Value = a.Id.ToString(), Selected = a.Id == model.WarrantyId }).ToList();
            model.ModelList = modelService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.ModelId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Bill model)
        {
            model.WarrantyList = warrantyService.GetAll().Select(a => new SelectListItem { Text = a.WarrantyName, Value = a.Id.ToString(), Selected = a.Id == model.WarrantyId }).ToList();
            model.StorageList = storageService.GetAll().Select(a => new SelectListItem { Text = a.StorageName, Value = a.Id.ToString(), Selected = a.Id == model.StorageId }).ToList();
            model.ModelList = modelService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.ModelId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = billService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Delete(int id)
        {

            var result = billService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = billService.GetAll();
            return View(data);
        }
    }
}
