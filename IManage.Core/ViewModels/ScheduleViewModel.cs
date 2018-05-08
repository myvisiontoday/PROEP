using IManage.Core.IManageEmployeeService;
using IManage.Core.IManageScheduleService;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Employee = IManage.Core.IManageEmployeeService.Employee;
using WeekDay = IManage.Core.IManageScheduleService.WeekDay;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of Schedule View
    /// </summary>
    public class ScheduleViewModel : BaseEmployeeViewModel
    {
        #region Private Constant Data
        /// <summary>
        /// Starting day of the month
        /// </summary>
        private const int StartDay = 1;
        /// <summary>
        /// Total months in a year
        /// </summary>
        private const int TotalMonths = 12;
        /// <summary>
        /// Total weeks in a month
        /// </summary>
        private const int TotalWeeks = 4;
        #endregion

        #region Private Static Data
        /// <summary>
        /// Reference to current calender year
        /// </summary>
        private static int _syear;
        #endregion

        #region Private Data

        private readonly EmployeeServiceClient _employeeServiceClient;
        private readonly ScheduleServiceClient _scheduleServiceClient;
        private List<Employee> _allEmployees;
        /// <summary>
        /// Holds week number and its corresponding date
        /// </summary>
        private Dictionary<int, DateTime[]> _weekDateAssocivative;

        /// <summary>
        /// Reference to all weeks legend
        /// </summary>
        private MvxObservableCollection<string> _weekLegend;

        private MvxObservableCollection<WeekInformation> _weekInformations;

        private string _selectWeekNumber;

        private int _selectedIndex;
        #region Commands
        /// <summary>
        /// Reference to add or update button click command
        /// </summary>
        private MvxCommand _nextButtonClickCommand;

        /// <summary>
        /// Reference to delete button click command
        /// </summary>
        private MvxCommand _previousButtonClickCommand;
        #endregion

        #endregion

        #region Properties
        public MvxObservableCollection<string> WeekLegends
        {
            get => _weekLegend;
            set
            {
                _weekLegend = value;
                RaisePropertyChanged(() => WeekLegends);
            }
        }

        public MvxObservableCollection<WeekInformation> WeekInformations
        {
            get => _weekInformations;
            set
            {
                _weekInformations = value;
                RaisePropertyChanged(() => WeekInformations);
            }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (value >= 0 && value < WeekLegends.Count)
                {
                    _selectedIndex = value;

                }
                else if (value == 0)
                {
                    _selectedIndex = value;
                }
                else if (value == (WeekLegends.Count - 1))
                {
                    SelectedIndex = (WeekLegends.Count - 1);
                }
                RaisePropertyChanged(() => SelectedIndex);
            }
        }

        public string SelectedWeekNumber
        {
            get => _selectWeekNumber;
            set
            {
                _selectWeekNumber = value;
                RaisePropertyChanged(() => SelectedWeekNumber);
                if (!string.IsNullOrEmpty(SelectedWeekNumber))
                {
                    int weekNumber = Int32.Parse(SelectedWeekNumber.ToCharArray()[0].ToString());
                    if (_scheduleServiceClient != null)
                    {
                        _scheduleServiceClient.GetSchedulesWithGivenWeekNumberCompleted += GetSchedulesWithGivenWeekNumberCompleted;
                        _scheduleServiceClient.GetSchedulesWithGivenWeekNumberAsync(weekNumber);
                    }
                }
            }
        }

        private void GetSchedulesWithGivenWeekNumberCompleted(object sender, GetSchedulesWithGivenWeekNumberCompletedEventArgs e)
        {
            _scheduleServiceClient.GetSchedulesWithGivenWeekNumberCompleted -= GetSchedulesWithGivenWeekNumberCompleted;
            WeekInformations.Clear();
            if ((_allEmployees != null) && _allEmployees.Count != 0)
            {
                WeekInformation weekInformation = new WeekInformation();
                foreach (IManageScheduleService.Schedule schedule in e.Result)
                {
                    if (!schedule.IsDeleted)
                    {
                        Employee foundEmployee = _allEmployees.FirstOrDefault(employee => employee.PinCode == schedule.EmployeePinCode);
                        if (foundEmployee != null)
                        {
                            switch (schedule.WeekDay)
                            {
                                case WeekDay.Monday:
                                    weekInformation.Monday +=
                                        "Employee Name: " + foundEmployee.FirstName + " " + foundEmployee.LastName +
                                        "\n"
                                        + "StartHour: " + schedule.StartHour + "\n" + "EndHour: " + schedule.EndHour +
                                        "\n\n";
                                    break;
                                case WeekDay.Tuesday:
                                    weekInformation.Tuesday +=
                                        "Employee Name: " + foundEmployee.FirstName + " " + foundEmployee.LastName +
                                        "\n"
                                        + "StartHour: " + schedule.StartHour + "\n" + "EndHour: " + schedule.EndHour +
                                        "\n\n";
                                    break;
                                case WeekDay.Wednesday:
                                    weekInformation.Wednesday +=
                                        "Employee Name: " + foundEmployee.FirstName + " " + foundEmployee.LastName +
                                        "\n"
                                        + "StartHour: " + schedule.StartHour + "\n" + "EndHour: " + schedule.EndHour +
                                        "\n\n";
                                    break;
                                case WeekDay.Thursday:
                                    weekInformation.Thursday +=
                                        "Employee Name: " + foundEmployee.FirstName + " " + foundEmployee.LastName +
                                        "\n"
                                        + "StartHour: " + schedule.StartHour + "\n" + "EndHour: " + schedule.EndHour +
                                        "\n\n";
                                    break;
                                case WeekDay.Friday:
                                    weekInformation.Friday +=
                                        "Employee Name: " + foundEmployee.FirstName + " " + foundEmployee.LastName +
                                        "\n"
                                        + "StartHour: " + schedule.StartHour + "\n" + "EndHour: " + schedule.EndHour +
                                        "\n\n";
                                    break;
                                case WeekDay.Saturday:
                                    weekInformation.Saturday +=
                                        "Employee Name: " + foundEmployee.FirstName + " " + foundEmployee.LastName +
                                        "\n"
                                        + "StartHour: " + schedule.StartHour + "\n" + "EndHour: " + schedule.EndHour +
                                        "\n\n";
                                    break;
                                case WeekDay.Sunday:
                                    weekInformation.Sunday +=
                                        "Employee Name: " + foundEmployee.FirstName + " " + foundEmployee.LastName +
                                        "\n"
                                        + "StartHour: " + schedule.StartHour + "\n" + "EndHour: " + schedule.EndHour +
                                        "\n\n";
                                    break;
                            }
                        }
                    }
                    WeekInformations.Add(weekInformation);
                }
            }
        }

        public MvxCommand PreviousButtonClickCommand
        {
            get
            {
                _previousButtonClickCommand =
                    _previousButtonClickCommand ?? new MvxCommand(WhenPreviousButtonIsClicked);
                return _previousButtonClickCommand;
            }
        }

        public MvxCommand NextButtonClickCommand
        {
            get
            {
                _nextButtonClickCommand =
                    _nextButtonClickCommand ?? new MvxCommand(WhenNextButtonIsClicked);
                return _nextButtonClickCommand;
            }
        }
        #endregion

        #region Constructors

        public ScheduleViewModel()
        {
            Initialises();
            _employeeServiceClient = new EmployeeServiceClient();
            _scheduleServiceClient = new ScheduleServiceClient();
            WeekInformations = new MvxObservableCollection<WeekInformation>();

            _employeeServiceClient.GetAllEmployeesCompleted += GetAllEmployeesCompleted;
            _employeeServiceClient.GetAllEmployeesAsync();

        }

        private void GetAllEmployeesCompleted(object sender, GetAllEmployeesCompletedEventArgs e)
        {
            _employeeServiceClient.GetAllEmployeesCompleted -= GetAllEmployeesCompleted;
            _allEmployees = new List<Employee>();
            foreach (Employee employee in e.Result)
            {
                _allEmployees.Add(employee);
            }
        }
        #endregion

        #region Private Methods

        #region Helper


        public void Initialises()
        {
            _weekDateAssocivative = new Dictionary<int, DateTime[]>(TotalMonths * TotalWeeks);
            WeekLegends = new MvxObservableCollection<string>();
            _syear = DateTime.Now.Year;
            int weekCounter = 1;
            for (int month = 1; month <= TotalMonths; month++)
            {
                DateTime? firstDateOfWeek = new DateTime(_syear, month, StartDay, 23, 0, 0);
                for (int week = 1; week <= TotalWeeks; week++)
                {
                    DateTime? endDateOfWeek = firstDateOfWeek.Value.AddDays(6);
                    _weekDateAssocivative.Add(weekCounter, new[] { firstDateOfWeek.Value, endDateOfWeek.Value });
                    WeekLegends.Add(weekCounter + " ( " + firstDateOfWeek.Value.ToString("d") + " - " + endDateOfWeek.Value.ToString("d") + " )");
                    firstDateOfWeek = endDateOfWeek.Value.AddDays(1);
                    weekCounter++;
                }
            }
        }
        #endregion

        #region Callback method for button click

        private void WhenPreviousButtonIsClicked()
        {
            SelectedIndex--;
        }

        private void WhenNextButtonIsClicked()
        {
            SelectedIndex++;
        }
        #endregion

        #endregion

    }
}
