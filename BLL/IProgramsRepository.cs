using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public interface IProgramsRepository
    {
        ProgramsDTO GetProgramsById(int id);
        List<ProgramsDTO> GetListOfPrograms();
        void AddProgram(ProgramsDTO p);
        void UpdateProgram(ProgramsDTO p);
        void DeleteProgram(ProgramsDTO p);



    }
}
