using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nancy;

namespace wall_e_API.Control
{
    public class _main : NancyModule
    {
        public _main() {
            Get["/"] = parameters => "Hello World";
        }
    }
}