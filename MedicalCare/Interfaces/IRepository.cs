namespace MedicalCare.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByEmail(string email);
        bool GetByCpfEmail(string cpf, string email);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(int id);
    }
}
