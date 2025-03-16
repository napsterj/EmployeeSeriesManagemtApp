namespace EmployeeSeriesManagemt.Frontend
{
    public static class AppConstants
    {
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public const string BY_CITY = "bycity";
        public const string BY_DATES = "bydates";
        public const string BY_ID = "byid";

        public const string INVALID_EMPLOYEE_ID = "Employee id is invalid.";
        public const string NO_EMPLOYEES_FOUND = "No employees found in the city of";
    }
}
