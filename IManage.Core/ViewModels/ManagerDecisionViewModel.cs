using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Input;

namespace IManage.Core.ViewModels
{
    /// <summary>
    ///  A class which handles the interaction of ManagerDecision View
    /// </summary>
    public class ManagerDecisionViewModel : MvxViewModel
    {
        #region Private Data
        /// <summary>
        /// Holds current time
        /// </summary>
        private string _currentTime;

        #region Commands
        /// <summary>
        /// Reference to ManagerChoiceViewModel
        /// </summary>
        private ICommand _managerChoiceViewModelCommand;

        /// <summary>
        /// Reference to EmployeeViewModel
        /// </summary>
        private ICommand _employeeViewModelCommand;

        #endregion

        #endregion

        #region Properties

        #region Commands
        /// <summary>
        /// Gets ManagerChoiceViewModel
        /// </summary>
        public ICommand ManagerChoiceViewViewModelCommand
        {
            get
            {
                _managerChoiceViewModelCommand = _managerChoiceViewModelCommand ?? new MvxCommand(NavigateToMangerChoiceViewModel);
                return _managerChoiceViewModelCommand;
            }
        }

        /// <summary>
        /// Gets EmployeeViewModel
        /// </summary>
        public ICommand EmployeeViewModelCommand
        {
            get
            {
                _employeeViewModelCommand = _employeeViewModelCommand ?? new MvxCommand(NavigateToEmployeeViewModel);
                return _employeeViewModelCommand;
            }
        }

        #endregion
        /// <summary>
        /// Gets and sets the current time
        /// </summary>
        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                RaisePropertyChanged(() => CurrentTime);
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerDecisionViewModel()
        {
            CurrentTime = "Current Time:" + DateTime.Now.ToString("T");
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Navigates to ManagerChoiceViewModel
        /// </summary>
        private void NavigateToMangerChoiceViewModel()
        {
            ShowViewModel<ManagerChoiceViewModel>();
        }

        /// <summary>
        /// Navigates to EmployeeViewModel
        /// </summary>
        private void NavigateToEmployeeViewModel()
        {
            ShowViewModel<EmployeeViewModel>();
        }
        #endregion
    }
}
