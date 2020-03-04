
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ResponseFactory
    {
        public static IResponse GetResponse() {
            return new Response();
        }
    }
}
