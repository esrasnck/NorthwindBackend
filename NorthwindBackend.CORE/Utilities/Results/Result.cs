using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)  // => başka bir constractor'ı tetiklemek. yorum satırına aldığım yer ile aynı
        {
            Message = message;

            //  Success = success;

        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
