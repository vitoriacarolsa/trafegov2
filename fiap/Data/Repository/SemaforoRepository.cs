using fiap.Models;
using Microsoft.EntityFrameworkCore;

namespace fiap.Data.Repository
{
    public class SemaforoRepository : IsemaforoRepository
    {
        private readonly DataBaseContext _context;

        public SemaforoRepository (DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<SemaforoModel> GetAll() => _context.Semaforos.ToList();

        public IEnumerable<SemaforoModel> GetAll(int page, int size)
        {
            return _context.Semaforos
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        public IEnumerable<SemaforoModel> GetAllReference(int lastReference, int size)
        {
            var semaforos = _context.Semaforos
                                .Where(c => c.SemaforoId > lastReference)
                                .OrderBy(c => c.SemaforoId)
                                .Take(size)
                                .AsNoTracking()
                                .ToList();

            return semaforos;
        }

        public SemaforoModel GetById(int id) => _context.Semaforos.Find(id);

        public void Add(SemaforoModel semaforo)
        {
            _context.Semaforos.Add(semaforo);
            _context.SaveChanges();
        }

        public void Update(SemaforoModel semaforo)
        {
            _context.Semaforos.Update(semaforo);
            _context.SaveChanges();
        }

        public void Delete(SemaforoModel semaforo)
        {
            _context.Semaforos.Remove(semaforo);
            _context.SaveChanges();
        }
    }
}
