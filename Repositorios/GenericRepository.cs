using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class GenericRepository<T> where T : class
    {
        public GenericRepository(PruebaCoreContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = _dbContext.Set<T>();
        }

        private readonly PruebaCoreContext dbContext;
        private readonly DbSet<T> dbSet;

        public void Add(T Entidad)
        {
            dbSet.Add(Entidad);
        }

        public void AddList(IEnumerable<T> Entidades)
        {
            dbSet.AddRange(Entidades);
        }

        public void Delete(T Entidad)
        {
            dbSet.Remove(Entidad);
        }

        public void DeleteList(IEnumerable<T> Entidades)
        {
            dbSet.RemoveRange(Entidades);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public T GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public void Update(T Entidad)
        {
            dbSet.Attach(Entidad);
            dbContext.Entry(Entidad).State = EntityState.Modified;
        }
    }
}
