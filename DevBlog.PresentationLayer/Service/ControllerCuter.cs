using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.PresentationLayer.Service
{
    public static class ControllerCuter
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }
    }
}
