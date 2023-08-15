using DoctorWebForum.Data;
using System.Collections;
using System.Dynamic;

namespace DoctorWebForum.Models
{
    public class MessageVM
    {
        public UserMessageVm User1 { get; set; }
        public UserMessageVm User2 { get; set; }
        public List<message> Messages { get; set; }
    }
    public class message
    {
        public string Messages { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
