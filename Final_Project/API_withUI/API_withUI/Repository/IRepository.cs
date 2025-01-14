using System;
using System.Collections.Generic;



namespace API_withUI.Controllers

{

    public interface IRepository<T> where T : class

    {

        IEnumerable<T> GetAll();

        T GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();

    }

}