using App3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.CustomControls
{
    public class TeamMemberDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Free { get; set; }

        public DataTemplate Bussy { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((EmployeeMdl)item).Isbusy == false ? Free : Bussy;
        }
    }
}
