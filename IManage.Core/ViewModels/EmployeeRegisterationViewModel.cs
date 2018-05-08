using IManage.Core.IManageEmployeeService;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using System;
using Gender = IManage.Core.IManageEmployeeService.Gender;
using JobTitle = IManage.Core.Models.JobTitle;

namespace IManage.Core.ViewModels
{

    /// <summary>
    /// A class which handles the interaction of EmployeeRegistration View
    /// </summary>
    public class EmployeeRegisterationViewModel : BaseManagerViewModel
    {
        #region Private Data
        /// <summary>
        /// Reference to employee service client
        /// </summary>
        private readonly EmployeeServiceClient _employeeServiceClient;

        /// <summary>
        /// Reference to employee model
        /// </summary>
        private Models.Employee _employee;

        /// <summary>
        /// Reference to a message
        /// </summary>
        private Message? _message;

        #region Commands
        /// <summary>
        /// Reference to reseting command
        /// </summary>
        private IMvxCommand _clearAllInputFieldsCommand;

        /// <summary>
        /// Reference to save command
        /// </summary>
        private IMvxCommand _saveButtonCommand;
        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets an employee model
        /// </summary>
        public Models.Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                RaisePropertyChanged(() => Employee);
            }
        }

        /// <summary>
        /// Gets and sets success message
        /// </summary>
        public Message? Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        /// <summary>
        /// Gets and sets genders collection
        /// </summary>
        public MvxObservableCollection<Models.Gender> Genders { get; set; }

        /// <summary>
        /// Gets and sets jobtitle collection
        /// </summary>
        public MvxObservableCollection<JobTitle> JobTitles { get; set; }


        #region Commands
        /// <summary>
        ///Gets the clear command
        /// </summary>
        public IMvxCommand ClearAllInputFieldsCommand
        {
            get
            {
                _clearAllInputFieldsCommand = _clearAllInputFieldsCommand ?? new MvxCommand(ClearingAllInputFields);
                return _clearAllInputFieldsCommand;
            }
        }

        /// <summary>
        ///Gets the save command
        /// </summary>
        public IMvxCommand SaveButtonCommand
        {
            get
            {
                _saveButtonCommand = _saveButtonCommand ?? new MvxCommand(SavingAllInputFields);
                return _saveButtonCommand;
            }
        }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the members
        /// </summary>
        public EmployeeRegisterationViewModel()
        {

            _employeeServiceClient = new EmployeeServiceClient();
            Employee = new Models.Employee();
            Message = null;
            Genders = new MvxObservableCollection<Models.Gender> { Models.Gender.Male, Models.Gender.Female };
            JobTitles = new MvxObservableCollection<JobTitle> { Models.JobTitle.Chef, Models.JobTitle.DishWasher, Models.JobTitle.Manager, Models.JobTitle.Waiter };
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
        /// <summary>
        /// Clearing all input fields
        /// </summary>
        private void ClearingAllInputFields()
        {
            Employee = new Models.Employee();
        }

        /// <summary>
        /// Convert model gender to employee service gender
        /// </summary>
        /// <param name="gender">Gender to be convert</param>
        /// <returns>Employee service type gender</returns>
        protected Gender ConvertModelGenderToEmployeeServiceGender(Models.Gender? gender)
        {
            if (gender != null && gender.Value == Models.Gender.Female)
                return Gender.Female;

            return Gender.Male;
        }

        /// <summary>
        /// Convert model job title to employee service job title
        /// </summary>
        /// <param name="jobTitle">Job title to be convert</param>
        /// <returns>Employee service type job title</returns>
        protected IManageEmployeeService.JobTitle ConvertModelJobTitleToEmployeeServiceJobTitle(Models.JobTitle? jobTitle)
        {
            IManageEmployeeService.JobTitle rJobTitle = IManageEmployeeService.JobTitle.Manager;
            if (jobTitle.HasValue)
            {
                switch (jobTitle)
                {
                    case JobTitle.Chef:
                        rJobTitle = IManageEmployeeService.JobTitle.Chef;
                        break;
                    case JobTitle.Waiter:
                        rJobTitle = IManageEmployeeService.JobTitle.Waiter;
                        break;
                    case JobTitle.DishWasher:
                        rJobTitle = IManageEmployeeService.JobTitle.DishWasher;
                        break;
                }
            }
            return rJobTitle;
        }

        /// <summary>
        /// Save information
        /// </summary>
        private void SavingAllInputFields()
        {
            if (_employeeServiceClient != null)
            {
                if (!string.IsNullOrEmpty(Employee?.FirstName) && !string.IsNullOrEmpty(Employee.LastName) &&
                    !string.IsNullOrEmpty(Employee.Email) && !string.IsNullOrEmpty(Employee.Address) &&
                    !string.IsNullOrEmpty(Employee.BsnNumber) && Employee.PhoneNumber.HasValue &&
                    Employee.JobTitle.HasValue && Employee.Gender.HasValue)
                {
                    _employeeServiceClient.SaveEmployeeCompleted += SaveEmployeeCompleted;

                    Gender gender = ConvertModelGenderToEmployeeServiceGender(Employee.Gender);

                    IManageEmployeeService.JobTitle jobTitle =
                        ConvertModelJobTitleToEmployeeServiceJobTitle(Employee.JobTitle);

                    int bsnNumber = Convert.ToInt32(Employee.BsnNumber);

                    if (Employee.PhoneNumber != null && Employee.DateOfBirth != null)
                    {
                        _employeeServiceClient.SaveEmployeeAsync
                        (Employee.FirstName, Employee.LastName, Employee.Email, bsnNumber,
                            Employee.Address, Employee.PhoneNumber.Value,
                            Employee.DateOfBirth.Value, gender, jobTitle);
                    }
                }
                else
                {
                    Message = Models.Message.NotAllFieldsComplete;
                }
            }
        }

        /// <summary>
        /// Sets message according to the response from the service
        /// </summary>
        /// <param name="sender">An event sender</param>
        /// <param name="e">An event arg</param>
        private void SaveEmployeeCompleted(object sender, SaveEmployeeCompletedEventArgs e)
        {
            _employeeServiceClient.SaveEmployeeCompleted -= SaveEmployeeCompleted;
            Message = e.Result ? Models.Message.Saved : Models.Message.UnSaved;
        }
        #endregion

    }
}
