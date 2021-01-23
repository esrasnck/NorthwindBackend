using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Results
{
   public interface IDataResult<out T>: IResult
    {
        /// <summary>
        /// data result'ın hata sınıfı (generic)
        /// </summary>
        T Data { get; }
    }
}
