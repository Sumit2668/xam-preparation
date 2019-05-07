using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class GetEmployeeRequest : CommonRequest
    {
        public string EmployeeId { get; set; }
        public string Status { get; set; }
    }

    public class CommonRequest
    {
        public int FranchiseeCode { get; set; }
        public string TeamCode { get; set; }
        public DateTime? DateVisit { get; set; }
        public int PropertyId { get; set; }
    }
}
