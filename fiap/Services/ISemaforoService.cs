using fiap.Models;

namespace fiap.Services
{
    public interface ISemaforoService
    {
        IEnumerable<SemaforoModel> ListarSemaforos();
        SemaforoModel ObterSemaforoPorId(int id);

        IEnumerable<SemaforoModel> ListarSemaforos(int pagina = 0, int tamanho = 10);
        IEnumerable<SemaforoModel> ListarSemaforosUltimaReferencia(int ultimoId = 0, int tamanho = 10);
        void CriarSemaforo(SemaforoModel semaforo);
        void AtualizarSemaforo(SemaforoModel semaforo);
        void DeletarSemaforo(int id);
    }
}
