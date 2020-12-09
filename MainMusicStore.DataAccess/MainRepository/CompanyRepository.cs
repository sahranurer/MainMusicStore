﻿using MainMusicStore.Data;
using MainMusicStore.DataAccess.IMainRepository;
using MainMusicStore.Models.DbModels;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Linq;

namespace MainMusicStore.DataAccess.MainRepository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Update(company);
        
        }

    }
}
