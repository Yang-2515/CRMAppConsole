using CRMApplication.Entities;
using CRMApplication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRMAplication;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRMApplication.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public static CustomerRepository _Instance;
        public static CustomerRepository Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerRepository();
                }
                return _Instance;
            }
            private set { }
        }
        public async Task<Customer> GetById(int id)
        {
            using( AppCRMContext db = new AppCRMContext())
            {
                return await db.Customers.FirstOrDefaultAsync(c => c.Id == id && c.IsDelete == false);
            }
        }
    }
}
