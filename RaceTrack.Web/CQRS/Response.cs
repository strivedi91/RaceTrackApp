using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack.Web.CQRS
{    
    public class Response<T>
    {
        public Response(T data, string message, string error)
        {
            Data = data;
            Message = message;
            Error = error;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
}
