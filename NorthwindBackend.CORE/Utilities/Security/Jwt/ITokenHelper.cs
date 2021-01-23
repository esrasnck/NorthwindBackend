using NorthwindBackend.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Security.Jwt
{
   public interface ITokenHelper
    {
        // biri diğerini referans ettiğinde, o diğeri bunu referans edemez :(

        // bunları ilk başta core kısmına koymamız gerekiyormuş...user ile useroperationclaim kısmını
       AccessToken CreateToken(User user, List<OperationClaim> operationClaims); // kullanıcı bilgisi ve rolleri verildi.
    }
}
