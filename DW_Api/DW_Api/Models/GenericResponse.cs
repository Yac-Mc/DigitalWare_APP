using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DW_Api.Models
{
    public class GenericResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public GenericResponse()
        {
            StatusCode = (int)HttpStatusCode.OK;
            IsSuccessful = true;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
