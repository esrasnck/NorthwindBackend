using NorthwindBackend.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Entities.Concrete
{
   public  class OperationClaim:IEntity // kullanıcı rolleri
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
