using IManage.Core.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace IManage.Core.ViewModels.BaseViewModels
{
    /// <summary>
    /// A base viewmodel class for Manager views viewmodel
    /// </summary>
    public class BaseManagerViewModel : MvxViewModel
    {
        #region Private Data
        /// <summary>
        /// Holds current time
        /// </summary>
        private string _currentTime;

        private Greeting? _greeting;
        #region Commands
        /// <summary>
        /// Reference to ManagerViewModel command
        /// </summary>
        private ICommand _managerViewModelCommand;

        /// <summary>
        /// Reference to EmployeeListViewModel command
        /// </summary>
        private ICommand _employeeListViewModelCommand;

        /// <summary>
        /// Reference to CreateScheduleViewModel command
        /// </summary>
        private ICommand _createScheduleViewModelCommand;

        /// <summary>
        /// Reference to EmployeeRegistrationViewModel command
        /// </summary>
        private ICommand _employeeRegistrationViewModelCommand;

        private MvxObservableCollection<string> _dropDownMenus;
        private string _logoutSelected;
        #endregion

        #endregion

        #region Properties

        #region Commands
        /// <summary>
        /// Gets ManagerViewModel
        /// </summary>
        public ICommand ManagerViewModelCommand
        {
            get
            {
                _managerViewModelCommand = _managerViewModelCommand ?? new MvxCommand(NavigateToMangerViewModel);
                return _managerViewModelCommand;
            }
        }

        /// <summary>
        /// Gets EmployeeListViewModel
        /// </summary>
        public ICommand EmployeeListViewModelCommand
        {
            get
            {
                _employeeListViewModelCommand = _employeeListViewModelCommand ?? new MvxCommand(NavigateToEmployeeListViewModel);
                return _employeeListViewModelCommand;
            }
        }

        /// <summary>
        /// Gets CreateScheduleViewModel
        /// </summary>
        public ICommand CreateScheduleViewModelCommand
        {
            get
            {
                _createScheduleViewModelCommand = _createScheduleViewModelCommand ?? new MvxCommand(NavigateToCreateScheduleViewModel);
                return _createScheduleViewModelCommand;
            }
        }

        /// <summary>
        /// Gets EmployeeRegistrationViewModel
        /// </summary>
        public ICommand EmployeeRegistrationViewModelCommand
        {
            get
            {
                _employeeRegistrationViewModelCommand = _employeeRegistrationViewModelCommand ?? new MvxCommand(NavigateToEmployeeRegistrationViewModel);
                return _employeeRegistrationViewModelCommand;
            }
        }
        #endregion

        /// <summary>
        ///Gets and sets current time 
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

        public MvxObservableCollection<string> DropDownMenus
        {
            get => _dropDownMenus;
            set
            {
                _dropDownMenus = value;
                RaisePropertyChanged(() => DropDownMenus);
            }
        }

        public string LogoutSelected
        {
            get => _logoutSelected;
            set
            {
                _logoutSelected = value;
                RaisePropertyChanged(() => LogoutSelected);
                if ((LogoutSelected != null) && LogoutSelected.Contains("LogOut"))
                {
                    ShowViewModel<LogInViewModel>();
                }
            }
        }

        public Greeting? Greeting
        {
            get => _greeting;
            set
            {
                _greeting = value;
                RaisePropertyChanged(() => Greeting);
            }
        }
        #endregion

        #region Constructor

        public BaseManagerViewModel()
        {
            Greeting = null;
            DispatcherTimer timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += TimerTick;
            timer.Start();

            DropDownMenus = new MvxObservableCollection<string> { "Welcome", "LogOut" };
        }

        private void TimerTick(object sender, EventArgs e)
        {

            if (DateTime.Now.Hour >= 0 || DateTime.Now.Hour < 12)
            {
                Greeting = Models.Greeting.GoodMorning;
            }
            else if (DateTime.Now.Hour > 12 || DateTime.Now.Hour <= 17)
            {
                Greeting = Models.Greeting.GoodAfterNoon;
            }
            else if (DateTime.Now.Hour > 17 || DateTime.Now.Hour <= 20)
            {
                Greeting = Models.Greeting.GoodEvening;
            }
            else if (DateTime.Now.Hour > 20 || DateTime.Now.Hour < 0)
            {
                Greeting = Models.Greeting.GoodNight;
            }
            CurrentTime = "Current time: " + DateTime.Now.ToString("T");
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Helps to navigate ManagerViewModel
        /// </summary>
        private void NavigateToMangerViewModel()
        {
            ShowViewModel<ManagerViewModel>(ManagerViewModel.ClientDetailParameter);
        }

        /// <summary>
        /// Helps to navigate EmployeeListViewModel
        /// </summary>
        private void NavigateToEmployeeListViewModel()
        {
            ShowViewModel<EmployeeListViewModel>(ManagerViewModel.ClientDetailParameter);
        }

        /// <summary>
        /// Helps to navigate CreateScheduleViewModel
        /// </summary>
        private void NavigateToCreateScheduleViewModel()
        {
            ShowViewModel<CreateScheduleViewModel>(ManagerViewModel.ClientDetailParameter);
        }

        /// <summary>
        /// Helps to navigate EmployeeRegistrationViewModel
        /// </summary>
        private void NavigateToEmployeeRegistrationViewModel()
        {
            ShowViewModel<EmployeeRegisterationViewModel>(ManagerViewModel.ClientDetailParameter);
        }
        #endregion
    }
}
