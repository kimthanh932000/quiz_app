
namespace QuizApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task AddAsync(User user)
        {
            _userRepo.Add(user);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return _userRepo.GetById(id);
        }

        //public Task<User> GetByUsernameAsync(string username)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
