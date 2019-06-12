using SR.MVCWebSite.Models;
using SR.MVCWebSite.ViewModels.FacultiesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.MVCWebSite.Controllers
{
    public class FacultiesController : Controller
    {
        FacultiesClientModel _service = new FacultiesClientModel();

        public ActionResult Index(IndexVM model)
        {
            model.Items = new List<FacultiesService.FacultyDTO>();
            using (_service.Service)
            {
                foreach (var item in _service.Service.GetFaculties())
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
                        SR.MVCWebSite.FacultiesService.FacultyDTO item = new SR.MVCWebSite.FacultiesService.FacultyDTO();
                        model.PopulateEntityDTO(item);
                        _service.Service.PostFaculty(item);
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
                SR.MVCWebSite.FacultiesService.FacultyDTO item =
                    _service.Service.GetFaculties().Where(x => x.Id == id).FirstOrDefault();
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
                SR.MVCWebSite.FacultiesService.FacultyDTO item = new SR.MVCWebSite.FacultiesService.FacultyDTO();

                model.PopulateEntityDTO(item);

                _service.Service.PutFaculty(item);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (_service.Service)
            {
                _service.Service.DeleteFaculty(id);
                return RedirectToAction("Index");
            }
        }
    }
}