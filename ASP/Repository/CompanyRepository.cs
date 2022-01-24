using ASP.DataAccess.Repository.IRepository;
using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        void ICompanyRepository.Update(Company obj)
        {
            _db.Companies.Update(obj); 
        }
    }
}
