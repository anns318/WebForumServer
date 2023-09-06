using DoctorWebForum.Data;

namespace DoctorWebForum.Services
{
    public interface IJwtService
    {
        public string CreateToken(User user, string role);
    }
}
