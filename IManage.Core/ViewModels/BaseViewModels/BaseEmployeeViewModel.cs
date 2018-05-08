using IManage.Core.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace IManage.Core.ViewModels.BaseViewModels
{
    /// <summary>
    /// A base viewmodel class for Employee views viewmodel
    /// </summary>
    public class BaseEmployeeViewModel : MvxViewModel
    {
        #region Private Data
        /// <summary>
        /// Holds current time
        /// </summary>
        private string _currentTime;

        private Greeting? _greeting;

        #region Commands
        /// <summary>
        /// Command to navigate to ClockingPopOutViewModel
        /// </summary>
        private ICommand _clockingPopOutViewModelCommand;

        /// <summary>
        /// Command to navigate to EmployeeViewModel
        /// </summary>
        private ICommand _employeeViewModelCommand;

        /// <summary>
        /// Command to navigate to NotificationViewModel
        /// </summary>
        private ICommand _notificationSenderLoginViewModelCommand;

        /// <summary>
        /// Command to navigate to ScheduleViewerLoginViewModel
        /// </summary>
        private ICommand _scheduleViewerLoginViewModelCommand;

        /// <summary>
        /// Command to navigate to StockUpdaterLoginViewModel
        /// </summary>
        private ICommand _stockUpdaterLoginViewModelCommand;
        #endregion

        #endregion

        #region Constructor

        public BaseEmployeeViewModel()
        {
            Greeting = null;
            DispatcherTimer timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += TimerTick;
            timer.Start();
        }
        #endregion

        #region Properties
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
        public Greeting? Greeting
        {
            get => _greeting;
            set
            {
                _greeting = value;
                RaisePropertyChanged(() => Greeting);
            }
        }
        /// <summary>
        ///Gets ClockingPopOutViewModel
        /// </summary>
        public ICommand ClockingPopOutViewModelCommand
        {
            get
            {
                _clockingPopOutViewModelCommand = _clockingPopOutViewModelCommand ?? new MvxCommand(NavigateToClockingPopOutViewModel);
                return _clockingPopOutViewModelCommand;
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

        /// <summary>
        ///Gets NotificationViewModel
        /// </summary>
        public ICommand NotificationSenderLoginViewModelCommand
        {
            get
            {
                _notificationSenderLoginViewModelCommand = _notificationSenderLoginViewModelCommand ?? new MvxCommand(NavigateToNotificationSenderLoginViewModel);
                return _notificationSenderLoginViewModelCommand;
            }
        }

        /// <summary>
        ///Gets ScheduleViewModel
        /// </summary>
        public ICommand ScheduleViewerLoginViewModelCommand
        {
            get
            {
                _scheduleViewerLoginViewModelCommand = _scheduleViewerLoginViewModelCommand ?? new MvxCommand(NavigateToScheduleViewerLoginViewModel);
                return _scheduleViewerLoginViewModelCommand;
            }
        }

        /// <summary>
        ///Gets StockUpdaterLoginViewModel
        /// </summary>
        public ICommand StockUpdaterLoginViewModelCommand
        {
            get
            {
                _stockUpdaterLoginViewModelCommand = _stockUpdaterLoginViewModelCommand ?? new MvxCommand(NavigateToStockUpaterLoginViewModel);
                return _stockUpdaterLoginViewModelCommand;
            }
        }
        #endregion

        #region Private Methods
        private void TimerTick(object sender, EventArgs e)
        {

            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 12)
            {
                Greeting = Models.Greeting.GoodMorning;
            }
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 17)
            {
                Greeting = Models.Greeting.GoodAfterNoon;
            }
            else if (DateTime.Now.Hour > 17 && DateTime.Now.Hour <= 20)
            {
                Greeting = Models.Greeting.GoodEvening;
            }
            else if (DateTime.Now.Hour > 20 && DateTime.Now.Hour < 0)
            {
                Greeting = Models.Greeting.GoodNight;
            }
            CurrentTime = "Current time: " + DateTime.Now.ToString("T");
        }

        /// <summary>
        /// Navigates to ClockingPopOutViewModel
        /// </summary>
        private void NavigateToClockingPopOutViewModel()
        {
            ShowViewModel<ClockingPopOutViewModel>();
        }

        /// <summary>
        /// Navigates to EmployeeViewModel
        /// </summary>
        private void NavigateToEmployeeViewModel()
        {
            ShowViewModel<EmployeeViewModel>();
        }

        /// <summary>
        /// Navigate to NotificationViewModel
        /// </summary>
        private void NavigateToNotificationSenderLoginViewModel()
        {
            ShowViewModel<NotificationSenderLoginViewModel>();
        }

        /// <summary>
        /// Navigate to ScheduleViewModell
        /// </summary>
        private void NavigateToScheduleViewerLoginViewModel()
        {
            ShowViewModel<ScheduleViewerLoginViewModel>();
        }

        /// <summary>
        /// Navigate to StockUpaterLoginViewModel
        /// </summary>
        private void NavigateToStockUpaterLoginViewModel()
        {
            ShowViewModel<StockUpdaterLoginViewModel>();
        }
        #endregion
    }
}
