using AutoMapper;
using DoctorWebForum.Data;
using DoctorWebForum.Models;

namespace DoctorWebForum.Configurations
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserVM>();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}
