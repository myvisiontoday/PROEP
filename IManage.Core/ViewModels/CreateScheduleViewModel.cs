using IManage.Core.IManageEmployeeService;
using IManage.Core.IManageScheduleService;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Schedule = IManage.Core.IManageScheduleService.Schedule;
using WeekDay = IManage.Core.IManageScheduleService.WeekDay;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of CreateSchedule View
    /// </summary>
    public class CreateScheduleViewModel : BaseManagerViewModel
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
        /// <summary>
        /// Holds week number and its corresponding date
        /// </summary>
        private Dictionary<int, DateTime[]> _weekDateAssocivative;

        /// <summary>
        /// Holds all schedules of employees
        /// </summary>
        private ObservableCollection<Schedule> _schedules;

        /// <summary>
        /// Holds all days of the week
        /// </summary>
        private List<WeekDay> _weekDays;

        #region Bindings
        /// <summary>
        /// Reference to all employees
        /// </summary>
        private MvxObservableCollection<IManageEmployeeService.Employee> _employees;

        /// <summary>
        /// Reference to all weeks legend
        /// </summary>
        private MvxObservableCollection<string> _weekLegend;

        /// <summary>
        /// Reference to selected employee
        /// </summary>
        private IManageEmployeeService.Employee _selectedEmployee;

        /// <summary>
        /// Reference to employee search string
        /// </summary>
        private string _employeeSearchText;

        /// <summary>
        /// Reference to text in button
        /// </summary>
        private string _actionButtonContent;

        private string _selectWeekNumber;

        private DateTime? _startHourMonday;
        private DateTime? _startHourTuesday;
        private DateTime? _startHourWednesday;
        private DateTime? _startHourThursday;
        private DateTime? _startHourFriday;
        private DateTime? _startHourSaturday;
        private DateTime? _startHourSunday;

        private DateTime? _endHourMonday;
        private DateTime? _endHourTuesday;
        private DateTime? _endHourWednesday;
        private DateTime? _endHourThursday;
        private DateTime? _endHourFriday;
        private DateTime? _endHourSaturday;
        private DateTime? _endHourSunday;

        private Message? _message;
        #endregion

        #region Commands
        /// <summary>
        /// Reference to add or update button click command
        /// </summary>
        private MvxCommand _addOrUpdateButtonCommand;

        /// <summary>
        /// Reference to delete button click command
        /// </summary>
        private MvxCommand _deleteButtonCommand;
        #endregion

        #region Services
        /// <summary>
        /// Reference to employee service client
        /// </summary>
        private readonly EmployeeServiceClient _employeeServiceClient;

        /// <summary>
        /// Reference to schedule service client
        /// </summary>
        private readonly ScheduleServiceClient _scheduleServiceClient;
        #endregion

        #endregion

        #region Properties

        #region Bindings
        public string ActionButtonContent
        {
            get => _actionButtonContent;
            set
            {
                _actionButtonContent = value;
                RaisePropertyChanged(() => ActionButtonContent);
            }
        }
        public IManageEmployeeService.Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged(() => SelectedEmployee);

                if ((SelectedEmployee != null) && (SelectedWeekNumber != null) && (_scheduleServiceClient != null))
                {
                    int weekNumber = Int32.Parse(SelectedWeekNumber.ToCharArray()[0].ToString());
                    _scheduleServiceClient.GetSchedulesWithEmployeePinCodeAndWeekNumberCompleted += GetSchedulesWithEmployeePinCodeAndWeekNumberCompleted; ;
                    _scheduleServiceClient.GetSchedulesWithEmployeePinCodeAndWeekNumberAsync(SelectedEmployee.PinCode, weekNumber);
                }
                else
                {

                    ResetHours();
                }
            }
        }
        public string SelectedWeekNumber
        {
            get => _selectWeekNumber;
            set
            {
                _selectWeekNumber = value;
                RaisePropertyChanged(() => SelectedWeekNumber);
                if ((SelectedEmployee != null) && (SelectedWeekNumber != null) && (_scheduleServiceClient != null))
                {
                    int weekNumber = Int32.Parse(SelectedWeekNumber.ToCharArray()[0].ToString());
                    _scheduleServiceClient.GetSchedulesWithEmployeePinCodeAndWeekNumberCompleted += GetSchedulesWithEmployeePinCodeAndWeekNumberCompleted; ;
                    _scheduleServiceClient.GetSchedulesWithEmployeePinCodeAndWeekNumberAsync(SelectedEmployee.PinCode, weekNumber);
                }
                else
                {

                    ResetHours();
                }

            }
        }

        public MvxObservableCollection<string> WeekLegends
        {
            get => _weekLegend;
            set
            {
                _weekLegend = value;
                RaisePropertyChanged(() => WeekLegends);
            }
        }

        public MvxObservableCollection<IManageEmployeeService.Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                RaisePropertyChanged(() => Employees);
            }
        }

        public string EmployeeSearchText
        {
            get
            {
                return _employeeSearchText;
            }
            set
            {
                _employeeSearchText = value;
                RaisePropertyChanged(() => EmployeeSearchText);
                EmployeeView?.Refresh();
            }
        }

        public ICollectionView EmployeeView => CollectionViewSource.GetDefaultView(Employees);
        public DateTime? StartHourMonday
        {
            get => _startHourMonday;
            set
            {
                _startHourMonday = value;
                RaisePropertyChanged(() => StartHourMonday);
            }
        }

        public DateTime? StartHourTuesday
        {
            get => _startHourTuesday;
            set
            {
                _startHourTuesday = value;
                RaisePropertyChanged(() => StartHourTuesday);
            }
        }

        public DateTime? StartHourWednesday
        {
            get => _startHourWednesday;
            set
            {
                _startHourWednesday = value;
                RaisePropertyChanged(() => StartHourWednesday);
            }
        }

        public DateTime? StartHourThursday
        {
            get => _startHourThursday;
            set
            {
                _startHourThursday = value;
                RaisePropertyChanged(() => StartHourThursday);
            }
        }
        public DateTime? StartHourFriday
        {
            get => _startHourFriday;
            set
            {
                _startHourFriday = value;
                RaisePropertyChanged(() => StartHourFriday);
            }
        }
        public DateTime? StartHourSaturday
        {
            get => _startHourSaturday;
            set
            {
                _startHourSaturday = value;
                RaisePropertyChanged(() => StartHourSaturday);
            }
        }

        public DateTime? StartHourSunday
        {
            get => _startHourSunday;
            set
            {
                _startHourSunday = value;
                RaisePropertyChanged(() => StartHourSunday);
            }
        }
        public DateTime? EndHourMonday
        {
            get => _endHourMonday;
            set
            {
                _endHourMonday = value;
                RaisePropertyChanged(() => EndHourMonday);
            }
        }

        public DateTime? EndHourTuesday
        {
            get => _endHourTuesday;
            set
            {
                _endHourTuesday = value;
                RaisePropertyChanged(() => EndHourTuesday);
            }
        }

        public DateTime? EndHourWednesday
        {
            get => _endHourWednesday;
            set
            {
                _endHourWednesday = value;
                RaisePropertyChanged(() => EndHourWednesday);
            }
        }

        public DateTime? EndHourThursday
        {
            get => _endHourThursday;
            set
            {
                _endHourThursday = value;
                RaisePropertyChanged(() => EndHourThursday);
            }
        }
        public DateTime? EndHourFriday
        {
            get => _endHourFriday;
            set
            {
                _endHourFriday = value;
                RaisePropertyChanged(() => EndHourFriday);
            }
        }
        public DateTime? EndHourSaturday
        {
            get => _endHourSaturday;
            set
            {
                _endHourSaturday = value;
                RaisePropertyChanged(() => EndHourSaturday);
            }
        }

        public DateTime? EndHourSunday
        {
            get => _endHourSunday;
            set
            {
                _endHourSunday = value;
                RaisePropertyChanged(() => EndHourSunday);
            }
        }

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
        /// <summary>
        /// Gets the command for add or update button click
        /// </summary>
        public MvxCommand AddOrUpdateButtonCommand
        {
            get
            {
                _addOrUpdateButtonCommand = _addOrUpdateButtonCommand ?? new MvxCommand(AddOrUpdateButtonClick);
                return _addOrUpdateButtonCommand;
            }
        }
        /// <summary>
        /// Gets the command for delete button click
        /// </summary>
        public MvxCommand DeleteButtonCommand
        {
            get
            {
                _deleteButtonCommand = _deleteButtonCommand ?? new MvxCommand(DeleteButtonClick);
                return _deleteButtonCommand;
            }
        }
        #endregion

        #endregion

        #region Constructor
        public CreateScheduleViewModel()
        {
            Employees = new MvxObservableCollection<IManageEmployeeService.Employee>();
            SelectedWeekNumber = null;
            ActionButtonContent = "Add";
            EmployeeView.Filter = employee => Filter(employee as IManageEmployeeService.Employee);

            Initializes();

            _employeeServiceClient = new EmployeeServiceClient();
            _employeeServiceClient.GetAllEmployeesCompleted += GetAllEmployeesCompleted;
            _employeeServiceClient.GetAllEmployeesAsync();
            _scheduleServiceClient = new ScheduleServiceClient();
        }
        #endregion

        #region Public Methods

        public void Init(ClientDetailParameter parameter)
        {
            if (parameter != null)
            {
                DropDownMenus = new MvxObservableCollection<string> { "Welcome " + parameter.Name, "LogOut" };
            }
        }
        #endregion



        #region Private Methods

        #region Helper
        private void Initializes()
        {
            _weekDateAssocivative = new Dictionary<int, DateTime[]>(TotalMonths * TotalWeeks);
            Message = null;
            WeekLegends = new MvxObservableCollection<string>();
            _syear = DateTime.Now.Year;
            int weekCounter = 1;
            for (int month = 1; month <= TotalMonths; month++)
            {
                DateTime? firstDateOfWeek = new DateTime(_syear, month, StartDay, 23, 59, 59);
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
        private bool CheckAtLeastWeekDayHourHasValue()
        {
            return (StartHourMonday.HasValue || EndHourMonday.HasValue) ||
                   (StartHourTuesday.HasValue || EndHourTuesday.HasValue) ||
                   (StartHourWednesday.HasValue || EndHourWednesday.HasValue) ||
                   (StartHourThursday.HasValue || EndHourThursday.HasValue) ||
                   (StartHourFriday.HasValue || EndHourFriday.HasValue) ||
                   (StartHourSaturday.HasValue || EndHourSaturday.HasValue) ||
                   (StartHourSunday.HasValue || EndHourSunday.HasValue);
        }
        private void ResetHours()
        {
            StartHourMonday = null;
            StartHourTuesday = null;
            StartHourWednesday = null;
            StartHourThursday = null;
            StartHourFriday = null;
            StartHourSaturday = null;
            StartHourSunday = null;

            EndHourMonday = null;
            EndHourTuesday = null;
            EndHourWednesday = null;
            EndHourThursday = null;
            EndHourFriday = null;
            EndHourSaturday = null;
            EndHourSunday = null;
        }
        private bool Filter(IManageEmployeeService.Employee employee)
        {
            return string.IsNullOrEmpty(EmployeeSearchText) ||
                   EmployeeSearchText.ToLower().StartsWith(employee.FirstName.ToLower()) ||
                   EmployeeSearchText.ToLower().StartsWith(employee.LastName.ToLower());
        }

        private bool CheckValidDate(int weekNumber, DateTime dateTobeCheck)
        {
            bool checkSuccess = false;
            var dateRange = _weekDateAssocivative.FirstOrDefault((kvp) => kvp.Key == weekNumber);
            DateTime dateChecker = dateRange.Value[1];
            if (dateTobeCheck <= dateChecker)
            {
                checkSuccess = true;
            }
            return checkSuccess;
        }
        /// <summary>
        /// Combine new schedules and updated schedule
        /// </summary>
        /// <param name="newSchedules">Reference to a new schedules</param>
        /// <param name="updatedSchedules">Reference to an updated schedules</param>
        /// <returns>Combined collection of new and update schedules</returns>
        private ObservableCollection<Schedule> CombineNewUpdateSchedules(IEnumerable<Schedule> newSchedules, IEnumerable<Schedule> updatedSchedules)
        {
            ObservableCollection<Schedule> schedules = new ObservableCollection<Schedule>();
            foreach (Schedule newSchedule in newSchedules)
            {
                schedules.Add(newSchedule);
            }

            foreach (Schedule updatedSchedule in updatedSchedules)
            {
                schedules.Add(updatedSchedule);
            }

            return schedules;
        }

        /// <summary>
        /// Get schedules of an employee
        /// </summary>
        /// <returns>Schedules of an employee</returns>
        private ObservableCollection<Schedule> GetNewSchedules()
        {
            ObservableCollection<Schedule> schedules = new ObservableCollection<Schedule>();
            if ((SelectedEmployee != null) && (SelectedWeekNumber != null))
            {
                int weekNumber = Int32.Parse(SelectedWeekNumber.ToCharArray()[0].ToString());

                if (StartHourMonday.HasValue && EndHourMonday.HasValue)
                {
                    if ((CheckValidDate(weekNumber, StartHourMonday.Value) &&
                         CheckValidDate(weekNumber, EndHourMonday.Value)))
                    {
                        if (StartHourMonday.Value != EndHourMonday.Value)
                        {

                            schedules.Add(new Schedule
                            {
                                CreatedDate = DateTime.Now,
                                EmployeeId = SelectedEmployee.EmployeeId,
                                EmployeePinCode = SelectedEmployee.PinCode,
                                StartHour = StartHourMonday.Value,
                                EndHour = EndHourMonday.Value,
                                WeekNumber = weekNumber,
                                WeekDay = WeekDay.Monday
                            });


                        }
                        else if (StartHourMonday.Value > EndHourMonday.Value)
                        {
                            Message = Models.Message.StartHourCannotBeGreater;
                        }
                        else
                        {
                            Message = Models.Message.StartHourAndEndHourCannotBeSame;
                        }
                    }
                    else
                    {
                        Message = Models.Message.InvalidDate;
                    }
                }

                if (StartHourTuesday.HasValue && EndHourTuesday.HasValue)
                {
                    if ((CheckValidDate(weekNumber, StartHourTuesday.Value) &&
                         CheckValidDate(weekNumber, EndHourTuesday.Value)))
                    {
                        if (StartHourTuesday.Value != EndHourTuesday.Value)
                        {

                            schedules.Add(new Schedule
                            {
                                CreatedDate = DateTime.Now,
                                EmployeeId = SelectedEmployee.EmployeeId,
                                EmployeePinCode = SelectedEmployee.PinCode,
                                StartHour = StartHourTuesday.Value,
                                EndHour = EndHourTuesday.Value,
                                WeekNumber = weekNumber,
                                WeekDay = WeekDay.Tuesday
                            });


                        }
                        else if (StartHourTuesday.Value > EndHourTuesday.Value)
                        {
                            Message = Models.Message.StartHourCannotBeGreater;
                        }
                        else
                        {
                            Message = Models.Message.StartHourAndEndHourCannotBeSame;
                        }
                    }
                    else
                    {
                        Message = Models.Message.InvalidDate;
                    }
                }

                if (StartHourWednesday.HasValue && EndHourWednesday.HasValue)
                {
                    if ((CheckValidDate(weekNumber, StartHourWednesday.Value) &&
                         CheckValidDate(weekNumber, EndHourWednesday.Value)))
                    {
                        if (StartHourWednesday.Value != EndHourWednesday.Value)
                        {

                            schedules.Add(new Schedule
                            {
                                CreatedDate = DateTime.Now,
                                EmployeeId = SelectedEmployee.EmployeeId,
                                EmployeePinCode = SelectedEmployee.PinCode,
                                StartHour = StartHourWednesday.Value,
                                EndHour = EndHourWednesday.Value,
                                WeekNumber = weekNumber,
                                WeekDay = WeekDay.Wednesday
                            });


                        }
                        else if (StartHourWednesday.Value > EndHourWednesday.Value)
                        {
                            Message = Models.Message.StartHourCannotBeGreater;
                        }
                        else
                        {
                            Message = Models.Message.StartHourAndEndHourCannotBeSame;
                        }
                    }
                    else
                    {
                        Message = Models.Message.InvalidDate;
                    }
                }

                if (StartHourThursday.HasValue && EndHourThursday.HasValue)
                {
                    if ((CheckValidDate(weekNumber, StartHourThursday.Value) &&
                         CheckValidDate(weekNumber, EndHourThursday.Value)))
                    {
                        if (StartHourThursday.Value != EndHourThursday.Value)
                        {

                            schedules.Add(new Schedule
                            {
                                CreatedDate = DateTime.Now,
                                EmployeeId = SelectedEmployee.EmployeeId,
                                EmployeePinCode = SelectedEmployee.PinCode,
                                StartHour = StartHourThursday.Value,
                                EndHour = EndHourThursday.Value,
                                WeekNumber = weekNumber,
                                WeekDay = WeekDay.Thursday
                            });

                        }
                        else if (StartHourThursday.Value > EndHourThursday.Value)
                        {
                            Message = Models.Message.StartHourCannotBeGreater;
                        }
                        else
                        {
                            Message = Models.Message.StartHourAndEndHourCannotBeSame;
                        }
                    }
                    else
                    {
                        Message = Models.Message.InvalidDate;
                    }
                }

                if (StartHourFriday.HasValue && EndHourFriday.HasValue)
                {
                    if ((CheckValidDate(weekNumber, StartHourFriday.Value) &&
                         CheckValidDate(weekNumber, EndHourFriday.Value)))
                    {
                        if (StartHourFriday.Value != EndHourFriday.Value)
                        {

                            schedules.Add(new Schedule
                            {
                                CreatedDate = DateTime.Now,
                                EmployeeId = SelectedEmployee.EmployeeId,
                                EmployeePinCode = SelectedEmployee.PinCode,
                                StartHour = StartHourFriday.Value,
                                EndHour = EndHourFriday.Value,
                                WeekNumber = weekNumber,
                                WeekDay = WeekDay.Friday
                            });


                        }
                        else if (StartHourFriday.Value > EndHourFriday.Value)
                        {
                            Message = Models.Message.StartHourCannotBeGreater;
                        }
                        else
                        {
                            Message = Models.Message.StartHourAndEndHourCannotBeSame;
                        }
                    }
                    else
                    {
                        Message = Models.Message.InvalidDate;
                    }
                }

                if (StartHourSaturday.HasValue && EndHourSaturday.HasValue)
                {
                    if ((CheckValidDate(weekNumber, StartHourSaturday.Value) &&
                         CheckValidDate(weekNumber, EndHourSaturday.Value)))
                    {
                        if (StartHourSaturday.Value != EndHourSaturday.Value)
                        {

                            schedules.Add(new Schedule
                            {
                                CreatedDate = DateTime.Now,
                                EmployeeId = SelectedEmployee.EmployeeId,
                                EmployeePinCode = SelectedEmployee.PinCode,
                                StartHour = StartHourSaturday.Value,
                                EndHour = EndHourSaturday.Value,
                                WeekNumber = weekNumber,
                                WeekDay = WeekDay.Saturday
                            });


                        }
                        else if (StartHourSaturday.Value > EndHourSaturday.Value)
                        {
                            Message = Models.Message.StartHourCannotBeGreater;
                        }
                        else
                        {
                            Message = Models.Message.StartHourAndEndHourCannotBeSame;
                        }
                    }
                    else
                    {
                        Message = Models.Message.InvalidDate;
                    }
                }

                if (StartHourSunday.HasValue && EndHourSunday.HasValue)
                {
                    if ((CheckValidDate(weekNumber, StartHourSunday.Value) &&
                         CheckValidDate(weekNumber, EndHourSunday.Value)))
                    {
                        if (StartHourSunday.Value != EndHourSunday.Value)
                        {
                            schedules.Add(new Schedule
                            {
                                CreatedDate = DateTime.Now,
                                EmployeeId = SelectedEmployee.EmployeeId,
                                EmployeePinCode = SelectedEmployee.PinCode,
                                StartHour = StartHourSunday.Value,
                                EndHour = EndHourSunday.Value,
                                WeekNumber = weekNumber,
                                WeekDay = WeekDay.Sunday
                            });


                        }
                        else if (StartHourSunday.Value > EndHourSunday.Value)
                        {
                            Message = Models.Message.StartHourCannotBeGreater;
                        }
                        else
                        {
                            Message = Models.Message.StartHourAndEndHourCannotBeSame;
                        }
                    }
                    else
                    {
                        Message = Models.Message.InvalidDate;
                    }
                }

            }

            return schedules;
        }

        /// <summary>
        /// Gets day of week of an updated schedules
        /// </summary>
        /// <param name="updatedSchedules">Reference to an updated schedules</param>
        /// <returns>Days of a week of an updated schedules</returns>
        private List<WeekDay> GetWeeksOfUpdatedScheules(IEnumerable<Schedule> updatedSchedules)
        {
            List<WeekDay> weekList = new List<WeekDay>();

            foreach (Schedule schedule in updatedSchedules)
            {
                weekList.Add(schedule.WeekDay);
            }

            foreach (Schedule schedule in _schedules)
            {
                if (!weekList.Contains(schedule.WeekDay))
                {
                    weekList.Add(schedule.WeekDay);
                }
            }
            return weekList;
        }

        private IEnumerable<Schedule> GetUpdatedSchedules()
        {
            List<Schedule> updateSchedules = new List<Schedule>();
            if (_schedules.Count != 0)
            {
                foreach (Schedule schedule in _schedules)
                {
                    switch (schedule.WeekDay)
                    {
                        case WeekDay.Monday:
                            if (StartHourMonday.HasValue && EndHourMonday.HasValue)
                            {
                                if (CheckValidDate(schedule.WeekNumber, StartHourMonday.Value) &&
                                    CheckValidDate(schedule.WeekNumber, EndHourMonday.Value))
                                {
                                    if (StartHourMonday.Value != EndHourMonday.Value)
                                    {
                                        if ((StartHourMonday.Value != schedule.StartHour) ||
                                            (EndHourMonday.Value != schedule.EndHour))
                                        {
                                            schedule.StartHour = StartHourMonday.Value;
                                            schedule.EndHour = EndHourMonday.Value;
                                            schedule.Updated = true;
                                            schedule.UpdatedDate = DateTime.Now;
                                            updateSchedules.Add(schedule);


                                        }
                                    }
                                    else if (StartHourMonday.Value > EndHourMonday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Tuesday:
                            if (StartHourTuesday.HasValue && EndHourTuesday.HasValue)
                            {
                                if (CheckValidDate(schedule.WeekNumber, StartHourTuesday.Value) &&
                                    CheckValidDate(schedule.WeekNumber, EndHourTuesday.Value))
                                {
                                    if (StartHourTuesday.Value != EndHourTuesday.Value)
                                    {
                                        if (CheckValidDate(schedule.WeekNumber, StartHourTuesday.Value) &&
                                            CheckValidDate(schedule.WeekNumber, EndHourTuesday.Value))
                                        {
                                            if ((StartHourTuesday.Value != schedule.StartHour) ||
                                                (EndHourTuesday.Value != schedule.EndHour))
                                            {
                                                schedule.StartHour = StartHourTuesday.Value;
                                                schedule.EndHour = EndHourTuesday.Value;
                                                schedule.Updated = true;
                                                schedule.UpdatedDate = DateTime.Now;
                                                updateSchedules.Add(schedule);
                                            }
                                        }

                                    }
                                    else if (StartHourTuesday.Value > EndHourTuesday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Wednesday:
                            if (StartHourWednesday.HasValue && EndHourWednesday.HasValue)
                            {
                                if (CheckValidDate(schedule.WeekNumber, StartHourWednesday.Value) &&
                                    CheckValidDate(schedule.WeekNumber, EndHourWednesday.Value))
                                {
                                    if (StartHourWednesday.Value != EndHourWednesday.Value)
                                    {

                                        if ((StartHourWednesday.Value != schedule.StartHour) ||
                                            (EndHourWednesday.Value != schedule.EndHour))
                                        {
                                            schedule.StartHour = StartHourWednesday.Value;
                                            schedule.EndHour = EndHourWednesday.Value;
                                            schedule.Updated = true;
                                            schedule.UpdatedDate = DateTime.Now;
                                            updateSchedules.Add(schedule);
                                        }


                                    }
                                    else if (StartHourWednesday.Value > EndHourWednesday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Thursday:
                            if (StartHourThursday.HasValue && EndHourThursday.HasValue)
                            {
                                if (CheckValidDate(schedule.WeekNumber, StartHourThursday.Value) &&
                                    CheckValidDate(schedule.WeekNumber, EndHourThursday.Value))
                                {
                                    if (StartHourThursday.Value != EndHourThursday.Value)
                                    {

                                        if ((StartHourThursday.Value != schedule.StartHour) ||
                                            (EndHourThursday.Value != schedule.EndHour))
                                        {
                                            schedule.StartHour = StartHourThursday.Value;
                                            schedule.EndHour = EndHourThursday.Value;
                                            schedule.Updated = true;
                                            schedule.UpdatedDate = DateTime.Now;
                                            updateSchedules.Add(schedule);
                                        }

                                    }
                                    else if (StartHourThursday.Value > EndHourThursday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Friday:
                            if (StartHourFriday.HasValue && EndHourFriday.HasValue)
                            {
                                if (CheckValidDate(schedule.WeekNumber, StartHourFriday.Value) &&
                                    CheckValidDate(schedule.WeekNumber, EndHourFriday.Value))
                                {
                                    if (StartHourFriday.Value != EndHourFriday.Value)
                                    {

                                        if ((StartHourFriday.Value != schedule.StartHour) ||
                                            (EndHourFriday.Value != schedule.EndHour))
                                        {
                                            schedule.StartHour = StartHourFriday.Value;
                                            schedule.EndHour = EndHourFriday.Value;
                                            schedule.Updated = true;
                                            schedule.UpdatedDate = DateTime.Now;
                                            updateSchedules.Add(schedule);
                                        }


                                    }
                                    else if (StartHourFriday.Value > EndHourFriday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Saturday:
                            if (StartHourSaturday.HasValue && EndHourSaturday.HasValue)
                            {
                                if (CheckValidDate(schedule.WeekNumber, StartHourSaturday.Value) &&
                                    CheckValidDate(schedule.WeekNumber, EndHourSaturday.Value))
                                {
                                    if (StartHourSaturday.Value != EndHourSaturday.Value)
                                    {

                                        if ((StartHourSaturday.Value != schedule.StartHour) ||
                                            (EndHourSaturday.Value != schedule.EndHour))
                                        {
                                            schedule.StartHour = StartHourSaturday.Value;
                                            schedule.EndHour = EndHourSaturday.Value;
                                            schedule.Updated = true;
                                            schedule.UpdatedDate = DateTime.Now;
                                            updateSchedules.Add(schedule);
                                        }

                                    }
                                    else if (StartHourSaturday.Value > EndHourSaturday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }

                            }
                            break;
                        case WeekDay.Sunday:
                            if (StartHourSunday.HasValue && EndHourSunday.HasValue)
                            {
                                if (CheckValidDate(schedule.WeekNumber, StartHourSunday.Value) &&
                                    CheckValidDate(schedule.WeekNumber, EndHourSunday.Value))
                                {
                                    if (StartHourSunday.Value != EndHourSunday.Value)
                                    {

                                        if ((StartHourSunday.Value != schedule.StartHour) ||
                                            (EndHourSunday.Value != schedule.EndHour))
                                        {
                                            schedule.StartHour = StartHourSunday.Value;
                                            schedule.EndHour = EndHourSunday.Value;
                                            schedule.Updated = true;
                                            schedule.UpdatedDate = DateTime.Now;
                                            updateSchedules.Add(schedule);
                                        }

                                    }
                                    else if (StartHourSunday.Value > EndHourSunday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                    }
                }
            }
            return updateSchedules;
        }

        private IEnumerable<Schedule> GetNewSchedulesTobeAdded(List<WeekDay> weekList)
        {

            List<Schedule> schedules = new List<Schedule>();

            _weekDays = new List<WeekDay>
            {
                WeekDay.Monday, WeekDay.Tuesday, WeekDay.Wednesday, WeekDay.Thursday, WeekDay.Friday, WeekDay.Saturday, WeekDay.Sunday
            };

            foreach (WeekDay weekDay in weekList)
            {
                _weekDays.Remove(weekDay);
            }

            if ((SelectedEmployee != null) && (SelectedWeekNumber != null))
            {
                int weekNumber = Int32.Parse(SelectedWeekNumber.ToCharArray()[0].ToString());

                foreach (WeekDay weekDay in _weekDays)
                {
                    switch (weekDay)
                    {
                        case WeekDay.Monday:
                            if (StartHourMonday.HasValue && EndHourMonday.HasValue)
                            {
                                if ((CheckValidDate(weekNumber, StartHourMonday.Value) &&
                                     CheckValidDate(weekNumber, EndHourMonday.Value)))
                                {

                                    if (StartHourMonday.Value != EndHourMonday.Value)
                                    {

                                        schedules.Add(new Schedule
                                        {
                                            CreatedDate = DateTime.Now,
                                            EmployeeId = SelectedEmployee.EmployeeId,
                                            EmployeePinCode = SelectedEmployee.PinCode,
                                            StartHour = StartHourMonday.Value,
                                            EndHour = EndHourMonday.Value,
                                            WeekNumber = weekNumber,
                                            WeekDay = WeekDay.Monday
                                        });


                                    }
                                    else if (StartHourMonday.Value > EndHourMonday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Tuesday:
                            if (StartHourTuesday.HasValue && EndHourTuesday.HasValue)
                            {
                                if ((CheckValidDate(weekNumber, StartHourTuesday.Value) &&
                                     CheckValidDate(weekNumber, EndHourTuesday.Value)))
                                {
                                    if (StartHourTuesday.Value != EndHourTuesday.Value)
                                    {

                                        schedules.Add(new Schedule
                                        {
                                            CreatedDate = DateTime.Now,
                                            EmployeeId = SelectedEmployee.EmployeeId,
                                            EmployeePinCode = SelectedEmployee.PinCode,
                                            StartHour = StartHourTuesday.Value,
                                            EndHour = EndHourTuesday.Value,
                                            WeekNumber = weekNumber,
                                            WeekDay = WeekDay.Tuesday
                                        });

                                    }
                                    else if (StartHourTuesday.Value > EndHourTuesday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Wednesday:
                            if (StartHourWednesday.HasValue && EndHourWednesday.HasValue)
                            {
                                if ((CheckValidDate(weekNumber, StartHourWednesday.Value) &&
                                     CheckValidDate(weekNumber, EndHourWednesday.Value)))
                                {
                                    if (StartHourWednesday.Value != EndHourWednesday.Value)
                                    {

                                        schedules.Add(new Schedule
                                        {
                                            CreatedDate = DateTime.Now,
                                            EmployeeId = SelectedEmployee.EmployeeId,
                                            EmployeePinCode = SelectedEmployee.PinCode,
                                            StartHour = StartHourWednesday.Value,
                                            EndHour = EndHourWednesday.Value,
                                            WeekNumber = weekNumber,
                                            WeekDay = WeekDay.Wednesday
                                        });


                                    }
                                    else if (StartHourWednesday.Value > EndHourWednesday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Thursday:
                            if (StartHourThursday.HasValue && EndHourThursday.HasValue)
                            {
                                if ((CheckValidDate(weekNumber, StartHourThursday.Value) &&
                                     CheckValidDate(weekNumber, EndHourThursday.Value)))
                                {
                                    if (StartHourThursday.Value != EndHourThursday.Value)
                                    {

                                        schedules.Add(new Schedule
                                        {
                                            CreatedDate = DateTime.Now,
                                            EmployeeId = SelectedEmployee.EmployeeId,
                                            EmployeePinCode = SelectedEmployee.PinCode,
                                            StartHour = StartHourThursday.Value,
                                            EndHour = EndHourThursday.Value,
                                            WeekNumber = weekNumber,
                                            WeekDay = WeekDay.Thursday
                                        });

                                    }
                                    else if (StartHourThursday.Value > EndHourThursday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Friday:
                            if (StartHourFriday.HasValue && EndHourFriday.HasValue)
                            {
                                if ((CheckValidDate(weekNumber, StartHourFriday.Value) &&
                                     CheckValidDate(weekNumber, EndHourFriday.Value)))
                                {
                                    if (StartHourFriday.Value != EndHourFriday.Value)
                                    {

                                        schedules.Add(new Schedule
                                        {
                                            CreatedDate = DateTime.Now,
                                            EmployeeId = SelectedEmployee.EmployeeId,
                                            EmployeePinCode = SelectedEmployee.PinCode,
                                            StartHour = StartHourFriday.Value,
                                            EndHour = EndHourFriday.Value,
                                            WeekNumber = weekNumber,
                                            WeekDay = WeekDay.Friday
                                        });


                                    }
                                    else if (StartHourFriday.Value > EndHourFriday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Saturday:
                            if (StartHourSaturday.HasValue && EndHourSaturday.HasValue)
                            {

                                if (StartHourSaturday.Value != EndHourSaturday.Value)
                                {
                                    if ((CheckValidDate(weekNumber, StartHourSaturday.Value) &&
                                         CheckValidDate(weekNumber, EndHourSaturday.Value)))
                                    {
                                        schedules.Add(new Schedule
                                        {
                                            CreatedDate = DateTime.Now,
                                            EmployeeId = SelectedEmployee.EmployeeId,
                                            EmployeePinCode = SelectedEmployee.PinCode,
                                            StartHour = StartHourSaturday.Value,
                                            EndHour = EndHourSaturday.Value,
                                            WeekNumber = weekNumber,
                                            WeekDay = WeekDay.Saturday
                                        });

                                    }
                                    else if (StartHourSaturday.Value > EndHourSaturday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                        case WeekDay.Sunday:
                            if (StartHourSunday.HasValue && EndHourSunday.HasValue)
                            {
                                if ((CheckValidDate(weekNumber, StartHourSunday.Value) &&
                                     CheckValidDate(weekNumber, EndHourSunday.Value)))
                                {
                                    if (StartHourSunday.Value != EndHourSunday.Value)
                                    {

                                        schedules.Add(new Schedule
                                        {
                                            CreatedDate = DateTime.Now,
                                            EmployeeId = SelectedEmployee.EmployeeId,
                                            EmployeePinCode = SelectedEmployee.PinCode,
                                            StartHour = StartHourSunday.Value,
                                            EndHour = EndHourSunday.Value,
                                            WeekNumber = weekNumber,
                                            WeekDay = WeekDay.Sunday
                                        });

                                    }
                                    else if (StartHourSunday.Value > EndHourSunday.Value)
                                    {
                                        Message = Models.Message.StartHourCannotBeGreater;
                                    }
                                    else
                                    {
                                        Message = Models.Message.StartHourAndEndHourCannotBeSame;
                                    }
                                }
                                else
                                {
                                    Message = Models.Message.InvalidDate;
                                }
                            }
                            break;
                    }
                }
            }
            return schedules;

        }

        #endregion

        #region Callback methods of button click
        /// <summary>
        /// Add or update schedules
        /// </summary>
        private void AddOrUpdateButtonClick()
        {
            if (_scheduleServiceClient != null)
            {
                if (ActionButtonContent.Contains("Add"))
                {
                    ObservableCollection<Schedule> schedules = GetNewSchedules();
                    if (schedules.Count != 0)
                    {
                        _scheduleServiceClient.AddSchedulesCompleted += AddSchedulesCompleted;
                        _scheduleServiceClient.AddSchedulesAsync(schedules);
                    }

                }
                else
                {
                    IEnumerable<Schedule> getUpdatedSchedules = GetUpdatedSchedules();
                    IEnumerable<Schedule> updatedSchedules = getUpdatedSchedules as Schedule[] ?? getUpdatedSchedules.ToArray();

                    List<WeekDay> weekDays = GetWeeksOfUpdatedScheules(updatedSchedules);

                    IEnumerable<Schedule> newSchedules = GetNewSchedulesTobeAdded(weekDays);

                    ObservableCollection<Schedule> combinedNewAndUpdatedSchedules = CombineNewUpdateSchedules(newSchedules, updatedSchedules);

                    if ((_scheduleServiceClient != null) && (combinedNewAndUpdatedSchedules.Count != 0))
                    {
                        _scheduleServiceClient.AddAndUpdateSchedulesCompleted += AddAndUpdateSchedulesCompleted;
                        _scheduleServiceClient.AddAndUpdateSchedulesAsync(combinedNewAndUpdatedSchedules);
                    }

                }
            }
        }

        private void DeleteButtonClick()
        {
            if ((_scheduleServiceClient != null) && (_schedules.Count != 0))
            {
                _scheduleServiceClient.DeleteSchedulesCompleted += DeleteSchedulesCompleted;
                _scheduleServiceClient.DeleteSchedulesAsync(_schedules);
            }
        }
        #endregion

        #region Callback methods of Services

        #region Employee Service
        private void GetAllEmployeesCompleted(object sender, GetAllEmployeesCompletedEventArgs e)
        {
            _employeeServiceClient.GetAllEmployeesCompleted -= GetAllEmployeesCompleted;

            foreach (IManageEmployeeService.Employee emp in e.Result)
            {
                if (!emp.IsDeleted)
                {
                    Employees.Add(emp);
                }
            }
        }
        #endregion

        #region Schedule Service
        private void AddSchedulesCompleted(object sender, AddSchedulesCompletedEventArgs e)
        {
            _scheduleServiceClient.AddSchedulesCompleted -= AddSchedulesCompleted;
            bool success = e.Result;
            if (success)
            {
                Message = Models.Message.Added;
            }
            else
            {
                Message = Models.Message.UnableToAdd;
            }
        }
        private void AddAndUpdateSchedulesCompleted(object sender, AddAndUpdateSchedulesCompletedEventArgs e)
        {
            _scheduleServiceClient.AddAndUpdateSchedulesCompleted -= AddAndUpdateSchedulesCompleted;
            bool success = e.Result;
            Message = success ? Models.Message.Updated : Models.Message.UpdateUnsucess;
        }
        private void DeleteSchedulesCompleted(object sender, DeleteSchedulesCompletedEventArgs e)
        {
            _scheduleServiceClient.DeleteSchedulesCompleted -= DeleteSchedulesCompleted;
            if (e.Result)
            {
                Message = Models.Message.Deleted;
                ResetHours();
            }
            else
            {
                Message = Models.Message.DeleteUnsucess;
            }
        }

        private void AddToSchedules(ObservableCollection<Schedule> schedules)
        {
            _schedules = new ObservableCollection<Schedule>();
            foreach (Schedule schedule in schedules)
            {
                if (!schedule.IsDeleted)
                {
                    _schedules.Add(schedule);
                }
            }
        }

        private void AssignStartAndHourOfWeekDay(ObservableCollection<Schedule> schedules)
        {
            foreach (IManageScheduleService.Schedule schedule in schedules)
            {
                switch (schedule.WeekDay)
                {
                    case WeekDay.Monday:
                        StartHourMonday = schedule.StartHour;
                        EndHourMonday = schedule.EndHour;
                        break;
                    case WeekDay.Tuesday:
                        StartHourTuesday = schedule.StartHour;
                        EndHourTuesday = schedule.EndHour;
                        break;
                    case WeekDay.Wednesday:
                        StartHourWednesday = schedule.StartHour;
                        EndHourWednesday = schedule.EndHour;
                        break;
                    case WeekDay.Thursday:
                        StartHourThursday = schedule.StartHour;
                        EndHourThursday = schedule.EndHour;
                        break;
                    case WeekDay.Friday:
                        StartHourFriday = schedule.StartHour;
                        EndHourFriday = schedule.EndHour;
                        break;
                    case WeekDay.Saturday:
                        StartHourSaturday = schedule.StartHour;
                        EndHourSaturday = schedule.EndHour;
                        break;
                    case WeekDay.Sunday:
                        StartHourSunday = schedule.StartHour;
                        EndHourSunday = schedule.EndHour;
                        break;
                }
            }
        }
        private void GetSchedulesWithEmployeePinCodeAndWeekNumberCompleted(object sender, GetSchedulesWithEmployeePinCodeAndWeekNumberCompletedEventArgs e)
        {
            ResetHours();

            AddToSchedules(e.Result);

            AssignStartAndHourOfWeekDay(_schedules);

            ActionButtonContent = CheckAtLeastWeekDayHourHasValue() ? "AddorUpdate" : "Add";
        }
        #endregion

        #endregion

        #endregion
    }

}
