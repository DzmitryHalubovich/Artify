namespace Artify.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        IArtworkRepository Artwork { get; }
        IAuthorRepository Author { get; }
        void Save();
    }
}
