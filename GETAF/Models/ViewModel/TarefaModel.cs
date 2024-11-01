using Microsoft.AspNetCore.Mvc;

namespace GETAF.Models.ViewModel
{
    public class TarefaModel
    {
        public Resposta Criar()
        {
            return new Resposta(true, "a");
        }
    }
}
