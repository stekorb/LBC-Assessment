namespace VacationManager.Common.Enums
{
    public enum RoleEnum
    {
        Administrator,
        Manager,
        Employee
    }

    public static class Roles
    {
        public const string Administrator = nameof(RoleEnum.Administrator);
        public const string Manager = nameof(RoleEnum.Manager);
        public const string Employee = nameof(RoleEnum.Employee);
    }
}
