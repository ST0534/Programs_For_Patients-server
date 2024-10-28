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
    public class UsersRepository:IUsersRepository
    {
        ProgramsPatients usersPatients;
        IMapper mapper;
        public UsersRepository(ProgramsPatients usersPatients, IMapper mapper)
        {
            this.usersPatients = usersPatients;
            this.mapper = mapper;
        }
        public UsersDTO GetUserById(int id)
        {
            Users user= usersPatients.Users.Find(id);
            return mapper.Map<UsersDTO>(user);
        }
        public List<UsersDTO> GetListOfUsers()
        {
            List<Users> usersList= usersPatients.Users.ToList(); 
            return mapper.Map<List<UsersDTO>>(usersList);

        }

        public void AddUser(UsersDTO u)
        {
            usersPatients.Users.Add(mapper.Map<Users>(u));
            usersPatients.SaveChanges();
        }
        public void UpdateUsers(UsersDTO u)
        {
            usersPatients.Users.Update(mapper.Map<Users>(u));
            usersPatients.SaveChanges();
        }
        public void DeleteUsers(UsersDTO u)
        {
            usersPatients.Users.Remove(mapper.Map<Users>(u));
            usersPatients.SaveChanges();
        }

        public UsersDTO ExsistUser(UsersDTO u)
        {

            Users users = usersPatients.Users.Where(item => item.UserName == u.UserName ).FirstOrDefault();
            if (users == null)
                return null;
            return mapper.Map<UsersDTO>(users);
        }



    }
}
