using IManage.Core.IManageEmployeeService;
using IManage.Core.IManageNotificationService;
using IManage.Core.IManageStockService1;
using IManage.Core.Models;
using IManage.Core.ViewModels.BaseViewModels;
using MvvmCross.Core.ViewModels;
using Employee = IManage.Core.IManageEmployeeService.Employee;

namespace IManage.Core.ViewModels
{
    /// <summary>
    /// A class which handles the interaction of Manager View
    /// </summary>
    public class ManagerViewModel : BaseManagerViewModel
    {
        #region Static Properties
        public static ClientDetailParameter ClientDetailParameter { get; set; }
        #endregion

        #region Private Data 

        private readonly EmployeeServiceClient _employeeServiceClient;
        private readonly StockServiceClient _stockServiceClient;
        private readonly NotificationServiceClient _notificationServiceClient;

        #region Bindings

        private MvxObservableCollection<Item> _itemsToOrder;
        private MvxObservableCollection<IManageNotificationService.Notification> _notifications;
        private MvxObservableCollection<Employee> _employees;
        #endregion

        #endregion

        #region Properties

        #region Bindings

        public MvxObservableCollection<Item> ItemsToOrder
        {
            get => _itemsToOrder;
            set
            {
                _itemsToOrder = value;
                RaisePropertyChanged(() => ItemsToOrder);
            }
        }

        public MvxObservableCollection<IManageNotificationService.Notification> Notifications
        {
            get => _notifications;
            set
            {
                _notifications = value;
                RaisePropertyChanged(() => Notifications);
            }
        }
        public MvxObservableCollection<Employee> Employees

        {
            get => _employees;
            set
            {
                _employees = value;
                RaisePropertyChanged(() => Employees);
            }
        }
        #endregion

        #endregion

        #region Constructor

        public ManagerViewModel()
        {
            ItemsToOrder = new MvxObservableCollection<Item>();
            Notifications = new MvxObservableCollection<IManageNotificationService.Notification>();
            Employees = new MvxObservableCollection<Employee>();
            _employeeServiceClient = new EmployeeServiceClient();
            _notificationServiceClient = new NotificationServiceClient();
            _stockServiceClient = new StockServiceClient();

            _stockServiceClient.GetAllItemsCompleted += GetAllItemsCompleted;
            _stockServiceClient.GetAllItemsAsync();

            _notificationServiceClient.GetAllNotificationsCompleted += GetAllNotificationsCompleted;
            _notificationServiceClient.GetAllNotificationsAsync();

            _employeeServiceClient.GetAllEmployeesCompleted += GetAllEmployeesCompleted;
            _employeeServiceClient.GetAllEmployeesAsync();
        }

        private void GetAllEmployeesCompleted(object sender, GetAllEmployeesCompletedEventArgs e)
        {
            _employeeServiceClient.GetAllEmployeesCompleted -= GetAllEmployeesCompleted;
            Employees.Clear();
            foreach (Employee employee in e.Result)
            {
                Employees.Add(employee);
            }
        }

        private void GetAllNotificationsCompleted(object sender, GetAllNotificationsCompletedEventArgs e)
        {
            _notificationServiceClient.GetAllNotificationsCompleted -= GetAllNotificationsCompleted;
            Notifications.Clear();
            foreach (IManageNotificationService.Notification notification in e.Result)
            {
                Notifications.Add(notification);
            }
        }

        private void GetAllItemsCompleted(object sender, GetAllItemsCompletedEventArgs e)
        {
            _stockServiceClient.GetAllItemsCompleted -= GetAllItemsCompleted;
            ItemsToOrder.Clear();
            foreach (Item item in e.Result)
            {
                if (item.Quantity <= 1)
                {
                    ItemsToOrder.Add(item);
                }
            }
        }
        #endregion

        #region Public Methods

        public void Init(ClientDetailParameter parameter)
        {
            if (parameter != null)
            {
                ClientDetailParameter = parameter;
                DropDownMenus = new MvxObservableCollection<string> { "Welcome " + parameter.Name, "LogOut" };
            }
        }
        #endregion
    }
}
