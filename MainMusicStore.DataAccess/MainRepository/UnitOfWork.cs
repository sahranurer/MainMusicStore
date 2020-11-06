﻿using MainMusicStore.Data;
using MainMusicStore.DataAccess.IMainRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainMusicStore.DataAccess.MainRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        //bağlantı kontrolü yapılması işlemleri
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(_db);
            sp_call = new SPCallRepository(_db);
        }

        public ICategoryRepository category { get; private set; }

        public ISPCallRepository sp_call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}