namespace QuizApp.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        //Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
    }
}
