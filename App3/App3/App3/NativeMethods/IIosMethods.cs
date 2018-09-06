using System;
using System.Collections.Generic;
using System.Text;

namespace App3.NativeMethods
{
    public interface IIosMethods
    {
        void ShowToast(string msg);
        string GetIdentifier();
    }
}
