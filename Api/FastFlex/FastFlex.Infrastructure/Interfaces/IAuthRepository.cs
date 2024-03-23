namespace FastFlex.Infrastructure.Interfaces
{
    public interface IAuthRepository 
    {
        public Task<string> Login(string username, string password);
    }
}