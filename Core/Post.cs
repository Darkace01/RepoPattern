using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Post : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string IconUri { get; set; }
        public string Tags { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
