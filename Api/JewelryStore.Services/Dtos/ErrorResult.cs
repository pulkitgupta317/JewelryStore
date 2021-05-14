using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.Services.Dtos
{
    public class ErrorResult
    {
        public bool IsSuccess { get; set; }

        public int Status { get; set; }

        public string ErrorMessage { get; set; }
    }
}
