using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NorthwindBackend.CORE.Entities.Concrete;
using NorthwindBackend.CORE.Extentions;
using NorthwindBackend.CORE.Utilities.Security.Encryption;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {

        // toker options ikonfigurasyon dosyasında okumak olacak  (appsetting.json 'daki)

        // IConfiguration extention metot. peki...

        public IConfiguration Configuration { get; }

        TokenOptions _tokenOptions;

        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;   // configurasyon dosyası ile oradan gelen token ayarlarını (appsettingsteki bilgiyi) bu yapı ile okuyacağız

            // bunu şu şekilde okuycaz
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // bu nesneye bind edebiliyoruz.

            // .net core, bu token options bilgilerini alıp, bu nesneye bind ediyor. (herşeyi bu token option içerisine atmış olduk)
             
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);  // => artık elimizde bir tarih var.
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurtiyKey); // tokeni şifreli oluşturcaz. bunu encrtyp ederken bir anahta ihtiyacımız var.

            // signing credantials. bizim security key ve algoritmamızı belirlediğimiz bir nesnedir. => bunu da helperla yazıyoruz

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            // kullanıcı rolleri ve bilglilerini parametre olarak verip bir adet parametre oluşturmak istiyyorum

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);  // yaa çok güzel:) aşağıdaki metot.

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var token = jwtSecurityTokenHandler.WriteToken(jwt);  // write token ile stringe e çevirdik.

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken (TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken( // json web token'ın lazım olan kısımları
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
               /* expires:tokenOptions.AccessTokenExpiration,*/  //=> expriation ı int tuttuk tarih yapacaz
                expires: _accessTokenExpiration,
                notBefore:DateTime.Now, // eğer token bilgisi şu andan önce ise geçerli değil. şart bu 
                claims:SetClaims(user,operationClaims),
                signingCredentials:signingCredentials

                );
            return jwt;
        }
        // claim set edeceğimiz operasyon

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }
    }
}
