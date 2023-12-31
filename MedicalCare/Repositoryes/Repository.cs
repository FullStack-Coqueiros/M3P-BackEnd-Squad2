﻿using MedicalCare.Infra;
using MedicalCare.Interfaces;
using MedicalCare.Models;
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

        public bool GetByCpfEmail(string cpf, string email)
        {
            var verificaCpf = _context.Set<PacienteModel>().Where(w => w.Cpf == cpf).FirstOrDefault();
            var verificaEmail = _context.Set<PacienteModel>().Where(w => w.Email == email).FirstOrDefault();
            if (verificaCpf != null || verificaEmail != null)
            {
                return true;
            }
            return false;
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(entity).State = EntityState.Modified;
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
