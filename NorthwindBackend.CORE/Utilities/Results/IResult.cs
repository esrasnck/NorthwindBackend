using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Results
{
   public  interface IResult
    {
        // hata yönetimi için yapıldı !!!

        /// <summary>
        /// yapılan işlem başarılı mı?
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// yapılan işlemin mesajı => başarılı oldu mu olmadı mı?
        /// </summary>
        string Message { get; }
    }
}
