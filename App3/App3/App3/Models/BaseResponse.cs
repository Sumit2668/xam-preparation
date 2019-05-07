using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class BaseResponse
    {
        public string resultCode { get; set; }

        public string resultText { get; set; }
        public int FranchiseCode { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool success { get; set; }


        public BaseResponse()
        {
            resultText = "Network not response";
        }
    }
}
