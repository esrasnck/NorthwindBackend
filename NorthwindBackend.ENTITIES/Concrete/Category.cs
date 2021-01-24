using NorthwindBackend.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.ENTITIES.Concrete
{
   public class Category:IEntity
    { 
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
     
    }
}
