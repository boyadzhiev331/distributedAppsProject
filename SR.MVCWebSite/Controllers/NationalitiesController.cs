using SR.ApplicationServices.DTOs;
using SR.MVCWebSite.Models;
using SR.MVCWebSite.ViewModels.NationalitiesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.MVCWebSite.Controllers
{
    public class NationalitiesController : Controller
    {
        NationalitiesClientModel _service = new NationalitiesClientModel();
        public ActionResult Index(IndexVM model)
        {
            model.Items = new List<NationalitiesService.NationalityDTO>();
            using (_service.Service)
            {
                foreach (var item in _service.Service.GetNationalities())
                {
                    model.Items.Add(item);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EditVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (_service.Service)
                    {
                        SR.MVCWebSite.NationalitiesService.NationalityDTO item = new SR.MVCWebSite.NationalitiesService.NationalityDTO();
                        model.PopulateEntityDTO(item);
                        _service.Service.PostNationality(item);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (_service.Service)
            {
                SR.MVCWebSite.NationalitiesService.NationalityDTO item =
                    _service.Service.GetNationalities().Where(x => x.Id == id).FirstOrDefault();
                EditVM model = new EditVM();
                model.PopulateModel(item);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (_service.Service)
            {
                SR.MVCWebSite.NationalitiesService.NationalityDTO item = new NationalitiesService.NationalityDTO();

                model.PopulateEntityDTO(item);

                _service.Service.PutNationality(item);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (_service.Service)
            {
                _service.Service.DeleteNationality(id);
                return RedirectToAction("Index");
            }
        }
    }
}