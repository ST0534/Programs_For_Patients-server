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
    public class LendRepository:ILendRepository
    {
        ProgramsPatients lendPatients;
        IMapper mapper;
        public LendRepository(ProgramsPatients lendPatients, IMapper mapper)
        {
            this.lendPatients = lendPatients;
            this.mapper = mapper;
        }
        public LendDTO GetLendById(int id)
        {
            Lend lend = lendPatients.Lends.Find(id);
            return mapper.Map<LendDTO>(lend);
        }
        public List<LendDTO> GetListOfLend()
        {
            List<Lend> lendListlist = lendPatients.Lends.ToList();
            return mapper.Map<List<LendDTO>>(lendListlist);
        }
        public void AddLend(LendDTO l)
        {
            lendPatients.Lends.Add(mapper.Map<Lend>(l));
            lendPatients.SaveChanges();
        }
        public void UpdateLend(LendDTO l)
        {
            lendPatients.Lends.Update(mapper.Map<Lend>(l));
            lendPatients.SaveChanges();
        }
        public void DeleteLend(LendDTO l)
        {
            lendPatients.Lends.Remove(mapper.Map<Lend>(l));
            lendPatients.SaveChanges();
        }
    }
}
