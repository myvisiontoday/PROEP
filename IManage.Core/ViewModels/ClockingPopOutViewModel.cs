using IManage.Core.IManageClockService;
using IManage.Core.IManageEmployeeService;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Controls;
using ClockInOut = IManage.Core.IManageClockService.ClockInOut;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of ClockingPopOut View
    /// </summary>
    public class ClockingPopOutViewModel : BaseEmployeeViewModel
    {
        #region Private Data

        private readonly ClockServiceClient _clockServiceClient;

        private readonly EmployeeServiceClient _employeeServiceClient;

        private string _passWord;

        #region Bindings

        private Message? _message;

        #endregion

        #region Commands

        private MvxCommand<PasswordBox> _clockedInButtonClickCommand;
        #endregion

        #endregion

        #region Properties

        #region Bindings

        public Message? Message
        {
            get => _message;
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        #endregion

        #region Commands

        public MvxCommand<PasswordBox> ClockedInButtonClickCommand
        {
            get
            {
                _clockedInButtonClickCommand = _clockedInButtonClickCommand ?? new MvxCommand<PasswordBox>(WhenClockedInButtonClicked);
                return _clockedInButtonClickCommand;
            }
        }

        #endregion
        #endregion

        #region Constructor

        public ClockingPopOutViewModel()
        {
            _clockServiceClient = new ClockServiceClient();
            _employeeServiceClient = new EmployeeServiceClient();
            Message = null;
        }
        #endregion

        #region Private Methods

        #region Callback methods of button click

        private void WhenClockedInButtonClicked(PasswordBox passwordBox)
        {
            if ((_clockServiceClient != null) && (_employeeServiceClient != null))
            {


                if (!string.IsNullOrEmpty(passwordBox.Password))
                {
                    _employeeServiceClient.IsEmployeeClockedInCompleted += IsEmployeeClockedInCompleted;
                    _employeeServiceClient.IsEmployeeClockedInAsync(passwordBox.Password);
                    _passWord = passwordBox.Password;
                }
                else
                {
                    Message = Models.Message.FieldCannotBeEmpty;
                }
            }
        }
        #endregion

        #region Callback methods of Service 

        #region EmployeeService
        private void IsEmployeeClockedInCompleted(object sender, IsEmployeeClockedInCompletedEventArgs e)
        {
            _employeeServiceClient.IsEmployeeClockedInCompleted -= IsEmployeeClockedInCompleted;
            if (!e.Result)
            {
                _clockServiceClient.ClockInCompleted += ClockInCompleted;
                ClockInOut clockInOut = new ClockInOut { ClockInDateTime = DateTime.Now, ClockOutDateTime = null };
                _clockServiceClient.ClockInAsync(_passWord, clockInOut);
            }
            else
            {
                _clockServiceClient.ClockOutCompleted += ClockOutCompleted;
                _clockServiceClient.ClockOutAsync(_passWord, DateTime.Now);
            }
        }
        #endregion

        #region ClockInService
        private void ClockInCompleted(object sender, ClockInCompletedEventArgs e)
        {
            _clockServiceClient.ClockInCompleted -= ClockInCompleted;
            if (e.Result)
            {
                Message = Models.Message.ClockedIn;
                ShowViewModel<EmployeeViewModel>();
            }
            else
            {
                Message = Models.Message.ErrorTryAgain;
            }
        }
        private void ClockOutCompleted(object sender, ClockOutCompletedEventArgs e)
        {
            _clockServiceClient.ClockOutCompleted -= ClockOutCompleted;
            if (e.Result)
            {
                Message = Models.Message.ClockedOut;
                ShowViewModel<EmployeeViewModel>();
            }
            else
            {
                Message = Models.Message.ErrorTryAgain;
            }
        }
        #endregion

        #endregion
        #endregion
    }
}
