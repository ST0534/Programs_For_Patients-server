using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Lend
    {
        public int Id { get; set; }
        public DateTime DateLend { get; set; }
        public DateTime DateReturn { get; set; }
        public int ProgramsId { get; set; }
        public virtual Programs Programs { get; set; }

        public int UsersId { get; set; }
        public virtual Users Users { get; set; }



    }
}
