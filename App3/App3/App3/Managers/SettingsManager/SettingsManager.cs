using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Managers.SettingsManager
{
    public class SettingsManager : ISettingsManager
    {
        public string ApiHost
        {
            get
            {
                return "http://111.118.241.110/FieldApi/api/";
            }
        }
    }
}
