using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Util
{
    public class GenerateOrderNoHelp
    {
        public static string GenerateOrderNo()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
