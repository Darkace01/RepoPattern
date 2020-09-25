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
