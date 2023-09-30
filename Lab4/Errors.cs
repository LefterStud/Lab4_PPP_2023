using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Errors
    {
        static int errorCode = 0;
        public static int ErrorCode
        {
            get => ErrorCode;
            set => ErrorCode = value;
        }

        static string[] errorsArray = {
            "",
            "Ivalid hour data",
            "Invalid minute data",
            "Invalid second data",
            "Invalid time",
        };

        public static string GetError(int errorCode)
        {
            return errorsArray[errorCode];
        }
    }
}
