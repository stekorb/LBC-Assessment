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
        public const string Administrator = nameof(Administrator);
        public const string Manager = nameof(Manager);
        public const string Employee = nameof(Employee);
    }
}
