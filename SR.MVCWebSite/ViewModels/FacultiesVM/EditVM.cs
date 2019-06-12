using SR.ApplicationServices.DTOs;
using SR.MVCWebSite.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SR.MVCWebSite.ViewModels.FacultiesVM
{
    public class EditVM : BaseEditVM<SR.MVCWebSite.FacultiesService.FacultyDTO>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be less than 200 characters long.")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be less than 200 characters long.")]
        public string Address { get; set; }

        public override void PopulateEntityDTO(SR.MVCWebSite.FacultiesService.FacultyDTO item)
        {
            item.Id = Id;
            item.Name = Name;
            item.City = City;
            item.Address = Address;
        }

        public override void PopulateModel(SR.MVCWebSite.FacultiesService.FacultyDTO item)
        {
            Id = item.Id;
            Name = item.Name;
            City = item.City;
            Address = item.Address;
        }
    }
}