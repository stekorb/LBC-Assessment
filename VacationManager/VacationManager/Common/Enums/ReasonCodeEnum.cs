using System.ComponentModel;

namespace VacationManager.Common.Enums
{
    /// <summary>
    /// Internal error codes for the application.
    /// </summary>
    public enum ReasonCodeEnum
    {
        #region Employee
        [Description("Email must be unique.")]
        EmailNotUnique = 100,

        [Description("ManagerId must already be registered to a manager.")]
        ManagerNotFound = 101,

        [Description("Employee was not found.")]
        EmployeeNotFound = 102,
        #endregion

        #region Vacation
        [Description("Vacation period is already booked for another.")]
        VacationPeriodAlreadyBooked = 200
        #endregion

    }
}
