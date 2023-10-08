
using MedicalCare.Models;
using MedicalCare.Interfaces;
using MedicalCare.Infra;

public class ExameRepository : IExameRepository
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
            existingExame.NomeDoExame = exame.NomeDoExame;
            existingExame.DataDoExame = exame.DataDoExame;
            existingExame.HorarioDoExame = exame.HorarioDoExame;
            existingExame.TipoDoExame = exame.TipoDoExame;
            existingExame.Laboratorio = exame.Laboratorio;
            existingExame.UrlDoDocumento = exame.UrlDoDocumento;
            existingExame.Resultados = exame.Resultados;
            existingExame.StatusDoSistema = exame.StatusDoSistema;

            _context.SaveChanges();

            return existingExame;
        }

        return null; //  exame não foi encontrado
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

        return false; // exame não foi encontrado
    }
}
