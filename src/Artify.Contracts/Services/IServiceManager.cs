namespace Artify.Contracts.Services
{
    public interface IServiceManager
    {
        IArtworkService ArtworkService { get; }
        IAuthorService AuthorService { get; }
    }
}
