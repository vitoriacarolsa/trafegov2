namespace fiap.ViewModels
{
    public class SemaforoPaginacaoReferenciaViewModel
    {

        public IEnumerable<SemaforoViewModel> Semaforos { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Semaforo?referencia={Ref}&tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Semaforo?referencia={NextRef}&tamanho={PageSize}" : "";



    }
}
