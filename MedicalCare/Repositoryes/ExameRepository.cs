using System;
using System.Collections.Generic;
using System.Linq;
using MedicalCare.Infra;
using MedicalCare.Models;

public class ExameRepository
{
    private readonly MedicalCareDbContext _context;

    public ExameRepository(MedicalCareDbContext context)
    {
        _context = context;
    }

    public ExameModel Create(ExameModel exame)
    {
        _context.DbExame.Add(exame);
        _context.SaveChanges();
        return exame;
    }

    public ExameModel Update(ExameModel exame)
    {
        var existingExame = _context.DbExame.Find(exame.Id);
        if (existingExame != null)
        {
            // Atualizar os campos necessários
            existingExame.NomeDoExame = exame.NomeDoExame;
            existingExame.DataDoExame = exame.DataDoExame;
            existingExame.HorarioDoExame = exame.HorarioDoExame;
            // ...

            _context.SaveChanges();

            return existingExame;
        }

        return null; // Indica que o exame não foi encontrado
    }

    public ExameModel GetById(int id)
    {
        return _context.DbExame.Find(id);
    }

    public IEnumerable<ExameModel> GetAll()
    {
        return _context.DbExame.ToList();
    }

    public bool Delete(int id)
    {
        var exame = _context.DbExame.Find(id);
        if (exame != null)
        {
            _context.DbExame.Remove(exame);
            _context.SaveChanges();
            return true;
        }

        return false; // Indica que o exame não foi encontrado
    }
}