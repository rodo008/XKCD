
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Response : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { set; get; }

        public int StatusCode {get; set;}

        public T GetData<T>() where T : class
        {
            if (Data.GetType() == typeof(T))
                return (T)Data;
            else
                return null;             
        }


        /// <summary>
        /// this field indicate navigation action taken for user. This data will be util when not data return back from remote URL.
        /// </summary>
        public Boolean NextAction { get; set; }
    }
}
