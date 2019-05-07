using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.NativeMethods
{
    public interface IIosMethods
    {
        void ShowToast(string msg);
        string GetIdentifier();
        Task<bool> CheckNewworkConnectivity();
    }
}
