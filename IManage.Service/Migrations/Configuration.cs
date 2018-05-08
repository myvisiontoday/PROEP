using IManageService.BusinessLogic.Domain;
using System;

namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<IManageService.Persistence.AppiManageDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IManageService.Persistence.AppiManageDatabaseContext context)
        {


            //Seeding client table

            //context.Clients.AddOrUpdate(client => client.Id,
            //new Client { UserName = "admin", PassWord = "admin", IsSubscriptionsExpired = true, SubscriptionsStartDate = DateTime.Now, SubscriptionsEndDate = DateTime.Now },
            // new Client { UserName = "fontys", PassWord = "fontys123", IsSubscriptionsExpired = true, SubscriptionsStartDate = DateTime.Now, SubscriptionsEndDate = DateTime.Now.AddYears(1) });


            //Seeding employee table

            //context.Employees.AddOrUpdate(employee => employee.PinCode,
            //    new Employee("Binod", "Nepali", "nepalibinod9@gmail.com", 495734573, "Fredirklaan 175 B6, Eindhoven",
            //        0685002983, new DateTime(1995, 12, 29), Gender.Male, JobTitle.Chef)
            //    {
            //        PinCode = "0001",
            //        IsDeleted = false
            //    });
            //    new Employee("Rabindra", "Simkhada", "test1@gmail.com", 49573454, "Fredirklaan 175 B7, Eindhoven", 0685002984, new DateTime(1992, 12, 29), Gender.Male, JobTitle.Chef) { PinCode = "0002", IsDeleted = false },
            //    new Employee("Simon", "omna", "test2@gmail.com", 495734575, "Fredirklaan 175 B8, Eindhoven", 0685002988, new DateTime(1991, 12, 29), Gender.Male, JobTitle.Waiter) { PinCode = "0003", IsDeleted = false },
            //    new Employee("Zeo", "zijn", "test3@gmail.com", 495734576, "Fredirklaan 175 B9, Eindhoven", 0685002986, new DateTime(1996, 12, 29), Gender.Female, JobTitle.Waiter) { PinCode = "0004", IsDeleted = false },
            //    new Employee("Farnaz", "Najiz", "test4@gmail.com", 495734577, "Fredirklaan 175 B10, Eindhoven", 0685002989, new DateTime(1993, 12, 29), Gender.Female, JobTitle.Waiter) { PinCode = "0005", IsDeleted = false },
            //    new Employee("Paul", "Toagwa", "test5@gmail.com", 495734578, "Fredirklaan 175 B11, Eindhoven", 0685002990, new DateTime(1990, 12, 29), Gender.Male, JobTitle.DishWasher) { PinCode = "0006", IsDeleted = false },
            //    new Employee("Tester", "Tester", "test6@gmail.com", 495734578, "Fredirklaan 175 B11, Eindhoven", 0685002990, new DateTime(1990, 12, 29), Gender.Male, JobTitle.DishWasher) { PinCode = "0006", IsDeleted = false });


            //seeding Schedules table
            //context.Schedules.AddOrUpdate(schedule => schedule.Id,
            //    new Schedule(WeekDay.Monday, 1, "0001", new DateTime(2018, 01, 01, 18, 00, 00),
            //        new DateTime(2018, 01, 01, 23, 00, 00))
            //    {
            //        EmployeeId = 1,
            //        CreatedDate = DateTime.Now,
            //        IsDeleted = false
            //    },
            //new Schedule(WeekDay.Tuesday, 1, "0001", new DateTime(2018, 01, 02, 09, 00, 00), new DateTime(2018, 01, 02, 09, 00, 00)) { EmployeeId = 1, CreatedDate = DateTime.Now.AddMinutes(1), IsDeleted = false },
            //new Schedule(WeekDay.Wednesday, 2, "0002", new DateTime(2018, 01, 08, 18, 00, 00), new DateTime(2018, 01, 08, 23, 00, 00)) { EmployeeId = 2, CreatedDate = DateTime.Now.AddMinutes(1), IsDeleted = false },
            //new Schedule(WeekDay.Thursday, 2, "0002", new DateTime(2018, 01, 09, 18, 00, 00), new DateTime(2018, 01, 09, 23, 00, 00)) { EmployeeId = 2, CreatedDate = DateTime.Now.AddMinutes(1), IsDeleted = false },
            //new Schedule(WeekDay.Friday, 3, "0003", new DateTime(2018, 01, 16, 18, 00, 00), new DateTime(2018, 01, 16, 23, 00, 00)) { EmployeeId = 3, CreatedDate = DateTime.Now.AddMinutes(1), IsDeleted = false },
            //new Schedule(WeekDay.Saturday, 2, "0003", new DateTime(2018, 01, 10, 18, 00, 00), new DateTime(2018, 01, 10, 23, 00, 00)) { EmployeeId = 3, CreatedDate = DateTime.Now.AddMinutes(1), IsDeleted = false });

            ////seeding ClockInOuts table
            //context.ClockInOuts.AddOrUpdate(clockInOut => clockInOut.Id,
            //    new ClockInOut
            //    {
            //        ClockInDateTime = DateTime.Now,
            //        ClockOutDateTime = null,
            //        TotalHoursWorked = 0,
            //        EmployeeId = 1,
            //        EmployeePinCode = "0001"
            //    },
            //    new ClockInOut
            //    {
            //        ClockInDateTime = DateTime.Now,
            //        ClockOutDateTime = null,
            //        TotalHoursWorked = 0,
            //        EmployeeId = 2,
            //        EmployeePinCode = "0002"
            //    });
            //new ClockInOut { ClockInDateTime = new DateTime(2018, 01, 02, 09, 00, 00), ClockOutDateTime = new DateTime(2018, 01, 02, 09, 00, 00).AddHours(9), TotalHoursWorked = 9, EmployeeId = 1, EmployeePinCode = "0001" },
            //new ClockInOut { ClockInDateTime = new DateTime(2018, 01, 03, 18, 00, 00), ClockOutDateTime = new DateTime(2018, 01, 03, 18, 00, 00).AddHours(5), TotalHoursWorked = 5, EmployeeId = 2, EmployeePinCode = "0002" },
            //new ClockInOut { ClockInDateTime = new DateTime(2018, 01, 04, 18, 00, 00), ClockOutDateTime = new DateTime(2018, 01, 04, 18, 00, 00).AddHours(4), TotalHoursWorked = 4, EmployeeId = 2, EmployeePinCode = "0002" },
            //new ClockInOut { ClockInDateTime = new DateTime(2018, 01, 05, 18, 00, 00), ClockOutDateTime = new DateTime(2018, 01, 05, 18, 00, 00).AddHours(4), TotalHoursWorked = 4, EmployeeId = 3, EmployeePinCode = "0003" },
            //new ClockInOut { ClockInDateTime = new DateTime(2018, 01, 06, 18, 00, 00), ClockOutDateTime = new DateTime(2018, 01, 06, 18, 00, 00).AddHours(4), TotalHoursWorked = 4, EmployeeId = 3, EmployeePinCode = "0003" });

            ////seeding notifications table
            context.Notifications.AddOrUpdate(notification => notification.Id,
                new Notification { Message = "dish washer is not working", IsResolved = false, CreatedDate = DateTime.Now, EmployeeId = 1, EmployeePinCode = "0001" },
                new Notification { Message = "there is no fire extinguisher", IsResolved = true, CreatedDate = DateTime.Now.AddDays(1), EmployeeId = 2, EmployeePinCode = "0002" },
                new Notification { Message = "emergency light is not working", IsResolved = true, CreatedDate = DateTime.Now.AddDays(2), EmployeeId = 3, EmployeePinCode = "0003" },
                new Notification { Message = "vaccumer is not working properly", IsResolved = false, CreatedDate = DateTime.Now.AddDays(3), EmployeeId = 4, EmployeePinCode = "0004" });

            ////seeding Items table
            //context.Items.AddOrUpdate(item => item.Name,
            //    new Item("Onion", 5, 10.2) { AddedDate = DateTime.Now, IsDeleted = false },
            //    new Item("Potato", 5, 6.89) { AddedDate = DateTime.Now.AddMinutes(2), IsDeleted = false },
            //    new Item("Garlic", 3, 7.80) { AddedDate = DateTime.Now.AddMinutes(5), IsDeleted = false },
            //    new Item("Ginger", 2, 5.50) { AddedDate = DateTime.Now.AddMinutes(7), IsDeleted = false });
        }
    }
}
