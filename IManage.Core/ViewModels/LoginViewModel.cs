using IManage.Core.IManageLoginService;
using IManage.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Controls;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of LogIn View
    /// </summary>
    public class LogInViewModel : MvxViewModel
    {
        #region Private Data
        /// <summary>
        /// Reference to login service instance
        /// </summary>
        private readonly LoginServiceClient _loginServiceClient;

        /// <summary>
        /// Error message
        /// </summary>
        private string _errorMessage;
        #endregion

        #region Commands
        /// <summary>
        /// Command to navigate to ManagerChoiceViewModel
        /// </summary>
        private IMvxCommand _managerChoiceViewModelCommand;
        #endregion

        #region Constructor

        public LogInViewModel()
        {
            _loginServiceClient = new LoginServiceClient();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets client user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets and sets error message
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);

            }
        }

        /// <summary>
        ///Command to navigate to ManagerChoiceViewModel
        /// </summary>
        public IMvxCommand ManagerChoiceViewModelCommand
        {
            get
            {
                _managerChoiceViewModelCommand = _managerChoiceViewModelCommand ?? new MvxCommand<PasswordBox>(NavigateToMangerChoiceViewModel);
                return _managerChoiceViewModelCommand;
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Navigate to manager choice view model
        /// </summary>
        private void NavigateToMangerChoiceViewModel(PasswordBox passwordBox)
        {
            ErrorMessage = string.Empty;

            //ShowViewModel<ManagerChoiceViewModel>();

            //Debug.Assert((UserName != null) && (passwordBox.Password != null));

            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(passwordBox.Password))
            {
                _loginServiceClient.GetClientCompleted += LoginServiceClient_GetClientCompleted;
                _loginServiceClient.GetClientAsync(UserName, passwordBox.Password);
            }
            else
            {
                if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(passwordBox.Password))
                {
                    ErrorMessage = "Please, enter username and password";
                    return;
                }

                if (string.IsNullOrEmpty(UserName))
                {
                    ErrorMessage = "Please, enter user name";
                    return;
                }

                if (string.IsNullOrEmpty(passwordBox.Password))
                {
                    ErrorMessage = "Please, enter password";
                }
            }
        }

        private void LoginServiceClient_GetClientCompleted(object sender, GetClientCompletedEventArgs e)
        {
            Client client = e.Result;
            if (client != null)
            {
                if (!client.IsSubscriptionsExpired)
                {
                    ShowViewModel<ManagerChoiceViewModel>(new ClientDetailParameter { Name = UserName });
                }
                else
                {
                    ErrorMessage = "Subscriptions Expired";
                }
                _loginServiceClient.GetClientCompleted -= LoginServiceClient_GetClientCompleted;
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }
        #endregion
    }
}
