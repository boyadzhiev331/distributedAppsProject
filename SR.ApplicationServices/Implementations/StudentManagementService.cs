using SR.ApplicationServices.DTOs;
using SR.DataAccess.Entities;
using SR.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.ApplicationServices.Implementations
{
    public class StudentManagementService
    {
        public List<StudentDTO> Get()
        {
            List<StudentDTO> studentDTOs = new List<StudentDTO>();

            using (UnitOfWork uof = new UnitOfWork())
            {
                foreach (var item in uof.StudentsRepo.GetAll(null, null, "Faculty, Nationality"))
                {
                    studentDTOs.Add(new StudentDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Comment = item.Comment,
                        DateOfBirth = item.DateOfBirth,
                        Faculty = new FacultyDTO
                        {
                            Id = item.FacultyId,
                            Name = item.Faculty.Name,
                            Address = item.Faculty.Address,
                            City = item.Faculty.City
                        },
                        Nationality = new NationalityDTO
                        {
                            Id = item.Nationality.Id,
                            Name = item.Nationality.Name
                        }
                    });
                }
            }

            return studentDTOs;
        }

        public StudentDTO GetById(int id)
        {
            StudentDTO item = null;

            using (UnitOfWork uof = new UnitOfWork())
            {
                Student stu = uof.StudentsRepo.GetById(id);
                Faculty _fac = uof.FacultiesRepo.GetById(stu.FacultyId);
                Nationality _nat = uof.NationalitiesRepo.GetById(stu.NationalityId);
                item = new StudentDTO
                {
                    Id = stu.Id,
                    FirstName = stu.FirstName,
                    LastName = stu.LastName,
                    Comment = stu.Comment,
                    DateOfBirth = stu.DateOfBirth,
                    Faculty = new FacultyDTO
                    {
                        Id = _fac.Id,
                        Name = _fac.Name,
                        Address = _fac.Address,
                        City = _fac.City
                    },
                    Nationality = new NationalityDTO
                    {
                        Id = _nat.Id,
                        Name = _nat.Name
                    }
                };
                uof.FacultiesRepo.Delete(_fac);
                uof.NationalitiesRepo.Delete(_nat);
            }
            return item;
        }

        public bool Save(StudentDTO item)
        {
            Student student = new Student
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                DateOfBirth = item.DateOfBirth,
                Comment = item.Comment,
                FacultyId = item.Faculty.Id,
                NationalityId = item.Nationality.Id
            };

            try
            {
                using (UnitOfWork uof = new UnitOfWork())
                {
                    uof.StudentsRepo.Insert(student);
                    uof.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentDTO item)
        {
            Student student = new Student
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                DateOfBirth = item.DateOfBirth,
                Comment = item.Comment,
                FacultyId = item.Faculty.Id,
                NationalityId = item.Nationality.Id,
            };

            try
            {
                using (UnitOfWork uof = new UnitOfWork())
                {
                    uof.StudentsRepo.Update(student);
                    uof.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork uof = new UnitOfWork())
                {
                    Student student = uof.StudentsRepo.GetById(id);
                    uof.StudentsRepo.Delete(student);
                    uof.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}