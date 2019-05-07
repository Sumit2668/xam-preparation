using Acr.UserDialogs;
using App3.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App3.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel()
        {
        }


        #region Properties

        private bool isEnabledOk;
        public bool IsEnabledOk
        {
            get { return isEnabledOk; }
            set { isEnabledOk = value; RaisePropertyChanged(() => IsEnabledOk); }
        }
        private string employeeId;
        public string EmployeeId
        {
            get { return employeeId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    IsEnabledOk = false;
                }
                else
                {
                    IsEnabledOk = true;
                }
                employeeId = value.ToUpper(); RaisePropertyChanged(() => EmployeeId);
            }
        }
        private bool isEnableSignIn;
        public bool IsEnableSignIn
        {
            get { return isEnableSignIn; }
            set { isEnableSignIn = value; RaisePropertyChanged(() => IsEnableSignIn); }
        }

        private ObservableCollection<EmployeeMdl> employeeList = new ObservableCollection<EmployeeMdl>();
        public ObservableCollection<EmployeeMdl> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; RaisePropertyChanged(() => EmployeeList); }
        }

        private ObservableCollection<EmployeeMdl> teamMembers = new ObservableCollection<EmployeeMdl>();
        public ObservableCollection<EmployeeMdl> TeamMembers
        {
            get { return teamMembers; }
            set { teamMembers = value; RaisePropertyChanged(() => TeamMembers); }
        }

        private EmployeeMdl teamMember = new EmployeeMdl();
        public EmployeeMdl TeamMember
        {
            get { return teamMember; }
            set { teamMember = value; RaisePropertyChanged(() => TeamMember); }
        }
        #endregion

        #region Command
        public RelayCommand GetAllEmployeeListCommand => new RelayCommand(() => GetAllEmployeeListExcute());
        #endregion


        #region CommandExecution
        public void GetAllEmployeeListExcute()
        {
            try
            {
                var request = new GetEmployeeRequest
                {
                    FranchiseeCode = 250,
                    TeamCode = "TC01",
                    DateVisit = DateTime.Now,
                    //EmployeeId = EmployeeId
                };
                //UserDialogs.Instance.ShowLoading();
                userManager.GetAllEmployeeList(request, () =>
                {
                    //UserDialogs.Instance.HideLoading();
                    var response = userManager.GetAllEmployeeListResponse;
                    if (response.ErrorCode == 200)
                    {
                        EmployeeList = new ObservableCollection<EmployeeMdl>(response.EmployeeList);
                        TeamMembers = new ObservableCollection<EmployeeMdl>();
                        foreach (var item in response.SelectEmployeeList)
                        {
                            EmployeeList.Where(x => x.EmployeeNumber == item.EmployeeNumber).ToList().ForEach(u =>
                            {
                                u.Isbusy = false;
                                u.IsAvailable = true;
                                u.CheckBox = "checkboxgreen.png";
                                TeamMember = item;
                                AddEmployeeExecute();
                            });
                        }

                        EmployeeList.Where(x => x.IsAvailable == true || x.EmployeeImg == null).ToList().ForEach(u =>
                        {
                            u.Isbusy = false;
                            u.EmployeeImg = "https://www.genesisholdingus.com/wp-content/uploads/2016/02/daniel_clark-350x350.jpg";
                        });
                        var em = EmployeeList.OrderByDescending(x => x.CheckBox).OrderBy(x => x.Isbusy == true);
                        EmployeeList = new ObservableCollection<EmployeeMdl>(em);
                        //Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.Navigation.PushAsync(new TeamMemberSignInView()));
                    }
                    else
                    {
                        UserDialogs.Instance.Alert(response.ErrorMessage, null, "OK");
                    }
                },
                 (failur) =>
                 {
                     UserDialogs.Instance.HideLoading();
                     UserDialogs.Instance.Alert(failur.ErrorMessage, null, "OK");
                 });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
            }
        }
        #endregion
        public void AddEmployeeExecute()
        {
            try
            {
                //if (TeamMembers != null)
                //{
                //    foreach (var i in TeamMembers)
                //    {
                //        if (i.EmployeeID == TeamMember.EmployeeID)
                //        {
                //            UserDialogs.Instance.Alert("Employee have allready added.", null, "OK");
                //            return;
                //        }
                //    }
                //}
                TeamMembers.Add(TeamMember);
                IsEnableSignIn = true;
                //ListHeight = TeamMembers.Count>=5?275:((TeamMembers.Count) * 55) + 55;
                //Device.BeginInvokeOnMainThread(async () => await PopupNavigation.Instance.PopAsync());
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
            }
        }

    }
}
