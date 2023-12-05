using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService:IGenericService<Comment>
	{
		void CommentAdd(Comment comment);

		//void CommentDelete(Comment comment);
		//void CommentUpdate(Comment comment);
		List<Comment> GetList(int id);

        List<Comment> GetCommentListWithBlog();

        //Comment GetById(int id);
    }
}
