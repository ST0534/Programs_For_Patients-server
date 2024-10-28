using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CommentDTO
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }
        public int ProgramsId { get; set; }
        public  ProgramsDTO? Programs { get; set; }
        public int UsersId { get; set; }
        public  UsersDTO? Users { get; set; }
    }
}
