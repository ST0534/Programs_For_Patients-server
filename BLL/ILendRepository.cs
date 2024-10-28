using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public interface ILendRepository
    {
        LendDTO GetLendById(int id);
        List<LendDTO> GetListOfLend();
        void AddLend(LendDTO l);
        void UpdateLend(LendDTO l);
        void DeleteLend(LendDTO l);

    }
}
