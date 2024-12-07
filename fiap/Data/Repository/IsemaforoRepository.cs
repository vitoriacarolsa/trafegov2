using fiap.Models;

namespace fiap.Data.Repository
{
    public interface IsemaforoRepository
    {
        IEnumerable<SemaforoModel> GetAll();
        IEnumerable<SemaforoModel> GetAll(int page, int size);
        IEnumerable<SemaforoModel> GetAllReference(int lastReference, int size);
        SemaforoModel GetById(int id);
        void Add(SemaforoModel semaforo);
        void Update(SemaforoModel semaforo);
        void Delete(SemaforoModel semaforo);
    }
}
