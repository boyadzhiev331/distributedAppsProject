using SR.MVCWebSite.Models;
using SR.MVCWebSite.Utils;
using SR.MVCWebSite.ViewModels.StudentsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;
using System.Web.Mvc;

namespace SR.MVCWebSite.Controllers
{
    public class StudentsController : Controller
    {
        //StudentsService.StudentsClient _service = new StudentsService.StudentsClient();
        StudentsClientModel _service = new StudentsClientModel();
        // GET: Students
        public ActionResult Index(IndexVM model)
        {
            model.Items = new List<StudentsService.StudentDTO>();
            using (_service.Service)
            {
                foreach (var item in _service.Service.GetStudents())
                {
                    model.Items.Add(item);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            EditVM model = new EditVM();

            StudentsService.StudentDTO item = _service.Service.GetById(id);

            model.PopulateModel(item);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            EditVM model = new EditVM();
            model.NationalitiesList = LoadDataUtil.LoadNationalitiesData();
            model.FacultiesList = LoadDataUtil.LoadFacultiesData();
            return View(model);
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
                        SR.MVCWebSite.StudentsService.StudentDTO item = new SR.MVCWebSite.StudentsService.StudentDTO();

                        model.PopulateEntityDTO(item);
                        _service.Service.PostStudent(item);
                    }
                    return RedirectToAction("Index");
                }
                model.NationalitiesList = LoadDataUtil.LoadNationalitiesData();
                model.FacultiesList = LoadDataUtil.LoadFacultiesData();
                return View(model);
            }
            catch
            {
                return View(model);
            }
         }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (_service.Service)
            {
                SR.MVCWebSite.StudentsService.StudentDTO item =
                    _service.Service.GetStudents().Where(x => x.Id == id).FirstOrDefault();
                EditVM model = new EditVM();
                model.PopulateModel(item);
                model.NationalitiesList = LoadDataUtil.LoadNationalitiesData();
                model.FacultiesList = LoadDataUtil.LoadFacultiesData();

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
                SR.MVCWebSite.StudentsService.StudentDTO item = new SR.MVCWebSite.StudentsService.StudentDTO();

                model.PopulateEntityDTO(item);

                _service.Service.PutStudent(item);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (_service.Service)
            {
                _service.Service.DeleteStudent(id);
                return RedirectToAction("Index");
            }
        }
    }
}