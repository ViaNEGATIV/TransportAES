﻿using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementations
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        private DbSet<T> set;
        private DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            set = this.context.Set<T>();
        }

        public void Create(T item)
        {
            set.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return set;
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return set.Where(predicate);
        }

        public T GetById(int id)
        {
            return set.Find(id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            set.Remove(entity);
        }
        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

    }
}
