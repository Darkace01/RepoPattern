using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Entity
    {
        public int ID { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
