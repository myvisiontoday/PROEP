using IManageService.BusinessLogic;
using IManageService.Persistence;
using IManageService.Services;
using System;
using System.ServiceModel;

namespace IManageTestServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost loginServiceHost = null, employeeServiceHost = null, scheduleServiceHost = null;
            ServiceHost clockServiceHost = null, notificationServiceHost = null, stockServiceHost = null;
            IUnitOfWork unitOfWorkForLoginService = new UnitOfWork(new AppiManageDatabaseContext());
            IUnitOfWork unitOfWorkForEmployeeService = new UnitOfWork(new AppiManageDatabaseContext());
            IUnitOfWork unitOfWorkForScheduleService = new UnitOfWork(new AppiManageDatabaseContext());
            IUnitOfWork unitOfWorkForClockService = new UnitOfWork(new AppiManageDatabaseContext());
            IUnitOfWork unitOfWorkForNotificationService = new UnitOfWork(new AppiManageDatabaseContext());
            IUnitOfWork unitOfWorkForStockService = new UnitOfWork(new AppiManageDatabaseContext());
            try
            {
                loginServiceHost = new ServiceHost(typeof(LoginService));
                employeeServiceHost = new ServiceHost(typeof(EmployeeService));
                scheduleServiceHost = new ServiceHost(typeof(ScheduleService));
                clockServiceHost = new ServiceHost(typeof(ClockService));
                notificationServiceHost = new ServiceHost(typeof(NotificationService));
                stockServiceHost = new ServiceHost(typeof(StockService));

                loginServiceHost.Open();
                employeeServiceHost.Open();
                scheduleServiceHost.Open();
                clockServiceHost.Open();
                notificationServiceHost.Open();
                stockServiceHost.Open();

                //setting unit of work
                LoginService.UnitOfWork = unitOfWorkForLoginService;
                EmployeeService.UnitOfWork = unitOfWorkForEmployeeService;
                ScheduleService.UnitOfWork = unitOfWorkForScheduleService;
                ClockService.UnitOfWork = unitOfWorkForClockService;
                NotificationService.UnitOfWork = unitOfWorkForNotificationService;
                StockService.UnitOfWork = unitOfWorkForStockService;

                Console.WriteLine(LoginService.NameOfService + @" started @" + DateTime.Now);
                Console.WriteLine(LoginService.NameOfService + @" available " + LoginService.ServiceAddress);

                Console.WriteLine();

                Console.WriteLine(EmployeeService.NameOfService + @" started @" + DateTime.Now);
                Console.WriteLine(EmployeeService.NameOfService + @" available " + EmployeeService.ServiceAddress);

                Console.WriteLine();

                Console.WriteLine(ScheduleService.NameOfService + @" started @" + DateTime.Now);
                Console.WriteLine(ScheduleService.NameOfService + @" available " + ScheduleService.ServiceAddress);

                Console.WriteLine();

                Console.WriteLine(ClockService.NameOfService + @" started @" + DateTime.Now);
                Console.WriteLine(ClockService.NameOfService + @" available " + ClockService.ServiceAddress);

                Console.WriteLine();

                Console.WriteLine(NotificationService.NameOfService + @" started @" + DateTime.Now);
                Console.WriteLine(NotificationService.NameOfService + @" available " + NotificationService.ServiceAddress);

                Console.WriteLine();

                Console.WriteLine(StockService.NameOfService + @" started @" + DateTime.Now);
                Console.WriteLine(StockService.NameOfService + @" available " + StockService.ServiceAddress);

                Console.WriteLine();

                Console.WriteLine(@"Press enter to close the service..............");
                Console.ReadLine();
            }
            finally
            {
                if ((loginServiceHost != null) && (employeeServiceHost != null) && (scheduleServiceHost != null) &&
                    (clockServiceHost != null) && (notificationServiceHost != null) && (stockServiceHost != null))
                {
                    unitOfWorkForLoginService.Dispose();
                    unitOfWorkForEmployeeService.Dispose();
                    unitOfWorkForScheduleService.Dispose();
                    unitOfWorkForClockService.Dispose();
                    unitOfWorkForNotificationService.Dispose();
                    unitOfWorkForStockService.Dispose();
                    loginServiceHost.Close();
                    employeeServiceHost.Close();
                    scheduleServiceHost.Close();
                    clockServiceHost.Close();
                    notificationServiceHost.Close();
                    stockServiceHost.Close();
                }
            }


        }
    }
}
