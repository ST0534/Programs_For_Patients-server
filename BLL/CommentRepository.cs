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
    public class CommentRepository:ICommentRepository
    {
        ProgramsPatients commentPatients;
        IMapper mapper;
        public CommentRepository(ProgramsPatients commentPatients, IMapper mapper)
        {
            this.commentPatients = commentPatients;
            this.mapper = mapper;
        }
        public CommentDTO GetCommentById(int id)
        {
            Comment comment = commentPatients.Comments.Find(id);
            return mapper.Map<CommentDTO>(comment);
        }

        public List<CommentDTO> GetListOfComment()
        {
            List<Comment> commentlist = commentPatients.Comments.ToList();
            return mapper.Map<List<CommentDTO>>(commentlist);

        }
        public void AddComment(CommentDTO c)
        {
            commentPatients.Comments.Add(mapper.Map<Comment>(c));
            commentPatients.SaveChanges();
        }
        public void UpdateComment(CommentDTO c)
        {
            commentPatients.Comments.Update(mapper.Map<Comment>(c));
            commentPatients.SaveChanges();
        }
        public void DeleteComment(CommentDTO c)
        {
            commentPatients.Comments.Remove(mapper.Map<Comment>(c));
            commentPatients.SaveChanges();
        }

    }
}
