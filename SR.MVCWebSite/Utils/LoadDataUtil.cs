using SR.MVCWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.MVCWebSite.Utils
{
    public class LoadDataUtil
    {
        public static IEnumerable<SelectListItem> LoadNationalitiesData()
        {
            NationalitiesClientModel _service = new NationalitiesClientModel();
            
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in _service.Service.GetNationalities())
            {
                items.Add(
                new SelectListItem()
                {
                   Value = item.Id.ToString(),
                   Text = item.Name
                });
            }
            return items;
           
        }

        public static IEnumerable<SelectListItem> LoadFacultiesData()
        {
            FacultiesClientModel _service = new FacultiesClientModel();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in _service.Service.GetFaculties())
            {
                items.Add(
                new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }
            return items;
        }
    }
}