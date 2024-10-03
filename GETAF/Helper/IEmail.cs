namespace GETAF.Helper
{
    public interface IEmail
    {
        Task<bool> EnviarAsync(string email, string assunto, string mensagem);
    }
}
