namespace fiap.ViewModels
{
    public class SemaforoViewModel
    {
        public int SemaforoId { get; set; }
        public string? localizacao { get; set; }
        public string? estadoAtual { get; set; }
        public int tempoVerde { get; set; }
        public int tempoVermelho { get; set; }
        public string? condicoesClimaticas { get; set; }
        public DateTime ultimaAtualizacao { get; set; }
    }
}
