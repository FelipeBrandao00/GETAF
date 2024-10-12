namespace GETAF.Models.ViewModel
{
    public class CodigoSenhaModel
    {
        public string Codigo { get; set; }

        public Resposta VerificarCodigo(string codigo) => new Resposta(codigo == Codigo, codigo == Codigo? "Código Validado" : "Código Incorreto");      
    }
}
