using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Security.Jwt
{
  public  class AccessToken
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; } // token'ın ne zamana kadar geçerli olduğu bilgisi



    }
}
