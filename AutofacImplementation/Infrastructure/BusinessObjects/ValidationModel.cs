using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.BusinessObjects
{
    public class ValidationModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
