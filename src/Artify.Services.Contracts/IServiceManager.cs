namespace Artify.Services.Contracts
{
    public interface IServiceManager
    {
        IArtworkService ArtworkService { get; }
        IAuthorService AuthorService { get; }
        IAuthenticationService AuthenticationService { get; }

    }
}
