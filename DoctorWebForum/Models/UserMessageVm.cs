namespace DoctorWebForum.Models
{
    public class UserMessageVm
    {
        public string? UserName { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? AvatarPath { get; set; }
        public string? Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
