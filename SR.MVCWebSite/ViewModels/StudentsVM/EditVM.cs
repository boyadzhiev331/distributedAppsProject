using SR.ApplicationServices.DTOs;
using SR.MVCWebSite.Models;
using SR.MVCWebSite.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.MVCWebSite.ViewModels.StudentsVM
{
    public class EditVM : BaseEditVM<SR.MVCWebSite.StudentsService.StudentDTO>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be less than 100 characters long.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be less than 100 characters long.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be less than 500 characters long.")]
        public string Comment { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public SR.MVCWebSite.StudentsService.FacultyDTO Faculty { get; set; }
        public int SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> FacultiesList { get; set; }
        public SR.MVCWebSite.StudentsService.NationalityDTO Nationality { get; set; }
        public int SelectedNationality { get; set; }
        public IEnumerable<SelectListItem> NationalitiesList { get; set; }

        public override void PopulateEntityDTO(SR.MVCWebSite.StudentsService.StudentDTO item)
        {
            item.Id = Id;
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.Comment = Comment;
            item.DateOfBirth = DateOfBirth;

            Faculty = new SR.MVCWebSite.StudentsService.FacultyDTO();
            FacultiesClientModel _facService = new FacultiesClientModel();
            SR.MVCWebSite.FacultiesService.FacultyDTO fac = _facService.Service.GetFaculties().Where(x => x.Id == SelectedFaculty).FirstOrDefault();
            Faculty.Id = fac.Id;
            Faculty.Name = fac.Name;
            Faculty.City = fac.City;
            Faculty.Address = fac.Address;
            item.Faculty = Faculty;

            Nationality = new SR.MVCWebSite.StudentsService.NationalityDTO();
            NationalitiesClientModel _natService = new NationalitiesClientModel();
            SR.MVCWebSite.NationalitiesService.NationalityDTO nat = _natService.Service.GetNationalities().Where(x => x.Id == SelectedNationality).FirstOrDefault();
            Nationality.Id = nat.Id;
            Nationality.Name = nat.Name;
            item.Nationality = Nationality;
        }

        public override void PopulateModel(SR.MVCWebSite.StudentsService.StudentDTO item)
        {
            Id = item.Id;
            FirstName = item.FirstName;
            LastName = item.LastName;
            Comment = item.Comment;
            DateOfBirth = item.DateOfBirth;
            Faculty = item.Faculty;
            Nationality = item.Nationality;
        }
    }
}