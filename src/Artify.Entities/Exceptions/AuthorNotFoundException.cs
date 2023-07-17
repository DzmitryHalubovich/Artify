namespace Artify.Entities.Exceptions
{
    public class AuthorNotFoundException : NotFoundException
    {
        public AuthorNotFoundException(Guid authorId) 
            : base($"The author with id: {authorId} doesn't exist in the database.")
        { }
    }
}
