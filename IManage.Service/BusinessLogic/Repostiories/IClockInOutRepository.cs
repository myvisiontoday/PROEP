﻿using IManageService.BusinessLogic.Domain;

namespace IManageService.BusinessLogic.Repostiories
{
    /// <summary>
    /// An interface for a class providing capabilities to perform CRUD in ClockInOut entity 
    /// </summary>
    public interface IClockInOutRepository : IRepository<ClockInOut>
    {
        ClockInOut GetClockInOutWhoseClockOutDateTimeIsNull(string employeePinCode);
    }
}
