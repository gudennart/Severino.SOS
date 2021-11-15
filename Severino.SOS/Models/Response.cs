using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Severino.SOS.Models
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
}
