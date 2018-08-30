using System;
using System.Collections.Generic;
using System.Text;

namespace Lands_V9.Models
{
    class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
