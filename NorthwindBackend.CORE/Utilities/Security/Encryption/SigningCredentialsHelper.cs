using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Security.Encryption
{
   public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
