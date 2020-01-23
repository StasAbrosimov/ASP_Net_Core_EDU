using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebCoreMVC.Exstensions
{
    static public class EnumExstensions
    {
        public static int StatusToInt(this HttpStatusCode eObj)
        {
            return (int)eObj;
        }
    }
}
