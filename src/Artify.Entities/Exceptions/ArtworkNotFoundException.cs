namespace Artify.Entities.Exceptions
{
    public sealed class ArtworkNotFoundException : NotFoundException
    {
        public ArtworkNotFoundException(Guid id) 
            : base ($"The artwork with id: {id} doesn't exist in the database.") 
        { }
    }
}
