namespace BusinessLogic.Services
{
    public interface IHashing
    {
        string HashPassword(string userUserPassword);
        bool ValidatePassword(string password, string correctHash);
    }
}