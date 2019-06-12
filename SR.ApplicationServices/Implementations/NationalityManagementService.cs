using SR.ApplicationServices.DTOs;
using SR.DataAccess.Entities;
using SR.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.ApplicationServices.Implementations
{
    public class NationalityManagementService
    {
        public List<NationalityDTO> Get()
        {
            List<NationalityDTO> nationalityDTOs = new List<NationalityDTO>();

            using (UnitOfWork uof = new UnitOfWork())
            {
                foreach (var item in uof.NationalitiesRepo.GetAll())
                {
                    nationalityDTOs.Add(new NationalityDTO
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }

            return nationalityDTOs;
        }

        public bool Save(NationalityDTO item)
        {
            Nationality nationality = new Nationality
            {
                Id = item.Id,
                Name = item.Name
            };

            try
            {
                using (UnitOfWork uof = new UnitOfWork())
                {
                    uof.NationalitiesRepo.Insert(nationality);
                    uof.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(NationalityDTO item)
        {
            Nationality nationality = new Nationality
            {
                Id = item.Id,
                Name = item.Name
            };

            try
            {
                using (UnitOfWork uof = new UnitOfWork())
                {
                    uof.NationalitiesRepo.Update(nationality);
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
                    Nationality nationality = uof.NationalitiesRepo.GetById(id);
                    uof.NationalitiesRepo.Delete(nationality);
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