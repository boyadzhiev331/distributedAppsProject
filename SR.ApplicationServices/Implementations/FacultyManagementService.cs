using SR.ApplicationServices.DTOs;
using SR.DataAccess.Entities;
using SR.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.ApplicationServices.Implementations
{
    public class FacultyManagementService
    {
        public List<FacultyDTO> Get()
        {
            List<FacultyDTO> facultyDTOs = new List<FacultyDTO>();

            using (UnitOfWork uof = new UnitOfWork())
            {
                foreach (var item in uof.FacultiesRepo.GetAll())
                {
                    facultyDTOs.Add(new FacultyDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        City = item.City,
                        Address = item.Address
                    });
                }
            }

            return facultyDTOs;
        }

        public bool Save(FacultyDTO item)
        {
            Faculty faculty = new Faculty
            {
                Id = item.Id,
                Name = item.Name,
                City = item.City,
                Address = item.Address
            };

            try
            {
                using (UnitOfWork uof = new UnitOfWork())
                {
                    uof.FacultiesRepo.Insert(faculty);
                    uof.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(FacultyDTO item)
        {
            Faculty faculty = new Faculty
            {
                Id = item.Id,
                Name = item.Name,
                City = item.City,
                Address = item.Address
            };

            try
            {
                using (UnitOfWork uof = new UnitOfWork())
                {
                    uof.FacultiesRepo.Update(faculty);
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
                    Faculty faculty = uof.FacultiesRepo.GetById(id);
                    uof.FacultiesRepo.Delete(faculty);
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