using System.ComponentModel;

namespace VacationManager.Common.Enums
{
    /// <summary>
    /// Internal error codes for the application.
    /// </summary>
    public enum ReasonCodeEnum
    {
        #region Employee
        EmailNotUnique = 100,
        ManagerNotFound = 101,
        EmployeeNotFound = 102,
        #endregion

        #region Vacation
        VacationPeriodAlreadyBooked = 200,
        VacationNotFound = 201
        #endregion

    }
}
