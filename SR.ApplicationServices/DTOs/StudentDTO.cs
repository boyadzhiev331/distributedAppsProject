using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.ApplicationServices.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public FacultyDTO Faculty { get; set; }
        public NationalityDTO Nationality { get; set; }
    }
}