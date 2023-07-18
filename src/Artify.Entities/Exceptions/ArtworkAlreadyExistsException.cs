namespace Artify.Entities.Exceptions
{
    public class ArtworkAlreadyExistsException : AlreadyExistsException
    {
        public ArtworkAlreadyExistsException(string name) : base($"The artwork with name: {name} already exists in the database.") 
        { }

    }
}
