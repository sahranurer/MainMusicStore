using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MainMusicStore.DataAccess.IRepository
{
    public interface IRepository<T> where T : class //repository tanımlarken mutlaka bir class olmalı
    {
        T Get(int id);

        IEnumerable<T> GetAll
            (Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
             string includeProperties = null);

        void Add(T entity);//T titipinde kayıt eklemek için
        void Remove(int id);//id türünde kayıt silmek için
        void Remove(T entity);//T tipinde kayıt silmek için
        void RemoveRange(IEnumerable<T> entity);//Toplu kayıt silmek için

    }
}
