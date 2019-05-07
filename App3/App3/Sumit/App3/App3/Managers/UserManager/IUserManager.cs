using App3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Managers.UserManager
{
    public interface IUserManager
    {
        Task GetAllEmployeeList(GetEmployeeRequest request, Action success, Action<GetAllEmployeeListResponse> failed);

        GetAllEmployeeListResponse GetAllEmployeeListResponse { get; }
    }
}
