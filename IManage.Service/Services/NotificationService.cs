using IManageService.BusinessLogic;
using IManageService.BusinessLogic.Domain;
using IManageService.Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace IManageService.Services
{
    [ServiceBehavior]
    public class NotificationService : INotificationService
    {
        #region Public Constant Data
        public const string NameOfService = "Notification Service";
        public const string ServiceAddress = "http://localhost:8090/IManageService/Services/NotificationService/";
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets and sets the unit of work instance
        /// </summary>
        public static IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region Private Data
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructor

        public NotificationService()
        {
            _employeeService = new EmployeeService();
        }
        #endregion

        #region INotificationService Implementation
        public bool SendNotification(Notification notification)
        {
            bool onSuccess = false;
            if ((UnitOfWork != null) && (_employeeService != null))
            {
                Employee employee = UnitOfWork.Employees.GetEmployeeWithGivenPinCode(notification.EmployeePinCode);
                if (employee != null)
                {
                    notification.Employee = employee;

                    UnitOfWork.Notifications.Add(notification);
                    if (UnitOfWork.SaveChanges() >= 1)
                    {
                        onSuccess = true;
                    }
                }
            }

            return onSuccess;
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return UnitOfWork?.Notifications.GetAll();
        }

        #endregion
    }
}
