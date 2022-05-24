using CRMApplication;
using CRMApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAplication
{
    public class BaseRepository<T> where T : class
    {
        public async Task Create(T obj)
        {
            using (var db = new AppCRMContext())
            {
                await db.Set<T>().AddAsync(obj);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var db = new AppCRMContext())
            {
                db.Set<T>().Remove(obj);
                await db.SaveChangesAsync();
            }
        }
        public async Task<T> GetById(object id)
        {
            using (var db = new AppCRMContext())
            {
                return await db.Set<T>().FindAsync(id);
            }
        }

        public async Task Update(T obj)
        {
            using (var db = new AppCRMContext())
            {
                db.Set<T>().Update(obj);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var db = new AppCRMContext())
            {
                return await db.Set<T>().ToListAsync();
            }
        }
    }
}