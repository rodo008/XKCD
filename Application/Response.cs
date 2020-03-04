
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Response:IResponse 
    {
        public bool Success { get ; set; }
        public string Message { get ; set; }        
        public Object Data { set; get; } 

        public T GetData<T>() where T : class
        {
            if (Data.GetType() == typeof(T))
                return (T)Data;
            else
                return null;             
        }
    }
}
