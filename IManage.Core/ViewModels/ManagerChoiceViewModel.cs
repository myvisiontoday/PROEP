using IManage.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of ManagerChoice View
    /// </summary>
    public class ManagerChoiceViewModel : MvxViewModel
    {
        #region Private Data

        #region Commands
        /// <summary>
        /// Command to navigate to LogInViewModel
        /// </summary>
        private ICommand _logInViewModelCommand;

        /// <summary>
        /// Command to navigate to ManagerViewModel or EmployeeViewModel
        /// </summary>
        private ICommand _managerOrManagerDecisionViewModelCommand;
        #endregion

        #endregion

        #region Properties
        public ClientDetailParameter ClientDetailParameter { get; set; }
        #region Commands
        /// <summary>
        ///Gets LogInViewModel
        /// </summary>
        public ICommand LogInViewModelCommand
        {
            get
            {
                _logInViewModelCommand = _logInViewModelCommand ?? new MvxCommand(NavigateToLogInViewModel);
                return _logInViewModelCommand;
            }
        }

        /// <summary>
        ///Gets ManagerViewModel or EmployeeViewModel
        /// </summary>
        public ICommand ManagerOrManagerDecisionViewModelCommand
        {
            get
            {
                _managerOrManagerDecisionViewModelCommand = _managerOrManagerDecisionViewModelCommand ?? new MvxCommand(NavigateToManagerOrManagerDecisionViewModel);
                return _managerOrManagerDecisionViewModelCommand;
            }
        }
        #endregion
        /// <summary>
        /// Gets and sets the checked state of manager view radio button
        /// </summary>
        public bool ManagerViewSelected { get; set; }
        /// <summary>
        /// Gets and sets checked state of employee view radio button
        /// </summary>
        public bool EmployeeViewSelected { get; set; }
        #endregion


        #region Public Methods

        public void Init(ClientDetailParameter parameter)
        {
            ClientDetailParameter = parameter;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Navigate to login view model
        /// </summary>
        private void NavigateToLogInViewModel()
        {
            ShowViewModel<LogInViewModel>();
        }
        /// <summary>
        /// Navigates ethier manager or employee view model
        /// </summary>
        private void NavigateToManagerOrManagerDecisionViewModel()
        {
            if (EmployeeViewSelected)
            {
                ShowViewModel<ManagerDecisionViewModel>();
            }
            else if (ManagerViewSelected)
            {
                ShowViewModel<ManagerViewModel>(ClientDetailParameter);
            }
        }
        #endregion
    }
}
