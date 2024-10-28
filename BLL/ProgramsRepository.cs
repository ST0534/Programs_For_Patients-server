using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DTO;

namespace BLL
{
    public class ProgramsRepository:IProgramsRepository 
    {

        ProgramsPatients programsPatients;
        IMapper mapper;
        public ProgramsRepository(ProgramsPatients programsPatients, IMapper mapper)
        {
            this.programsPatients = programsPatients;
            this.mapper = mapper;
        }
       public ProgramsDTO GetProgramsById(int id)
        {
            Programs program= programsPatients.Programs.Find(id);
            return mapper.Map<ProgramsDTO>(program);
        }
        public List<ProgramsDTO> GetListOfPrograms()
        {
            List <Programs> programs = programsPatients.Programs.ToList();
            return mapper.Map<List<ProgramsDTO>>(programs);
        }
      
        public void AddProgram(ProgramsDTO p)
        {
            programsPatients.Programs.Add(mapper.Map< Programs>(p));
            programsPatients.SaveChanges();
        }
        public void UpdateProgram(ProgramsDTO p)
        {
            programsPatients.Programs.Update(mapper.Map<Programs>(p));
            programsPatients.SaveChanges();
        }
        public void DeleteProgram(ProgramsDTO p)
        {
            programsPatients.Programs.Remove(mapper.Map<Programs>(p));
            programsPatients.SaveChanges();
        }
        

    }
}
