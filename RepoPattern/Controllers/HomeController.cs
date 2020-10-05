using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepoPattern.Models;
using RepoPattern.Models.ViewModel;
using Service.Contracts;

namespace RepoPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {

            IEnumerable<ViewPostViewModel> posts = _postService.GetAllPosts()
            .Select(p => new ViewPostViewModel
            {
                Id = p.ID,
                Content = p.Content,
                Title = p.Title,
                Description = p.Description,
                IconUri = p.IconUri,
                Tags = p.Tags,
                DateCreated = p.DateCreated
            }).ToList();

            return View(posts);
        }

        [HttpGet("{Action}/{Id}")]
        public IActionResult Post(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var p = _postService.GetPostById(Id.Value);
            List<LatestPostViewModel> posts = _postService.GetAllPosts()
                .Select(l => new LatestPostViewModel {
                    Id = l.ID,
                    Title = l.Title,
                    IconUri = l.IconUri,
                    Description = l.Description,
                    DateCreated = l.DateCreated,
                    Fullname = l.ApplicationUser.FullName,
                    PostUrl = l.PostUrl
                }).ToList();
           if(p != null)
            {
                ViewPostViewModel post = new ViewPostViewModel()
                {
                    Id = p.ID,
                    Content = p.Content,
                    DateCreated = p.DateCreated,
                    Description = p.Description,
                    IconUri = p.IconUri,
                    Tags = p.Tags,
                    Title = p.Title,
                    UserName = p.ApplicationUser.FullName,
                    Posts = posts,
                    PostUrl = p.PostUrl
                };
                
                return View(post);
            }
            return NotFound();
        }

        [HttpGet("{postUrl}")]
        public IActionResult Post(string postUrl)
        {
            if (postUrl == null)
            {
                return NotFound();
            }
            var p = _postService.GetPostByUrlOnly(postUrl);
            List<LatestPostViewModel> posts = _postService.GetAllPosts()
                .Select(l => new LatestPostViewModel
                {
                    Id = l.ID,
                    Title = l.Title,
                    IconUri = l.IconUri,
                    Description = l.Description,
                    DateCreated = l.DateCreated,
                    Fullname = l.ApplicationUser.FullName,
                    PostUrl = l.PostUrl
                }).ToList();
            if (p != null)
            {
                ViewPostViewModel post = new ViewPostViewModel()
                {
                    Id = p.ID,
                    Content = p.Content,
                    DateCreated = p.DateCreated,
                    Description = p.Description,
                    IconUri = p.IconUri,
                    Tags = p.Tags,
                    Title = p.Title,
                    UserName = p.ApplicationUser.FullName,
                    Posts = posts,
                    PostUrl = p.PostUrl
                };

                return View(post);
            }
            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
