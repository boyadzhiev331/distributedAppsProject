using SR.ApplicationServices.DTOs;
using SR.MVCWebSite.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SR.MVCWebSite.ViewModels.NationalitiesVM
{
    public class EditVM : BaseEditVM<SR.MVCWebSite.NationalitiesService.NationalityDTO>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be less than 100 characters long.")]
        public string Name { get; set; }

        public override void PopulateEntityDTO(SR.MVCWebSite.NationalitiesService.NationalityDTO item)
        {
            item.Id = Id;
            item.Name = Name;
        }

        public override void PopulateModel(SR.MVCWebSite.NationalitiesService.NationalityDTO item)
        {
            Id = item.Id;
            Name = item.Name;
        }
    }
}