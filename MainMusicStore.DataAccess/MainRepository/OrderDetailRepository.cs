﻿using MainMusicStore.Data;
using MainMusicStore.DataAccess.IMainRepository;
using MainMusicStore.Models.DbModels;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Linq;

namespace MainMusicStore.DataAccess.MainRepository
{
    public class OrderDetailRepository : Repository<OrderDetails>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails orderDetails)
        {
            _db.Update(orderDetails);
        
        }

    }
}