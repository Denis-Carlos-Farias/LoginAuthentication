namespace LoginAuthentication;

public interface ITokenService
{
    string GerarTokenJwt(string user, string role);
}