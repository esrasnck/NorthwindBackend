using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Utilities.Results
{
   public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)
        {
            // succeess resultta direkt olarak mesajı geçmek istiyorum. bu sınıf işlemin başarılı olduğunu söylediği için default değer true
        }

        public SuccessResult():base(true)
        {

        }
    }
}
