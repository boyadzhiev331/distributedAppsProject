using SR.DataAccess.Context;
using SR.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private StudentsRegisterDbContext context = new StudentsRegisterDbContext();
        private GenericRepository<Student> studentsRepo;
        private GenericRepository<Faculty> facultiesRepo;
        private GenericRepository<Nationality> nationalitiesRepo;

        public GenericRepository<Student> StudentsRepo
        {
            get
            {
                if (this.studentsRepo == null)
                {
                    this.studentsRepo = new GenericRepository<Student>(context);
                }
                return studentsRepo;
            }
        }

        public GenericRepository<Faculty> FacultiesRepo
        {
            get
            {
                if (this.facultiesRepo == null)
                {
                    this.facultiesRepo = new GenericRepository<Faculty>(context);
                }
                return facultiesRepo;
            }
        }

        public GenericRepository<Nationality> NationalitiesRepo
        {
            get
            {
                if (this.nationalitiesRepo == null)
                {
                    this.nationalitiesRepo = new GenericRepository<Nationality>(context);
                }
                return nationalitiesRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable implementation
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}