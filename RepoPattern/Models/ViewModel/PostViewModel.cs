using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepoPattern.Models.ViewModel
{
    public class AddPostViewModel
    {
        [Required]
        [Remote(action: "IsPostNameExist", controller: "Dashboard", ErrorMessage = "The Title Already exists, Kindly pick a different one")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        public string IconUri { get; set; }
        public string Tags { get; set; }
    }

    public class ViewPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string IconUri { get; set; }
        public string Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }
        public List<LatestPostViewModel> Posts { get; set; }

    }

    public class LatestPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUri { get; set; }
        public DateTime DateCreated { get; set; }
        public string Fullname { get; set; }
    }

    public class EditPostViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Remote(action: "IsPostNameExist", controller: "Dashboard", ErrorMessage = "The Title Already exists, Kindly pick a different one")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string IconUri { get; set; }
        public string Tags { get; set; }

    }
}