namespace GETAF.Models.ViewModel {
    public class Resposta {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; }

        public Resposta() {

        }

        public Resposta(bool sucesso, string mensagem) {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}
