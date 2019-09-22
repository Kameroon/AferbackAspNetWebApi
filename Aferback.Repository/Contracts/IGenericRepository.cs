using System.Collections.Generic;
using System.Linq;

namespace Aferback.Repository.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }

    /// <summary>
    /// -- !!!!!!!!!!!!!!!!!!!!!!!!! --
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //private EmployeeDBContext _context = null;
        //private DbSet<T> table = null;
        private List<T> table = null;

        public GenericRepository()
        {
            //this._context = new EmployeeDBContext();
            //table = _context.Set<T>();
        }

        //public GenericRepository(EmployeeDBContext _context)
        //{
        //    this._context = _context;
        //    table = _context.Set<T>();
        //}

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            //return table.Find(table.Where(t => t. id);
            return null;
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            //table.Attach(obj);
            //_context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            //T existing = table.Find(id);
            //table.Remove(existing);
        }

        public void Save()
        {
            //_context.SaveChanges();
        }
    }

}
