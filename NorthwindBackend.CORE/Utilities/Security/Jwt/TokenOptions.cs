using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Security.Jwt
{
    public class TokenOptions   // token optionlarını appsettings.json'da tutucaz. (net core 2 deki gibi) nesnellik adına böyle yaptık
    {
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; } // dakika cinsinden yazıyoruz.

        public string SecurtiyKey { get; set; }  
    }
}
