using MedicalCare.Infra;
using MedicalCare.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Repositoryes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            private readonly MedicalCareDbContext _context;

            public Repository(MedicalCareDbContext context)
            {
                _context = context;
            }

            public IEnumerable<TEntity> GetAll()
            {
                return _context.Set<TEntity>().ToList();
            }

            public TEntity GetById(int id)
            {
                return _context.Set<TEntity>().Find(id);
            }

            public TEntity GetByEmail(string email)
        {
            return _context.Set<TEntity>().Find(email);
        }

            public TEntity Create(TEntity entity)
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }

            public TEntity Update(TEntity entity)
            {
            //está tendo um erro por aqui
                _context.Update<TEntity>(entity);
                _context.SaveChanges();
                return entity;
            }

            public bool Delete(int id)
            {
                var entity = _context.Set<TEntity>().Find(id);
                if (entity == null)
                {
                    return false;
                }

                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
        }
}
