using ConferenceScheduler.Models.Interfaces;

namespace ConferenceScheduler.Models.Repositories
{
    class AuthProvider : IAuthProvider
    {
        readonly IUserRepository _ur;

        public AuthProvider(IUserRepository userRepo)
        {
            _ur = userRepo;
        }

        public bool Authenticate(UserLogin l)
        {
            var user = _ur.GetUserByEmail(l.Email);
            return user != null && user.Password.Equals(l.Password);
        }

        public int GetCurrentUserId(string email)
        {
            var user = _ur.GetUserByEmail(email);
            return user.UserID;
        }
    }
}