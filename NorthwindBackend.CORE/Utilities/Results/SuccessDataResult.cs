using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Results
{
   public class SuccessDataResult<T>:DataResult<T>
    {
        // success data result için kullanılan bir sınıf

        public SuccessDataResult(T data, string message):base(data,true,message)
        {

            // başarılı olduğundan, success yerine true koycaz

        }

        public SuccessDataResult(T data):base(data,true)
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        public SuccessDataResult():base(default,true)
        {

        }
    }
}
