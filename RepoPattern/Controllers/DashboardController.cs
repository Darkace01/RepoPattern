using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoPattern.Models;
using RepoPattern.Models.ViewModel;
using Service.Contracts;

namespace RepoPattern.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        public DashboardController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
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
                Tags = p.Tags,
                DateCreated = p.DateCreated,
                UserName = p.ApplicationUser.FullName
            }).ToList();

            return View(posts);
        }

        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(AddPostViewModel model, List<String> classTags)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = GetLoggedInUser();
                    string classT = classTags != null ? String.Join(",", classTags) : "";

                    Post post = new Post
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Content = model.Content,
                        Tags = classT,
                        ApplicationUser = user,
                        IconUri = "https://image.freepik.com/free-vector/farmer-peasant-illustration-man-with-beard-spade-farmland_33099-575.jpg",
                        IsDeleted = false,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };

                    _postService.CreatePost(post);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{Id}")]
        public IActionResult EditPost(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
        }

        private ApplicationUser GetLoggedInUser()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.GetUserById(userId);
            return user;
        }
    }
}