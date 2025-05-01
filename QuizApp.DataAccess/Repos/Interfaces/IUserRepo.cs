namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IUserRepo
    {
        User GetById(int id);
        //Task<User> GetByUsernameAsync(string username);
        void Add(User user);
    }
}
