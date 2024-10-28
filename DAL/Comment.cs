using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }
        public int ProgramsId { get; set; }
        public virtual Programs Programs { get; set; }
        public int UsersId { get; set; }
        public virtual Users Users { get; set; }

    }
}
