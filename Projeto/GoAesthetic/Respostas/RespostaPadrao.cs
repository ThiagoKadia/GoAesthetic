namespace GoAesthetic.Respostas
{
    public class RespostaPadrao
    {
        public bool Sucesso { get; set; } = false;
        public bool Erro { get; set; } = false;
        public string Mensagem { get; set; } = "Erro Inesperado";
        public object Dados { get; set; }
    }
}
