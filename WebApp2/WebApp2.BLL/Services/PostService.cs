using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.DAL.Data;
using WebApp2.DAL.Interfaces;
using WebApp2.DAL.Models;

namespace WebApp2.BLL.Services
{
    public class PostService
    {
        private readonly PostRepository postRepository;
        public PostService(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public void Add(Post post)
        {
            postRepository.Add(post);
        }

        public IEnumerable<Post> GetPostList()
        {
            var post = postRepository.GetPostList();
            return post;
        }

        public Post GetPost(int id)
        {
            return postRepository.GetPost(id);
        }
        public void Delete(int id)
        {
            postRepository.Delete(id);
        }
        public void Save()
        {
            postRepository.Save();
        }
    }

}
