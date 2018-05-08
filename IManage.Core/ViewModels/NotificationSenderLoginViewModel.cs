using IManage.Core.IManageEmployeeService;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using System.Windows.Controls;

namespace IManage.Core.ViewModels
{
    public class NotificationSenderLoginViewModel : BaseEmployeeViewModel
    {
        #region Private Data

        protected readonly EmployeeServiceClient EmployeeServiceClient;

        #region Bindings
        private Message? _message;
        #endregion

        #region Commands

        private MvxCommand<PasswordBox> _loginButtonClickCommand;

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

        public MvxCommand<PasswordBox> LoginButtonClickCommand
        {
            get
            {
                _loginButtonClickCommand = _loginButtonClickCommand ?? new MvxCommand<PasswordBox>(WhenLoginButtonClick);
                return _loginButtonClickCommand;
            }
        }

        #endregion

        #endregion

        #region Constructor

        public NotificationSenderLoginViewModel()
        {
            Message = null;
            EmployeeServiceClient = new EmployeeServiceClient();
        }
        #endregion

        #region Private Methods

        #region Callback Methods for button click

        protected void WhenLoginButtonClick(PasswordBox passwordBox)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password))
            {
                if (EmployeeServiceClient != null)
                {
                    EmployeeServiceClient.GetEmployeeWithGivenPinCodeCompleted += GetEmployeeWithGivenPinCodeCompleted;
                    EmployeeServiceClient.GetEmployeeWithGivenPinCodeAsync(passwordBox.Password);
                }
            }
            else
            {
                Message = Models.Message.FieldCannotBeEmpty;
            }
        }


        #endregion

        #region Service Callback methods

        protected virtual void GetEmployeeWithGivenPinCodeCompleted(object sender, GetEmployeeWithGivenPinCodeCompletedEventArgs e)
        {
            EmployeeServiceClient.GetEmployeeWithGivenPinCodeCompleted -= GetEmployeeWithGivenPinCodeCompleted;
            if (e.Result != null)
            {
                Message = Models.Message.LoggedIn;
                ShowViewModel<NotificationViewModel>(new EmployeeDetailParameter { Pincode = e.Result.PinCode, Id = e.Result.EmployeeId });
            }
            else
            {
                Message = Models.Message.ErrorTryAgain;
            }
        }

        #endregion

        #endregion
    }
}
