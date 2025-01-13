﻿using Entities.Helpers;

namespace Database
{
    public class Repository<T> where T : class, IIdEntity
    {
        AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            this._ctx = ctx;
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
        }

        public T FindById(string id)
        {
            return _ctx.Set<T>().First(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _ctx.Set<T>();
        }

        public void Update(T entity)
        {
            var old = FindById(entity.Id);
            foreach (var prop in typeof(T).GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            _ctx.Set<T>().Update(old);
            _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
        }

        public void DeleteById(string id)
        {
            var entity = FindById(id);
            Delete(entity);
        }
    }
}
