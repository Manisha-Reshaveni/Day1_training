using System;

using System.Collections.Generic;

using System.Data.Entity;

using System.Data.Entity.Validation;

using System.Linq;

namespace MyProject.Models.Repository

{

    public class Repository<T> : IRepository<T> where T : class

    {

        ProjectContext pc;

        DbSet<T> dbset;

        public Repository()

        {

            pc = new ProjectContext();

            dbset = pc.Set<T>();

        }

        //Implementation

        public IEnumerable<T> GetAll()

        {

            return dbset.ToList();

        }

        public T GetById(object EmployeeID)

        {

            return dbset.Find(EmployeeID);

        }

        public void Insert(T obj)

        {

            dbset.Add(obj);

        }

        public void Update(T obj)

        {

            pc.Entry(obj).State = EntityState.Modified;

        }

        public void Delete(object EmployeeID)

        {

            T getModel = dbset.Find(EmployeeID);

            dbset.Remove(getModel);

        }

        public void Save()

        {

            try

            {

                pc.SaveChanges();

            }

            catch (DbEntityValidationException ex)

            {

                foreach (var entityValidationErrors in ex.EntityValidationErrors)

                {

                    foreach (var validationError in entityValidationErrors.ValidationErrors)

                    {

                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                    }

                }

                throw; // Re-throw the exception to preserve the stack trace

            }

        }

    }

}