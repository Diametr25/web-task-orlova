using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.DAL.Data;
using WebApp2.DAL.Models;

namespace WebApp2.DAL.Interfaces
{
    public class PostRepository
    {
        private readonly AccountingDbContext mvcAccountingDbContext;
        public PostRepository(AccountingDbContext mvcAccountingDbContext)
        {
            this.mvcAccountingDbContext = mvcAccountingDbContext;
        }
        public IEnumerable<Post> GetPostList()
        {
            return mvcAccountingDbContext.Posts.ToList();
        }
        public Post GetPost(int id)
        {
            return mvcAccountingDbContext.Posts.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Post post) 
        {
            mvcAccountingDbContext.Posts.Add(post);
            mvcAccountingDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var post = GetPost(id);
            if (post != null)
            {
                mvcAccountingDbContext.Remove(post);
                mvcAccountingDbContext.SaveChanges();
            }
        }
        public void Save()
        {
            mvcAccountingDbContext.SaveChanges();
        }
    }
}
