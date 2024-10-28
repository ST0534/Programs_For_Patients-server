using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string ProfilePicture { get; set; }
        public string MedicalCertificate { get; set; }
        public virtual List<Lend> Lend { get; set; }
        public virtual List<Comment> Comment { get; set; }
    }
}
