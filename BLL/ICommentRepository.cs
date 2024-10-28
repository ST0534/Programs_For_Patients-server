using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public interface ICommentRepository
    {
        CommentDTO GetCommentById(int id);
        List<CommentDTO> GetListOfComment();
        void AddComment(CommentDTO c);
        void UpdateComment(CommentDTO c);
        void DeleteComment(CommentDTO c);


    }
}
