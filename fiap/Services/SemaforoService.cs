using fiap.Data.Repository;
using fiap.Models;

namespace fiap.Services
{
    public class SemaforoService : ISemaforoService
    {
        private readonly IsemaforoRepository _repository;

        public SemaforoService (IsemaforoRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<SemaforoModel> ListarSemaforos() => _repository.GetAll();

        public IEnumerable<SemaforoModel> ListarSemaforos(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public IEnumerable<SemaforoModel> ListarSemaforosUltimaReferencia(int ultimoId = 0, int tamanho = 10)
        {
            return _repository.GetAllReference(ultimoId, tamanho);
        }

        public SemaforoModel ObterSemaforoPorId(int id) => _repository.GetById(id);

        public void CriarSemaforo(SemaforoModel semaforo) => _repository.Add(semaforo);

        public void AtualizarSemaforo(SemaforoModel semaforo) => _repository.Update(semaforo);

        public void DeletarSemaforo(int id)
        {
            var semaforo = _repository.GetById(id);
            if (semaforo != null)
            {
                _repository.Delete(semaforo);
            }
        }

    }
}
