using IManage.Core.IManageEmployeeService;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using System.ComponentModel;
using System.Windows.Data;
using Gender = IManage.Core.IManageEmployeeService.Gender;
using JobTitle = IManage.Core.IManageEmployeeService.JobTitle;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of EmployeeList View
    /// </summary>
    public class EmployeeListViewModel : BaseManagerViewModel
    {
        #region Private Data
        private IManageEmployeeService.Employee _selectedEmployee;
        private string _selectedEmployeeGender;
        private string _selectedEmployeeJobTitle;
        private int? _selectedGenderIndex;
        private int? _selectedJobTitleIndex;
        private MvxObservableCollection<IManageEmployeeService.Employee> _employees;
        private string _employeeSearchText;
        private Message? _message;
        private readonly EmployeeServiceClient _employeeServiceClient;
        /// <summary>
        /// Reference to update command
        /// </summary>
        private IMvxCommand _deleteButtonCommand;
        /// <summary>
        /// Reference to update command
        /// </summary>
        private IMvxCommand _updateButtonCommand;
        /// <summary>
        /// Reference to update command
        /// </summary>
        private IMvxCommand _clearAllButtonCommand;
        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets genders collection
        /// </summary>
        public MvxObservableCollection<Gender> Genders { get; set; }

        /// <summary>
        /// Gets and sets jobtitle collection
        /// </summary>
        public MvxObservableCollection<JobTitle> JobTitles { get; set; }

        public IManageEmployeeService.Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged(() => SelectedEmployee);
                if (_selectedEmployee != null && SelectedEmployee.Gender != null && SelectedEmployee.JobTitle != null)
                {

                    SelectedGenderIndex = Genders.IndexOf(SelectedEmployee.Gender.Value);
                    SelectedJobTitleIndex = JobTitles.IndexOf(SelectedEmployee.JobTitle.Value);
                }

            }
        }

        public string SelectedEmployeeGender
        {
            get
            {
                return _selectedEmployeeGender;
            }
            set
            {
                _selectedEmployeeGender = value;
                RaisePropertyChanged(() => SelectedEmployeeGender);
            }
        }

        public string SelectedEmployeeJobTitle
        {
            get
            {
                return _selectedEmployeeJobTitle;
            }
            set
            {
                _selectedEmployeeJobTitle = value;
                RaisePropertyChanged(() => SelectedEmployeeJobTitle);
            }
        }

        public int? SelectedGenderIndex
        {
            get
            {
                return _selectedGenderIndex;
            }
            set
            {
                _selectedGenderIndex = value;
                RaisePropertyChanged(() => SelectedGenderIndex);
            }
        }



        public int? SelectedJobTitleIndex
        {
            get
            {
                return _selectedJobTitleIndex;
            }
            set
            {
                _selectedJobTitleIndex = value;
                RaisePropertyChanged(() => SelectedJobTitleIndex);
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
        public Message? Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        public ICollectionView EmployeeView => CollectionViewSource.GetDefaultView(Employees);

        #region Commands

        /// <summary>
        ///Gets the save command
        /// </summary>
        public IMvxCommand DeleteButtonCommand
        {
            get
            {
                _deleteButtonCommand = _deleteButtonCommand ?? new MvxCommand(DeleteEmployee);
                return _deleteButtonCommand;
            }
        }

        /// <summary>
        ///Gets the save command
        /// </summary>
        public IMvxCommand UpdateButtonCommand
        {
            get
            {
                _updateButtonCommand = _updateButtonCommand ?? new MvxCommand(UpdateEmployeeInfromation);
                return _updateButtonCommand;
            }
        }

        /// <summary>
        ///Gets the save command
        /// </summary>
        public IMvxCommand ClearAllButtonCommand
        {
            get
            {
                _clearAllButtonCommand = _clearAllButtonCommand ?? new MvxCommand(ClearingAllInputFields);
                return _clearAllButtonCommand;
            }
        }

        #endregion

        #endregion

        #region Constructor
        public EmployeeListViewModel()
        {
            Employees = new MvxObservableCollection<IManageEmployeeService.Employee>();
            EmployeeView.Filter = employee => Filter(employee as IManageEmployeeService.Employee);
            Genders = new MvxObservableCollection<Gender> { Gender.Male, Gender.Female };
            JobTitles = new MvxObservableCollection<JobTitle> { JobTitle.Chef, JobTitle.DishWasher, JobTitle.Manager, JobTitle.Waiter };

            _employeeServiceClient = new EmployeeServiceClient();

            _employeeServiceClient.GetAllEmployeesCompleted += GetAllEmployeesCompleted;
            _employeeServiceClient.GetAllEmployeesAsync();
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
        private bool Filter(IManageEmployeeService.Employee employee)
        {
            return string.IsNullOrEmpty(EmployeeSearchText) ||
                   EmployeeSearchText.ToLower().StartsWith(employee.FirstName.ToLower()) ||
                   EmployeeSearchText.ToLower().StartsWith(employee.LastName.ToLower());
        }
        private Gender? ConvertStringGenderToGenderEnum(string gender)
        {

            switch (gender.ToLower())
            {
                case "male":
                    return Gender.Male;
                case "female":
                    return Gender.Female;
            }
            return null;
        }

        private JobTitle? ConvertStringJobTitleToJobTitleEnum(string jobTitle)
        {
            if (jobTitle != null)
            {
                switch (jobTitle.ToLower())
                {

                    case "manager":
                        return IManageEmployeeService.JobTitle.Manager;
                    case "chef":
                        return IManageEmployeeService.JobTitle.Chef;
                    case "waiter":
                        return IManageEmployeeService.JobTitle.Waiter;

                    case "dishWasher":
                        return IManageEmployeeService.JobTitle.DishWasher;
                }
            }
            return null;
        }

        #region Command  Callback Methods
        private void ClearingAllInputFields()
        {
            SelectedEmployee = null;
            SelectedEmployeeJobTitle = null;
            SelectedEmployeeGender = null;
            SelectedGenderIndex = null;
            SelectedJobTitleIndex = null;
        }
        private void DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                _employeeServiceClient.DeleteEmployeeWithGivenPinCodeCompleted += DeleteEmployeeWithGivenPinCodeCompleted;
                _employeeServiceClient.DeleteEmployeeWithGivenPinCodeAsync(SelectedEmployee.PinCode);
            }
        }

        /// <summary>
        /// Update information
        /// </summary>
        private void UpdateEmployeeInfromation()
        {
            if (!string.IsNullOrEmpty(SelectedEmployee?.FirstName) && !string.IsNullOrEmpty(SelectedEmployee.LastName) &&
                !string.IsNullOrEmpty(SelectedEmployee.Email) && !string.IsNullOrEmpty(SelectedEmployee.Address) &&
                SelectedEmployee.BsnNumber.HasValue && SelectedEmployee.JobTitle.HasValue && SelectedEmployee.Gender.HasValue &&
                SelectedEmployee.PhoneNumber != 0 && SelectedEmployee.DateOfBirth.HasValue)
            {
                _employeeServiceClient.UpdateEmployeeCompleted += UpdateEmployeeCompleted;

                SelectedEmployee.Gender = ConvertStringGenderToGenderEnum(SelectedEmployeeGender);
                SelectedEmployee.JobTitle = ConvertStringJobTitleToJobTitleEnum(SelectedEmployeeJobTitle);

                _employeeServiceClient.UpdateEmployeeAsync(SelectedEmployee.PinCode, SelectedEmployee.FirstName, SelectedEmployee.LastName, SelectedEmployee.Email, SelectedEmployee.BsnNumber.Value, SelectedEmployee.Address, SelectedEmployee.PhoneNumber, SelectedEmployee.DateOfBirth.Value, SelectedEmployee.Gender.Value, SelectedEmployee.JobTitle.Value);
            }
            else
            {
                Message = Models.Message.NotAllFieldsComplete;
            }

        }
        #endregion

        #region Service Callback Methods
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

        private void DeleteEmployeeWithGivenPinCodeCompleted(object sender, DeleteEmployeeWithGivenPinCodeCompletedEventArgs e)
        {
            _employeeServiceClient.DeleteEmployeeWithGivenPinCodeCompleted -= DeleteEmployeeWithGivenPinCodeCompleted;
            if (e.Result && Employees != null)
            {
                Message = Models.Message.Deleted;
                Employees.Remove(SelectedEmployee);
                SelectedGenderIndex = null;
                SelectedEmployeeJobTitle = null;
            }
            else
            {
                Message = Models.Message.DeleteUnsucess;
            }
        }

        private void UpdateEmployeeCompleted(object sender, UpdateEmployeeCompletedEventArgs e)
        {
            _employeeServiceClient.UpdateEmployeeCompleted -= UpdateEmployeeCompleted;
            Message = e.Result ? Models.Message.Updated : Models.Message.UpdateUnsucess;
        }
        #endregion


        #endregion
    }
}
