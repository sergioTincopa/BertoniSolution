using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniSolution.Web.Models
{
    public class ResponseModel
    {
        public object Result { get; set; }
        public string AuthenticationServiceError { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
