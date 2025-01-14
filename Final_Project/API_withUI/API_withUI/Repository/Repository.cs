using API_withUI.Controllers;
using API_withUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace API_withUI.Controllers

{

    public class Repository<T> : IRepository<T> where T : class

    {

        private readonly  Context context;

        private readonly  DbSet<T> dbSet;

        public Repository()

        {

            context = new Context();

            dbSet = context.Set<T>();

        }

        public IEnumerable<T> GetAll()

        {

            return dbSet.ToList();

        }

        public T GetById(int id)

        {

            return dbSet.Find(id);

        }

        public void Insert(T entity)

        {

            dbSet.Add(entity);

        }

        public void Update(T entity)

        {

            context.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(T entity)

        {

            dbSet.Remove(entity);

        }

        public void Save()

        {

            context.SaveChanges();

        }

    }

}