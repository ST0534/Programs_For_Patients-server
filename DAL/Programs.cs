using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Programs
    {
     public int Id { get; set; }
     public string ProgramName { get; set; }
     public string ProducerName { get; set; }
     public string Trailer { get; set; }
     public string Duration { get; set; }
     public string Description { get; set; }
     public virtual List<Lend>Lend { get; set; }
     public int CategoryId { get; set; }
     public virtual Category Category { get; set; }
     public virtual List<Comment> Comment { get; set; }


    }
}
