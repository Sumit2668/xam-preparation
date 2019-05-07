using App3.Managers.SettingsManager;
using App3.Managers.UserManager;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App3.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase
    {
        #region Variables
        protected readonly IUserManager userManager;
        protected readonly ISettingsManager settingsManager;
        private readonly Dictionary<string, object> _propertyValues = new Dictionary<string, object>();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private bool _isBusy;
        #endregion

        #region Properties
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        private bool isEmpty;
        public bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                isEmpty = value;
                RaisePropertyChanged(() => IsEmpty);
            }
        }

        #endregion

        #region Constructor
        public BaseViewModel()
        {
            userManager = SimpleIoc.Default.GetInstance<IUserManager>();
            settingsManager = SimpleIoc.Default.GetInstance<ISettingsManager>();
        }
        #endregion

        #region Methods
        private void RaisePropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
