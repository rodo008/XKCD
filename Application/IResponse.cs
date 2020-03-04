using System;


namespace Application
{
    public interface IResponse
    {
        Boolean Success { get; set; }
        String Message { get; set; }
        
    }
}
