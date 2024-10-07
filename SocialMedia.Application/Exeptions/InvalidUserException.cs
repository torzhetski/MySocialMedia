namespace SocialMedia.Application.Exeptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string name, object key) : base($"Entity \"{name}\" ({key}) not found") { }
    }
}
