using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App3.Models
{
    public class GetAllEmployeeListResponse : BaseResponse
    {
        [JsonProperty("EmployeeList")]
        public ObservableCollection<EmployeeMdl> EmployeeList { get; set; }
        public List<EmployeeMdl> SelectEmployeeList { get; set; }
    }
    public class EmployeeMdl
    {
        public int EmployeeID { get; set; }
        public int FranchiseCode { get; set; }
        public int EmployeeNumber { get; set; }
        public string FullName
        {
            get { return string.Format($"{FirstName} {LastName}"); }
        }
        public string Address
        {
            get { return string.Format($"{Address1}, {Address2} , {City}"); }
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public object SocialSecurityNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string EMail { get; set; }
        public DateTime? Birthday { get; set; }
        public string Position { get; set; }
        public string EmployeeImg { get; set; } = "https://secure.gravatar.com/avatar/7d1f32b86a6076963e7beab73dddf7ca?s=116&d=mm&r=g";
        public bool Isbusy { get; set; }
        public bool IsAvailable { get; set; }
        public string CheckBox { get; set; } = "chackbox.png";


    }
    public class GetEmployeeResponse : BaseResponse
    {
        public EmployeeMdl EmployeeMdl { get; set; }
    }
}
