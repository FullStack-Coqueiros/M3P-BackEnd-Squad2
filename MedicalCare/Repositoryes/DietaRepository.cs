using MedicalCare.Models;
using MedicalCare.Interfaces;
using MedicalCare.Infra;
using Microsoft.EntityFrameworkCore;

public class DietaRepository : IDietaRepository
{
    private readonly MedicalCareDbContext _context;

    public DietaRepository(MedicalCareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DietaModel>> GetAllDietasAsync()
    {
        return await _context.DbDieta.ToListAsync();
    }

    public async Task<DietaModel> GetDietaByIdAsync(int id)
    {
        return await _context.DbDieta.FindAsync(id);
    }

    public async Task<int> CreateDietaAsync(DietaModel dieta)
    {
        _context.DbDieta.Add(dieta);
        await _context.SaveChangesAsync();
        return dieta.Id;
    }

    public async Task<bool> UpdateDietaAsync(DietaModel dieta)
    {
        var existingDieta = await _context.DbDieta.FindAsync(dieta.Id);
        if (existingDieta != null)
        {
            existingDieta.NomeDaDieta = dieta.NomeDaDieta;
            existingDieta.Descricao = dieta.Descricao;
            existingDieta.Data = dieta.Data;
            existingDieta.Horario = dieta.Horario;
            existingDieta.Tipo = dieta.Tipo;
            existingDieta.DescricaoDaDietaExecutada = dieta.DescricaoDaDietaExecutada;
            existingDieta.StatusDoSistema = dieta.StatusDoSistema;
            existingDieta.PacienteId = dieta.PacienteId;
            existingDieta.UsuarioId = dieta.UsuarioId;

            await _context.SaveChangesAsync();

            return true;
        }

        return false; // Dieta não foi encontrada
    }

    public async Task<bool> DeleteDietaAsync(int id)
    {
        var dieta = await _context.DbDieta.FindAsync(id);
        if (dieta != null)
        {
            _context.DbDieta.Remove(dieta);
            await _context.SaveChangesAsync();
            return true;
        }

        return false; // Dieta não foi encontrada
    }
}