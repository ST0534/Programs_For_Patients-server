using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LendDTO
    {
        public int Id { get; set; }
        public DateTime DateLend { get; set; }
        public DateTime DateReturn { get; set; }
        public int ProgramsId { get; set; }
        public  ProgramsDTO? Programs { get; set; }

        public int UsersId { get; set; }
        public  UsersDTO? Users { get; set; }
    }
}
