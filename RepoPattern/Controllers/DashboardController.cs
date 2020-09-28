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
            IEnumerable<ViewPostViewModel> posts = _postService.GetAllPostByUserId(GetLoggedInUser().Id)
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
                    string classT = classTags != null ? String.Join(",", classTags) : "";
                    string url = model.Title != null ? String.Join(" ", model.Title) : "-";
                    Post post = new Post
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Content = model.Content,
                        Tags = classT,
                        ApplicationUser = GetLoggedInUser(),
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
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + ex);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{Action}/{Id}")]
        public IActionResult EditPost(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var posts = _postService.GetPostByIdandUserId(Id.Value, GetLoggedInUser().Id);
            if(posts == null)
            {
                return NotFound();
            }
            EditPostViewModel post = new EditPostViewModel();

            post.Id = posts.ID;
            post.Title = posts.Title;
            post.Description = posts.Description;
            post.Content = posts.Content;
            List<string> tags = posts.Tags.Split(',').ToList();

            ViewBag.ClassTags = tags;

            return View(post);
        }

        [HttpPost("{Action}/{Id}")]
        public IActionResult EditPost(EditPostViewModel model, List<string> classTags)
        {
            if (ModelState.IsValid)
            {
                var user = GetLoggedInUser();
                string classT = classTags != null ? String.Join(",", classTags) : "";
                var oldPost = _postService.GetPostByIdandUserId(model.Id, user.Id);

                oldPost.Title = model.Title;
                oldPost.Description = model.Description;
                oldPost.Content = model.Content;
                oldPost.Tags = classT;
                oldPost.IconUri = "https://image.freepik.com/free-vector/farmer-peasant-illustration-man-with-beard-spade-farmland_33099-575.jpg";
                oldPost.DateModified = DateTime.Now;

                _postService.UpdatePost(oldPost);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public JsonResult IsPostNameExist(string title)
        {
            var post = _postService.IsTitleExist(title, GetLoggedInUser().Id);
            if(post)
            {
                return Json($"Title \" {title} \" is already in use.");
            }
            return Json(true);
        }

        private ApplicationUser GetLoggedInUser()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.GetUserById(userId);
            return user;
        }
    }
}