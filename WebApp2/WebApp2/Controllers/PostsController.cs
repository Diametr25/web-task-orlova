using Microsoft.AspNetCore.Mvc;
using WebApp2.DAL.Interfaces;
using WebApp2.Models;
using WebApp2.BLL.Services;
using WebApp2.DAL.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http.Json;

namespace WebApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly PostService postService;

        public PostsController(PostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            return Json(postService.GetPostList(), jsonOptions);
        }


        [HttpPost("Add")]
        public ActionResult Add([FromBody] AddPostViewModel addpostrequest)
        {
                var post = new Post()
                {
                    Guid = Guid.NewGuid(),
                    Code = addpostrequest.Code,
                    Name = addpostrequest.Name
                };
                postService.Add(post);
                return Json(post);
            
        }

        [HttpGet("View/{id}")]
        public IActionResult View(int id)
        {
                var post = postService.GetPost(id);
                if (post != null)
                {
                    var viewModel = new UpdatePostViewModel()
                    {
                        Id = post.Id,
                        Guid = post.Guid,
                        Code = post.Code,
                        Name = post.Name
                    };
                    return View("View", viewModel);
                }
                return RedirectToAction("Index");
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdatePostViewModel model)
        {
            var post = postService.GetPost(model.Id);

            if (post != null)
            {
                post.Code = model.Code;
                post.Name = model.Name;

                postService.Save();
            }

            return Json(post);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] UpdatePostViewModel model)
        {
            postService.Delete(model.Id);
            //return Json(model.Id);
            return Json(postService.GetPostList());
        }
    }
}
