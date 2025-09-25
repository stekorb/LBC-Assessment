using System.ComponentModel;

namespace VacationManager.Common.Enums
{
    /// <summary>
    /// Internal error codes for the application.
    /// </summary>
    public enum ReasonCodeEnum
    {
        UserNotFound = 100,

        #region Employee
        EmailNotUnique = 200,
        ManagerNotFound = 201,
        EmployeeNotFound = 202,
        #endregion

        #region Vacation
        VacationPeriodAlreadyBooked = 300,
        VacationNotFound = 301,
        VacationNotUnderManagement = 302,
        NotVacationOwner = 303,
        NotAllowedToSeeEmployeeVacations = 304,
        DoesNotHaveReviewPermission = 305,
        DoesNotHaveEditPermission = 306, 
        DoesNotHaveDeletePermission = 307
        #endregion

    }
}
