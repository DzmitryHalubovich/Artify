namespace Artify.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IArtworkRepository Artwork { get; }
        IAuthorRepository Author { get; }
        void Save();
    }
}
