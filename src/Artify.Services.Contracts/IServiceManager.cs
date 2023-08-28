namespace Artify.Services.Contracts
{
    public interface IServiceManager
    {
        IArtworkService ArtworkService { get; }
        IAuthorService AuthorService { get; }
        IAuthorProfileService AuthorProfileService { get; }
        IAuthenticationService AuthenticationService { get; }

    }
}
