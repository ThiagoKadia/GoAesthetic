namespace GoAesthetic.Respostas
{
    public class RespostaPadrao
    {
        public bool Sucesso { get; set; } = false;
        public bool Erro { get; set; } = false;
        public string Mensagem { get; set; } = "Erro Inesperado";
        public List<Erros> Dados { get; set; } = new List<Erros>();
    }

    public class Erros
    {
        public string Id { get; set; }
        public string Erro { get; set; }
    }
}
