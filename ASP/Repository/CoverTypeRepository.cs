using ASP.DataAccess.Repository.IRepository;
using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        void ICoverTypeRepository.Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj); 
        }
    }
}
